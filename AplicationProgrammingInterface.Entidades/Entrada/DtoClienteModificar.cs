namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para modificar un Cliente
    /// </summary>
    public class DtoClienteModificar
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoClienteModificar()
        {
            IdCliente = 0;
            Nombres = string.Empty;
            Genero = string.Empty;
            Edad = 0;
            Identificacion = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Contrasenia = string.Empty;
        }

        /// <summary>
        /// Identificador Cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }

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
        /// Contrasenia
        /// </summary>
        public string Contrasenia { get; set; }
    }
}
