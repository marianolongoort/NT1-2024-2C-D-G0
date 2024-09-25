using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        [Display(Name ="Número")]
        [Range(100000,99999999,ErrorMessage ="debe estar entre {1} y {2}")]
        public int Numero { get; set; }

        public TipoTelefono TipoTelefono { get; set; }

        //Prop Navegacional
        public Cliente  Cliente{ get; set; }

        //Prop Relacional
        [Display(Name ="Cliente")]
        public int ClienteId { get; set; }
    }
}
