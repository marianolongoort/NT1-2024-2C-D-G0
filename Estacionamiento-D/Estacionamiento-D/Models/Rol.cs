using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_D.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() :base(){}

        public Rol(string rolName) : base(rolName) { }

        [Display(Name="Nombre")]
        public override string Name {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}
