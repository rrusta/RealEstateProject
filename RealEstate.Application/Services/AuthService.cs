using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;
using RealEstate.Domain.IdentityModels;
using RealEstate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<bool> CheckUserExistsByEmail(string email)
        {
            return await _authRepository.CheckUserExistsByEmail(email);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            var token = await _authRepository.Login(username: loginViewModel.Username, password: loginViewModel.Password);

            return token;
        }

        public async Task<string> Register(RegisterUserViewModel registerViewModel)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                CreatedAt = DateTime.Now
            };

            var token = await _authRepository.Register(user, registerViewModel.Password);

            return token;
        }
    }
}
