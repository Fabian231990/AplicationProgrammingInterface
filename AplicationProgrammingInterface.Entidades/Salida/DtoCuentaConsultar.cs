namespace Dto.Salida
{
    /// <summary>
    /// Objeto para Consultar una Cuenta
    /// </summary>
    public class DtoCuentaConsultar
    {
        /// <summary>
        /// Objeto para realizar Movimientos
        /// </summary>
        public DtoCuentaConsultar()
        {
            NumeroCuenta = 0;
            Tipo = string.Empty;
            SaldoInicial = 0;
            Estado = false;
            Cliente = string.Empty;
        }

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
        /// Estado
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public string Cliente { get; set; }
    }
}
