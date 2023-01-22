namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para crear un Cliente
    /// </summary>
    public class DtoClienteCrear
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoClienteCrear()
        {
            IdPersona = 0;
            Contrasena = string.Empty;
        }

        /// <summary>
        /// Identificador Persona
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Contrasena
        /// </summary>
        public string Contrasena { get; set; }
    }
}
