namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para crear una Cuenta
    /// </summary>
    public class DtoCuentaCrear
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoCuentaCrear()
        {
            IdCliente = 0;
            NumeroCuenta = 0;
            TipoCuenta = string.Empty;
            SaldoInicial = 0;
        }

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
