using Dto.Entrada;
using Dto.Salida;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IMovimientoServicio
    {
        Task<DtoMovimientoRespuesta> RegistrarMovimiento(DtoMovimientoRealizar entrada);

        Task<ICollection<DtoMovimientoEstadoCuenta>> EstadoCuentaMovimiento(DtoMovimientoConsultaEstadoCuenta entrada);
    }
}
