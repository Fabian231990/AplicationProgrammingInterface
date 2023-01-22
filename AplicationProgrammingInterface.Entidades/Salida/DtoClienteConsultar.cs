namespace Dto.Salida
{
    /// <summary>
    /// Objeto para Consultar un Cliente
    /// </summary>
    public class DtoClienteConsultar
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoClienteConsultar()
        {
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Contrasenia = string.Empty;
            Estado = false;
        }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono { get; set; }

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
