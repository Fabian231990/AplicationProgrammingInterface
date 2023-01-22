using Dto.Entrada;
using Dto.Salida;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Cuenta Servicio
    /// </summary>
    public interface ICuentaServicio
    {
        /// <summary>
        /// Consultar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle Cuenta</returns>
        Task<DtoCuentaConsultar> ConsultarCuenta(int IdCuenta);

        /// <summary>
        /// Crear Cuenta
        /// </summary>
        /// <param name="ObjCuentaCrear">Objeto Cuenta Crear</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> CrearCuenta(DtoCuentaCrear ObjCuentaCrear);

        /// <summary>
        /// Modificar Cuenta
        /// </summary>
        /// <param name="ObjCuentaModificar">Objeto Cuenta Modificar</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> ModificarCuenta(DtoCuentaModificar ObjCuentaModificar);

        /// <summary>
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        Task<int> EliminarCuenta(int IdCuenta);
    }
}
