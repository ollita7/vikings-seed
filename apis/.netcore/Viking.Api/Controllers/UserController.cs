using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Viking.DataAccess;
using Viking.Sdk;

namespace Viking.Api.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly UserDataAccess _userData;
        protected readonly JwtService _jwtServices;
        protected readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration, IMapper mapper)
        {
            _userData = new UserDataAccess(configuration, mapper);
            _jwtServices = new JwtService(configuration);
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDataIn data)
        {
            (RetornoDataOut retorno, LoginOut loginOut) = _userData.Login(data);
            if (retorno.Result == Retorno.Error)
                return StatusCode(200, retorno);

            RetornoDataOut DataRetorno = new RetornoDataOut
            {
                Data = new { Token = _jwtServices.GenerateSecurityToken(loginOut.Email, loginOut.Username, loginOut.Id.ToString()) }
            };
            return StatusCode(200, DataRetorno);
        }

        [HttpPost("/User")]
        public IActionResult Register(RegisterDataIn data)
        {
            return StatusCode(200, _userData.Register(data));
        }
        [HttpGet("/User/Current")]
        public IActionResult CurrentUser()
        {
            string user = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return StatusCode(200, new RetornoDataOut { Msg = $"Current user: {user}" });
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