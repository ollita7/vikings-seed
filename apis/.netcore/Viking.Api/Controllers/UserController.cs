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
        public UserController(IConfiguration configuration)
        {
            _jwtServices = new JwtService(configuration);
        }


        [HttpPost]
        public IActionResult Login(LoginDataIn data)
        {
            return StatusCode(200, new { Token= _jwtServices.GenerateSecurityToken("pablo.ferrari@gmail.com","pablo","23")} );
        }
        [HttpPost("/User")]
        public IActionResult Register(RegisterDataIn data)
        {
            if(_userData.UserExist(data.UserName))
            return StatusCode(200,"User already exists");


            return StatusCode(200, data);
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