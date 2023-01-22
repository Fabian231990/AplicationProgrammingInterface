using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    /// <summary>
    /// Clase Cliente
    /// </summary>
    public partial class Cliente
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        /// <summary>
        /// Identificador Cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Identificador Persona
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Contrasena
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// IdPersonaNavigation
        /// </summary>
        public virtual Persona IdPersonaNavigation { get; set; }

        /// <summary>
        /// Cuenta
        /// </summary>
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
