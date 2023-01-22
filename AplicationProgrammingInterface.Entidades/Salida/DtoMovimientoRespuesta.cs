namespace Dto.Salida
{
    /// <summary>
    /// Objeto respuesta de los Movimientos
    /// </summary>
    public class DtoMovimientoRespuesta
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoMovimientoRespuesta()
        {
            NumeroCuenta = 0;
            Tipo = string.Empty;
            SaldoInicial = 0;
            Movimiento = string.Empty;
            Estado = false;
        }

        /// <summary>
        /// Numero Cuenta
        /// </summary>
        public int NumeroCuenta { get; set; }

        /// <summary>
        /// SaldoInicial
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Saldo Inicial
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Movimiento
        /// </summary>
        public string Movimiento { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
