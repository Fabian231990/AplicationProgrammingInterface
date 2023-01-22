using System;

namespace Dto.Entidades
{
    /// <summary>
    /// Objeto Entidad Movimiento
    /// </summary>
    public partial class EMovimiento
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EMovimiento()
        {
            IdMovimiento = 0;
            IdCuenta = 0;
            Fecha = DateTime.Now;
            SaldoInicial = 0;
            TipoMovimiento = string.Empty;
            Valor = 0;
            Saldo = 0;
        }

        /// <summary>
        /// Identificador Movimiento
        /// </summary>
        public int IdMovimiento { get; set; }

        /// <summary>
        /// Identificador Cuenta
        /// </summary>
        public int IdCuenta { get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Saldo Inicial
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Tipo Movimiento
        /// </summary>
        public string TipoMovimiento { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Saldo
        /// </summary>
        public decimal Saldo { get; set; }
    }
}
