using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
