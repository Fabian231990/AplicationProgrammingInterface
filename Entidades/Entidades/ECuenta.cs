namespace Dto.Entidades
{
    public partial class ECuenta
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
