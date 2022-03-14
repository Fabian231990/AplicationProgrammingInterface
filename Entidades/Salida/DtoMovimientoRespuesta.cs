namespace Dto.Salida
{
    public class DtoMovimientoRespuesta
    {
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Movimiento { get; set; }
        public bool Estado { get; set; }
    }
}
