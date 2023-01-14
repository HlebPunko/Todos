using Identity.Application.Models;

namespace Identity.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
        Task<bool> RegisterAsync(RegisterModel registerModel);
    }
}
