namespace Dto.Entidades
{
    /// <summary>
    /// Objeto Entidad Cliente
    /// </summary>
    public partial class ECliente
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ECliente()
        {
            IdCliente = 0;
            IdPersona = 0;
            Contrasenia = string.Empty;
            Estado = false;
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
        /// Contrasenia
        /// </summary>
        public string Contrasenia { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
