#nullable disable

namespace AccesoDatos.Models
{
    /// <summary>
    /// Clase Parametro
    /// </summary>
    public partial class Parametro
    {
        /// <summary>
        /// Identificador Parametro
        /// </summary>
        public int IdParametro { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
    }
}
