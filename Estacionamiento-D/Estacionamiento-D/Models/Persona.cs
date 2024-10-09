using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamiento_D.Models
{
    public class Persona : IdentityUser<int>
    {
        private const string _requiredMsg = "El campo {0} es requerido";
        //public int Id { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "{0} debe tener como minimo {2} y como maximo {1}")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = _requiredMsg)]
        [MinLength(5, ErrorMessage = "{0} debe tener como minimo {1}")]
        [MaxLength(200, ErrorMessage = "{0} debe tener como maximo {1}")]
        public string Apellido { get; set; }



        public Direccion Direccion { get; set; }

        [Required(ErrorMessage = _requiredMsg)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public override string Email {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get
            {
                return $"{Apellido}, {Nombre}";
            }

        }
    }
}
