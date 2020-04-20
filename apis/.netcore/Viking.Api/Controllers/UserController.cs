using Microsoft.AspNetCore.Mvc;
using Viking.Sdk;

namespace Viking.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginDataIn data)
        {
            return StatusCode(200,data);
        }
        [HttpPost("/User")]
        public IActionResult Register(RegisterDataIn data)
        {
            return StatusCode(200,data);
        }
        [HttpGet("/User/Current")]
        public IActionResult CurrentUser() {
            return StatusCode(200, new { mensaje ="Tamo ativo" });
        }
        [HttpPost("/User/Forgot-Password")]
        public IActionResult ForgotPassword(ForgotPasswordDataIn data) {
            return StatusCode(200,data);
        }
        [HttpPost("/User/Reset-Password")]
        public IActionResult ResetPassword(ResetPasswordDataIn data) {
            return StatusCode(200,data);
        }
    }
}