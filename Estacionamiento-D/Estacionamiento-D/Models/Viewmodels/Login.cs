using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models.Viewmodels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Recordarme")]
        public bool RememberMe { get; set; }
    }
}
