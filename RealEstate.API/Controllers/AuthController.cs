using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;
using RealEstate.Application.ViewModels;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            var tokenString = await _authService.Register(registerUserViewModel);

            if (tokenString != "")
                return Ok(new { tokenString });

            return BadRequest("User cannot be created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            var tokenString = await _authService.Login(loginViewModel);

            if (tokenString != "")
                return Ok(new { tokenString });

            return Unauthorized();
        }

        [Route("checkUserExistsByEmail/{email}")]
        [HttpGet]
        public async Task<IActionResult> CheckUserExistsByEmail(string email)
        {
            var userExists = await _authService.CheckUserExistsByEmail(email);
            return Ok(userExists);
        }
    }
}