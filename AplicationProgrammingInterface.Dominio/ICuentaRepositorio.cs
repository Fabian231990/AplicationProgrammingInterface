using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Cuenta Repositorio
    /// </summary>
    public interface ICuentaRepositorio
    {
        /// <summary>
        /// Consultar Cuenta
        /// </summary>
        /// <param name="idCuenta">Identificador Cuenta</param>
        /// <returns>Detalle Cuenta</returns>
        Task<DtoCuentaConsultar> ConsultarCuenta(int idCuenta);

        /// <summary>
        /// Crear Cuenta
        /// </summary>
        /// <param name="ObjEntidadCuenta">Objeto Entidada Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> CrearCuenta(ECuenta ObjEntidadCuenta);

        /// <summary>
        /// Modificar Cuenta
        /// </summary>
        /// <param name="ObjCuentaModificar">Objeto Cuenta Modificar</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> ModificarCuenta(DtoCuentaModificar ObjCuentaModificar);

        /// <summary>
        /// Obtener Detalle Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Objeto Entidada Cuenta</returns>
        Task<ECuenta> ObtenerDetalleCuenta(int IdCuenta);

        /// <summary>
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <param name="ObjEntidadCuenta">Objeto Entidad Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> EliminarCuenta(int IdCuenta, ECuenta ObjEntidadCuenta);
    }
}
