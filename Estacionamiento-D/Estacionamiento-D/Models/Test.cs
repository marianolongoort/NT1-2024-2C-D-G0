using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Test
    {
        public Test(string apellido)
        {
            Apellido = apellido;
        }

        [Key]
        public int Identificador { get; set; }
        public string Nombre { get; set; }

        private string _apellido;

        public string Apellido {
            get { return _apellido.ToUpper();  }
            set { _apellido = value.ToLower(); }
        }

    }
}
