using System;

namespace Dto.Entidades
{
    public partial class EMovimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoInicial { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}
