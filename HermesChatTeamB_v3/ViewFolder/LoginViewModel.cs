using System.ComponentModel.DataAnnotations;

namespace HermesChatTeamB_v3.ViewModels
{

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, write your Email")]
        [Display(Name = "Email")]
      
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, insert password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}