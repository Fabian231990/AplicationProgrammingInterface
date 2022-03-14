using System;

#nullable disable

namespace AccesoDatos.Models
{
    public partial class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoInicial { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
    }
}
