using System;

namespace Dto.Entrada
{
    /// <summary>
    /// Objeto para Consultar los Movimientos del Estado de Cuenta
    /// </summary>
    public class DtoMovimientoConsultaEstadoCuenta
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DtoMovimientoConsultaEstadoCuenta()
        {
            IdCliente = 0;
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now;
        }

        /// <summary>
        /// Identificador Cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha Fin
        /// </summary>
        public DateTime FechaFin { get; set; }
    }
}
