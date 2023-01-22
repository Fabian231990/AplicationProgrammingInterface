using System;

namespace Dto.Salida
{
    /// <summary>
    /// Objeto para Consultar los Movimientos del Estado de Cuenta
    /// </summary>
    public class DtoMovimientoEstadoCuenta
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoMovimientoEstadoCuenta()
        {
            Fecha = DateTime.Now;
            Cliente = string.Empty;
            NumeroCuenta = 0;
            Tipo = string.Empty;
            SaldoInicial = 0;
            TotalCredito = 0;
            TotalDebito = 0;
            SaldoDisponible = 0;
            Estado = false;
        }

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Numero Cuenta
        /// </summary>
        public int NumeroCuenta { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Saldo Inicial
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Total Credito
        /// </summary>
        public decimal TotalCredito { get; set; }

        /// <summary>
        /// Total Debito
        /// </summary>
        public decimal TotalDebito { get; set; }

        /// <summary>
        /// Saldo Disponible
        /// </summary>
        public decimal SaldoDisponible { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
