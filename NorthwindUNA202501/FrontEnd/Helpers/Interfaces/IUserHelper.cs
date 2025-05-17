using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUserHelper
    {
        Task<bool> RegisterAsync(RegisterViewModel register);
    }
}
