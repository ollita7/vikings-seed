using System.ComponentModel.DataAnnotations;

namespace Viking.Sdk
{
    public class ResetPasswordDataIn
    {
        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Password need to be at least 6 characters")]
        public string Password { get; set; }
    }
}