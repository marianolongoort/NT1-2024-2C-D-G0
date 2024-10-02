using System;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; } = "ND";
        public int Numero { get; set; }

        //Prop Navegacional
        public Persona  Persona{ get; set; }

        //Prop Relacional
        [Required]
        public int PersonaId { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
    }
}
