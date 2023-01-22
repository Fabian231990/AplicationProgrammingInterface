namespace Dto.Entidades
{
    /// <summary>
    /// Objeto Entidad Cuenta
    /// </summary>
    public partial class ECuenta
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ECuenta()
        {
            IdCuenta = 0;
            IdCliente = 0;
            NumeroCuenta = 0;
            TipoCuenta = string.Empty;
            SaldoInicial = 0;
            Estado = false;
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
    }
}
