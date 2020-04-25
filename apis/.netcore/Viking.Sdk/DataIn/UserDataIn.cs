using System.ComponentModel.DataAnnotations;

namespace Viking.Sdk
{
    public class LoginDataIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class RegisterDataIn
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Password need to be at least 6 characters")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class ResetPasswordDataIn
    {
        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Password need to be at least 6 characters")]
        public string Password { get; set; }
    }
    public class ForgotPasswordDataIn
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    }

}