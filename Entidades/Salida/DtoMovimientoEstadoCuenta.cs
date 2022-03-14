using System;

namespace Dto.Salida
{
    public class DtoMovimientoEstadoCuenta
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal SaldoDisponible { get; set; }
        public bool Estado { get; set; }
    }
}
