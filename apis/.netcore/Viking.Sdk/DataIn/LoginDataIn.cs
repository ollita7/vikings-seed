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
}