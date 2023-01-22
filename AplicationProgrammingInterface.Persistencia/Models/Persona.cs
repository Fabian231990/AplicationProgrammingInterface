using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    /// <summary>
    /// Clase Persona
    /// </summary>
    public partial class Persona
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        /// <summary>
        /// Identificador Persona
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Genero
        /// </summary>
        public string Genero { get; set; }

        /// <summary>
        /// Edad
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Identificacion
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Clientes
        /// </summary>
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
