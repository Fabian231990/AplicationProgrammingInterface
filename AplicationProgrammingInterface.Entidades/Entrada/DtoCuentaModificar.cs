namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para modificar una Cuenta
    /// </summary>
    public class DtoCuentaModificar
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoCuentaModificar()
        {
            IdCuenta = 0;
            IdCliente = 0;
            NumeroCuenta = 0;
            TipoCuenta = string.Empty;
            SaldoInicial = 0;
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
        public int SaldoInicial { get; set; }
    }
}
