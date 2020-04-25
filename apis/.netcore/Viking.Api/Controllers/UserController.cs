using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Viking.DataAccess;
using Viking.Sdk;

namespace Viking.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly UserDataAccess _userData;
        protected readonly JwtService _jwtServices;
        public UserController(IConfiguration configuration, IMapper mapper)
        {
            _userData = new UserDataAccess(mapper);
            _jwtServices = new JwtService(configuration);
        }


        [HttpPost]
        public IActionResult Login(LoginDataIn data)
        {
            return StatusCode(200, new { Token = _jwtServices.GenerateSecurityToken("pablo.ferrari@gmail.com", "pablo", "23") });
        }
        [HttpPost("/User")]
        public IActionResult Register(RegisterDataIn data)
        {
            try
            {
                return StatusCode(200, _userData.Register(data));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpGet("/User/Current")]
        public IActionResult CurrentUser()
        {
            return StatusCode(200, new { mensaje = "Tamo ativo" });
        }
        [HttpPost("/User/Forgot-Password")]
        public IActionResult ForgotPassword(ForgotPasswordDataIn data)
        {
            return StatusCode(200, data);
        }
        [HttpPost("/User/Reset-Password")]
        public IActionResult ResetPassword(ResetPasswordDataIn data)
        {
            return StatusCode(200, data);
        }
    }
}