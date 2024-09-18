using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Persona
    {
        private const string _requiredMsg = "El campo {0} es requerido";
        public int Id { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [StringLength(200,MinimumLength =5,ErrorMessage ="{0} debe tener como minimo {2} y como maximo {1}")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = _requiredMsg)]
        [MinLength(5,ErrorMessage = "{0} debe tener como minimo {1}")]
        [MaxLength(200, ErrorMessage = "{0} debe tener como maximo {1}")]
        public string Apellido { get; set; }

        

        public Direccion Direccion { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [EmailAddress]
        [Display(Name ="Correo")]
        public string Email { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
