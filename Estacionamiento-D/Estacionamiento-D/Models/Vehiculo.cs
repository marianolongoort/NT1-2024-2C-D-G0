using System.Collections.Generic;

namespace Estacionamiento_D.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos{ get; set; }
    }
}
