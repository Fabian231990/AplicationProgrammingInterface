using Dominio;
using System.Threading.Tasks;
using Dto.Salida;
using Dto.Entrada;
using System;
using Dto.Entidades;
using System.Collections.Generic;

namespace Servicio
{
    public class MovimientoServicio : IMovimientoServicio
    {
        private readonly IMovimientoRepositorio IMovimientoRepositorio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iMovimientoRepositorio"></param>
        public MovimientoServicio(IMovimientoRepositorio iMovimientoRepositorio)
        {
            IMovimientoRepositorio = iMovimientoRepositorio;
        }

        /// <summary>
        /// RegistrarMovimiento
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<DtoMovimientoRespuesta> RegistrarMovimiento(DtoMovimientoRealizar entrada)
        {
            try
            {
                DtoMovimientoRespuesta resultado = new();

                decimal ParametroMaximoRetiro = await IMovimientoRepositorio.ConsultarParametro("LimiteDiarioRetiro");

                var DetalleCuenta = await IMovimientoRepositorio.ConsultarDetalleCuenta(entrada.NumeroCuenta);
                if (DetalleCuenta == null)
                    throw new Exception("Cuenta no existe");

                if ((DetalleCuenta.SaldoInicial == 0 || entrada.Valor > DetalleCuenta.SaldoInicial) && entrada.TipoMovimiento.Equals("Debito"))
                    throw new Exception("Saldo no disponible");

                if (entrada.TipoMovimiento.Equals("Debito"))
                {
                    var montoDiarioDebitado = await IMovimientoRepositorio.ConsultarDebitoDiario(DetalleCuenta.IdCuenta);
                    if (((montoDiarioDebitado * -1) + entrada.Valor) > ParametroMaximoRetiro)
                        throw new Exception("Cupo diario Excedido");
                }

                EMovimiento eMovimiento = new();
                eMovimiento.IdCuenta = DetalleCuenta.IdCuenta;
                eMovimiento.Fecha = DateTime.Now;
                eMovimiento.SaldoInicial = DetalleCuenta.SaldoInicial;
                eMovimiento.TipoMovimiento = entrada.TipoMovimiento;

                string StrMovimiento = string.Empty;
                switch (entrada.TipoMovimiento)
                {
                    case "Debito": //-
                        decimal valor = entrada.Valor * -1;
                        eMovimiento.Valor = valor;
                        eMovimiento.Saldo = DetalleCuenta.SaldoInicial + valor;
                        StrMovimiento = "Retiro de " + entrada.Valor.ToString();
                        break;
                    case "Credito": //+
                        eMovimiento.Valor = entrada.Valor;
                        eMovimiento.Saldo = DetalleCuenta.SaldoInicial + entrada.Valor;
                        StrMovimiento = "Deposito de " + entrada.Valor.ToString();
                        break;
                }

                var RegistrarMovimiento = await IMovimientoRepositorio.CrearMovimiento(eMovimiento);

                ECuenta eCuenta = new()
                {
                    IdCuenta = DetalleCuenta.IdCuenta,
                    IdCliente = DetalleCuenta.IdCliente,
                    NumeroCuenta = DetalleCuenta.NumeroCuenta,
                    TipoCuenta = DetalleCuenta.TipoCuenta,
                    SaldoInicial = eMovimiento.Saldo,
                    Estado = true
                };

                var ActualizarSaldo = await IMovimientoRepositorio.ActualizarSaldoInicial(eCuenta);

                resultado.NumeroCuenta = DetalleCuenta.NumeroCuenta;
                resultado.Estado = true;
                resultado.Tipo = DetalleCuenta.TipoCuenta;
                resultado.SaldoInicial = DetalleCuenta.SaldoInicial;
                resultado.Movimiento = StrMovimiento;

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EstadoCuentaMovimiento
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<ICollection<DtoMovimientoEstadoCuenta>> EstadoCuentaMovimiento(DtoMovimientoConsultaEstadoCuenta entrada)
        {
            try
            {
                List<DtoMovimientoEstadoCuenta> resultado = new();

                var DetalleCliente = await IMovimientoRepositorio.ConsultarDetallesCliente(entrada.IdCliente);
                if (DetalleCliente == null)
                    throw new Exception("Cliente no existe");

                if ( entrada.FechaInicio.Date > entrada.FechaFin.Date)
                    throw new Exception("Error en el rango de las fechas");


                var CuentasCliente = await IMovimientoRepositorio.ConsultarCuentasCliente(entrada.IdCliente);

                foreach (var cuentas in CuentasCliente)
                {
                    DtoMovimientoEstadoCuenta estadoCuentaDetalle = new()
                    {
                        TotalDebito = await IMovimientoRepositorio.ConsultarDebitosEstadoCuenta(entrada, cuentas.IdCuenta),
                        TotalCredito = await IMovimientoRepositorio.ConsultarCreditosEstadoCuenta(entrada, cuentas.IdCuenta),
                        SaldoInicial = await IMovimientoRepositorio.ConsultarSaldoInicialEstadoCuenta(entrada, cuentas.IdCuenta),
                        Cliente = DetalleCliente.Nombres,
                        Estado = true,
                        Fecha = entrada.FechaInicio,
                        NumeroCuenta = cuentas.NumeroCuenta,
                        SaldoDisponible = cuentas.SaldoInicial,
                        Tipo = cuentas.TipoCuenta
                    };
                    resultado.Add(estadoCuentaDetalle);
                }

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
