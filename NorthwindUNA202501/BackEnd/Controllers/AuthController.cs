using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        ITokenService _tokenService;

        public AuthController(ITokenService tokenService,
                        UserManager<IdentityUser> userManager)
        {
                _tokenService = tokenService;
            _userManager = userManager; 
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            IdentityUser user = await _userManager.FindByNameAsync(login.UserName);
            LoginDTO loginDTO = new LoginDTO();
            if (user != null && await _userManager.CheckPasswordAsync(user,login.Password)) { 
                    var userRoles = await _userManager.GetRolesAsync()
            
            }

        }
    }
}
