using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models.Viewmodels
{
    public class RegistroUsuario
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmacionPassword { get; set; }

        [Display(Name ="Recordarme")]
        public bool RememberMe { get; set; } = false;
    }
}
