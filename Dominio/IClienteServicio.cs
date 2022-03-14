using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IClienteServicio
    {
        Task<DtoClienteConsultar> ConsultarCliente(int idCliente);
        Task<int> CrearCliente(DtoClienteCrear request);
        Task<int> ModificarCliente(DtoClienteModificar ClienteModificar);
        Task<int> EliminarCliente(int idCliente);
    }
}
