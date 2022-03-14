using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IMovimientoRepositorio
    {
        Task<decimal> ConsultarParametro(string Parametro);

        Task<ECuenta> ConsultarDetalleCuenta(int NumeroCuenta);

        Task<DtoClienteConsultar> ConsultarDetallesCliente(int idCliente);

        Task<int> CrearMovimiento(EMovimiento entrada);

        Task<int> ActualizarSaldoInicial(ECuenta entrada);

        Task<decimal> ConsultarDebitoDiario(int IdCuenta);

        Task<decimal> ConsultarDebitosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta);

        Task<decimal> ConsultarCreditosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta);

        Task<ICollection<ECuenta>> ConsultarCuentasCliente(int IdCliente);

        Task<decimal> ConsultarSaldoInicialEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta);
    }
}
