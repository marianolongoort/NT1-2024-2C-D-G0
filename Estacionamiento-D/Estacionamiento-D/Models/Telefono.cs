namespace Estacionamiento_D.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public TipoTelefono TipoTelefono { get; set; }

        //Prop Navegacional
        public Cliente  Cliente{ get; set; }

        //Prop Relacional
        public int ClienteId { get; set; }
    }
}
