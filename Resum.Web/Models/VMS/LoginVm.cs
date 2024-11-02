using System.ComponentModel.DataAnnotations;

namespace Resum.Web.Models.VMS
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Email Alani Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;

    }
}
