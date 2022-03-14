using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    public interface ICuentaServicio
    {
        Task<DtoCuentaConsultar> ConsultarCuenta(int IdCuenta);
        Task<int> CrearCuenta(DtoCuentaCrear entrada);
        Task<int> ModificarCuenta(DtoCuentaModificar entrada);
        Task<int> EliminarCuenta(int IdCuenta);
    }
}
