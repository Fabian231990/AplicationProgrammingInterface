using System.Collections.Generic;

#nullable disable

namespace AccesoDatos.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
