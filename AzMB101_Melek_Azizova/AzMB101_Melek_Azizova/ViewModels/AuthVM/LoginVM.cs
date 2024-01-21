using System.ComponentModel.DataAnnotations;

namespace AzMB101_Melek_Azizova.ViewModels.AuthVM
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
