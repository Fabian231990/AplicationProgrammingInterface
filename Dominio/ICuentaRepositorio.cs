using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    public interface ICuentaRepositorio
    {
        Task<DtoCuentaConsultar> ConsultarCuenta(int idCuenta);

        Task<int> CrearCuenta(ECuenta CuentaNueva);

        Task<int> ModificarCuenta(DtoCuentaModificar CuentaModificar);

        Task<ECuenta> ObtenerDetalleCuenta(int IdCuenta);

        Task<int> EliminarCuenta(int IdCuenta, ECuenta DetalleCuenta);
    }
}
