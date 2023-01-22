namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para realizar Movimientos
    /// </summary>
    public class DtoMovimientoRealizar
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoMovimientoRealizar()
        {
            NumeroCuenta = 0;
            TipoMovimiento = string.Empty;
            Valor = 0;
        }

        /// <summary>
        /// Numero Cuenta
        /// </summary>
        public int NumeroCuenta { get; set; }

        /// <summary>
        /// Tipo Movimiento
        /// </summary>
        public string TipoMovimiento { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
    }
}
