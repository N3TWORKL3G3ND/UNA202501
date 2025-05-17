using System.Security.Claims;
using System.Text;
using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {

        ISecurityHelper _securityHelper;
        IUserHelper _userHelper;

        public LoginController(ISecurityHelper securityHelper, IUserHelper userHelper)
        {
            _securityHelper = securityHelper;
            _userHelper = userHelper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {

            if (ModelState.IsValid) 
            {

                var loginAPI = _securityHelper.Login(user.UserName, user.Password);

                if (loginAPI.Token != null) {

                    TokenAPI token = new TokenAPI
                    {
                        Token = loginAPI.Token.Token,
                        Expiration = loginAPI.Token.Expiration,

                    };

                    HttpContext.Session.SetString("Token", token.Token);


                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserName)

                    };
                    var roles = loginAPI.Roles.ToList();

                    foreach (var role in roles) {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    
                    }


                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);  



                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal
                                        , new AuthenticationProperties
                                        {
                                            IsPersistent = false
                                        }
                                );


                }

                return RedirectToAction("Index","Home");
            
            } else
            {
                ModelState.AddModelError("UserName", "Credenciales Inválidas");
                return View(user);
            }



            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var success = await _userHelper.RegisterAsync(register);

            if (success)
            {
                // Opcional: Redirigir al login
                return RedirectToAction("Login", "Login");
            }

            ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
            return View(register);
        }






















    }
}
