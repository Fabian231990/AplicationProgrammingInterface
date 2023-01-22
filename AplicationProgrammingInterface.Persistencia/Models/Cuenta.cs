using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    /// <summary>
    /// Clase Cuenta
    /// </summary>
    public partial class Cuenta
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        /// <summary>
        /// Identificador Cuenta
        /// </summary>
        public int IdCuenta { get; set; }

        /// <summary>
        /// Identificador Cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Numero Cuenta
        /// </summary>
        public int NumeroCuenta { get; set; }

        /// <summary>
        /// Tipo Cuenta
        /// </summary>
        public string TipoCuenta { get; set; }

        /// <summary>
        /// Saldo Inicial
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// IdClienteNavigation
        /// </summary>
        public virtual Cliente IdClienteNavigation { get; set; }

        /// <summary>
        /// Movimientos
        /// </summary>
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
