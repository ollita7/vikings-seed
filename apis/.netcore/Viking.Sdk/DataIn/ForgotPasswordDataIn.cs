using System.ComponentModel.DataAnnotations;

namespace Viking.Sdk
{
    public class ForgotPasswordDataIn
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    }
}