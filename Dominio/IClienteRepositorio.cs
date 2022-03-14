using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IClienteRepositorio
    {
        Task<DtoClienteConsultar> ConsultarCliente(int idCliente);

        Task<int> CrearCliente(ECliente request);

        Task<int> ObtenerIdPersona(int idCliente);

        Task<int> ModificarCliente(DtoClienteModificar ClienteModificar, int IdPersona);

        Task<int> EliminarCliente(int IdCliente, int IdPersona);
    }
}
