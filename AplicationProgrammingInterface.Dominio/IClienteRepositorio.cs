using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Cliente Repositorio
    /// </summary>
    public interface IClienteRepositorio
    {
        /// <summary>
        /// Consultar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle del Cliente</returns>
        Task<DtoClienteConsultar> ConsultarCliente(int idCliente);

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="ObjEntidadCliente">Objeto Entidad Cliente</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> CrearCliente(ECliente ObjEntidadCliente);

        /// <summary>
        /// Obtener Identificador Persona
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> ObtenerIdPersona(int idCliente);

        /// <summary>
        /// Cliente Modificar
        /// </summary>
        /// <param name="ObjClienteModificar">Objeto Cliente Modificar</param>
        /// <param name="IdPersona">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> ModificarCliente(DtoClienteModificar ObjClienteModificar, int IdPersona);

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="IdCliente">Identificador Cliente</param>
        /// <param name="IdPersona">Identificador Persona</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> EliminarCliente(int IdCliente, int IdPersona);
    }
}
