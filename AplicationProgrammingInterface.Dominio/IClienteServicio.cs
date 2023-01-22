using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Cliente Servicio
    /// </summary>
    public interface IClienteServicio
    {
        /// <summary>
        /// Consultar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle Cliente</returns>
        Task<DtoClienteConsultar> ConsultarCliente(int idCliente);

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="ObjClienteCrear">Objeto Cliente Crear</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> CrearCliente(DtoClienteCrear ObjClienteCrear);

        /// <summary>
        /// Modificar Cliente
        /// </summary>
        /// <param name="ObjClienteModificar">Objeto Cliente Modificar</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> ModificarCliente(DtoClienteModificar ObjClienteModificar);

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        Task<int> EliminarCliente(int idCliente);
    }
}
