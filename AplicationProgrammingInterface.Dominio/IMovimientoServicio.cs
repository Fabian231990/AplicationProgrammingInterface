using Dto.Entrada;
using Dto.Salida;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Movimiento Servicio
    /// </summary>
    public interface IMovimientoServicio
    {
        /// <summary>
        /// Registrar Movimiento
        /// </summary>
        /// <param name="ObjMovimientoRealizar">Objeto Movimiento Realizar</param>
        /// <returns>Respuesta del Movimiento</returns>
        Task<DtoMovimientoRespuesta> RegistrarMovimiento(DtoMovimientoRealizar ObjMovimientoRealizar);

        /// <summary>
        /// Estado Cuenta Movimiento
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <returns>Consultar los Movimientos del Estado de Cuenta</returns>
        Task<ICollection<DtoMovimientoEstadoCuenta>> EstadoCuentaMovimiento(DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta);
    }
}
