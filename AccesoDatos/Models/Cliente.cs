using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
