using AutoMapper;
using Identity.Application.Models;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;//TODO This will not work, because, here is a new package
        private readonly IMapper _mapper;

        public AuthService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterAsync(RegisterModel registerModel)
        {
            var user = _mapper.Map<User>(registerModel);

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            return result.Succeeded;
        }
    }
}
