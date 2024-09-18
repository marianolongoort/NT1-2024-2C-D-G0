using System.Collections.Generic;

namespace Estacionamiento_D.Models
{
    public class Cliente : Persona
    {
        //Prop Navegacional
        public List<Telefono> Telefonos { get; set; }


        //public List<ClienteVehiculo> ClientesVehiculos { get; set; }
    }
}
