using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Implementations
{
    public class UserHelper : IUserHelper
    {
        private readonly IServiceHelper _serviceHelper;

        public UserHelper(IServiceHelper serviceHelper)
        {
            _serviceHelper = serviceHelper;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel register)
        {
            try
            {
                var request = new RegisterAPI
                {
                    UserName = register.UserName,
                    Password = register.Password,
                    Email = register.Email
                };

                var response = _serviceHelper.Post("api/Auth/register", request);

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                // Puedes loguear el error si deseas
                return false;
            }
        }
    }
}
