using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Test
    {
        [Key]
        public int Identificador { get; set; }
        public string Nombre { get; set; }

    }
}
