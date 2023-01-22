using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Interface Movimiento Repositorio
    /// </summary>
    public interface IMovimientoRepositorio
    {
        /// <summary>
        /// Consultar Parametro
        /// </summary>
        /// <param name="Parametro">Parametro consultar detalle</param>
        /// <returns>Valor del Parametro</returns>
        Task<decimal> ConsultarParametro(string Parametro);

        /// <summary>
        /// Consultar Detalle Cuenta
        /// </summary>
        /// <param name="NumeroCuenta">Numero Cuenta</param>
        /// <returns>Detalle de la Cuenta</returns>
        Task<ECuenta> ConsultarDetalleCuenta(int NumeroCuenta);

        /// <summary>
        /// Consultar Detalles Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle del Cliente</returns>
        Task<DtoClienteConsultar> ConsultarDetallesCliente(int idCliente);

        /// <summary>
        /// Crear Movimiento
        /// </summary>
        /// <param name="ObjEntidadMovimiento">Objeto Entidad Movimiento</param>
        /// <returns>Identificador del Movimiento</returns>
        Task<int> CrearMovimiento(EMovimiento ObjEntidadMovimiento);

        /// <summary>
        /// Actualizar Saldo Inicial
        /// </summary>
        /// <param name="ObjEntidadCuenta">Objeto Entidad Cuenta</param>
        /// <returns>Saldo de la Cuenta</returns>
        Task<int> ActualizarSaldoInicial(ECuenta ObjEntidadCuenta);

        /// <summary>
        /// Consultar Debito Diario
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Consultar monto Debito Diario</returns>
        Task<decimal> ConsultarDebitoDiario(int IdCuenta);

        /// <summary>
        /// Consultar Debitos Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle de Debitos en la Cuenta</returns>
        Task<decimal> ConsultarDebitosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta, int IdCuenta);

        /// <summary>
        /// Consultar Creditos Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle de Creditos en la Cuenta</returns>
        Task<decimal> ConsultarCreditosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta, int IdCuenta);

        /// <summary>
        /// Consultar Cuentas Cliente
        /// </summary>
        /// <param name="IdCliente">Identificador Cliente</param>
        /// <returns>Retorna Cuenta del Cliente</returns>
        Task<ICollection<ECuenta>> ConsultarCuentasCliente(int IdCliente);

        /// <summary>
        /// Consultar Saldo Inicial Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Saldo que tiene en la Cuenta</returns>
        Task<decimal> ConsultarSaldoInicialEstadoCuenta(DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta, int IdCuenta);
    }
}
