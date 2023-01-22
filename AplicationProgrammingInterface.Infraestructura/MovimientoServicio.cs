using Dominio;
using System.Threading.Tasks;
using Dto.Salida;
using Dto.Entrada;
using System;
using Dto.Entidades;
using System.Collections.Generic;
using Dto.General;

namespace Servicio
{
    /// <summary>
    /// Movimiento Servicio
    /// </summary>
    public class MovimientoServicio : IMovimientoServicio
    {
        private readonly IMovimientoRepositorio IMovimientoRepositorio;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="iMovimientoRepositorio">Interface Movimiento Repositorio</param>
        public MovimientoServicio(IMovimientoRepositorio iMovimientoRepositorio)
        {
            IMovimientoRepositorio = iMovimientoRepositorio;
        }

        /// <summary>
        /// RegistrarMovimiento
        /// </summary>
        /// <param name="ObjMovimientoRealizar">Objeto Movimiento Realizar</param>
        /// <returns>Respuesta del Movimiento</returns>
        public async Task<DtoMovimientoRespuesta> RegistrarMovimiento(DtoMovimientoRealizar ObjMovimientoRealizar)
        {
            try
            {
                DtoMovimientoRespuesta resultado = new();

                decimal ParametroMaximoRetiro = await IMovimientoRepositorio.ConsultarParametro(Constantes.LIMITE_DIARIO_RETIRO);

                var DetalleCuenta = await IMovimientoRepositorio.ConsultarDetalleCuenta(ObjMovimientoRealizar.NumeroCuenta);
                if (DetalleCuenta == null)
                    throw new Exception(Constantes.CUENTA_NO_EXISTE);

                if ((DetalleCuenta.SaldoInicial == 0 || ObjMovimientoRealizar.Valor > DetalleCuenta.SaldoInicial) && ObjMovimientoRealizar.TipoMovimiento.Equals(Constantes.DEBITO))
                    throw new Exception(Constantes.SALDO_NO_DISPONIBLE);

                if (ObjMovimientoRealizar.TipoMovimiento.Equals(Constantes.DEBITO))
                {
                    var montoDiarioDebitado = await IMovimientoRepositorio.ConsultarDebitoDiario(DetalleCuenta.IdCuenta);
                    if (((montoDiarioDebitado * -1) + ObjMovimientoRealizar.Valor) > ParametroMaximoRetiro)
                        throw new Exception(Constantes.CUPO_DIARIO_EXCEDIDO);
                }

                EMovimiento eMovimiento = new();
                eMovimiento.IdCuenta = DetalleCuenta.IdCuenta;
                eMovimiento.Fecha = DateTime.Now;
                eMovimiento.SaldoInicial = DetalleCuenta.SaldoInicial;
                eMovimiento.TipoMovimiento = ObjMovimientoRealizar.TipoMovimiento;

                string StrMovimiento = string.Empty;
                switch (ObjMovimientoRealizar.TipoMovimiento)
                {
                    case Constantes.DEBITO: //-
                        decimal valor = ObjMovimientoRealizar.Valor * -1;
                        eMovimiento.Valor = valor;
                        eMovimiento.Saldo = DetalleCuenta.SaldoInicial + valor;
                        StrMovimiento = Constantes.RETIRO_DE + ObjMovimientoRealizar.Valor.ToString();
                        break;
                    case Constantes.CREDITO: //+
                        eMovimiento.Valor = ObjMovimientoRealizar.Valor;
                        eMovimiento.Saldo = DetalleCuenta.SaldoInicial + ObjMovimientoRealizar.Valor;
                        StrMovimiento = Constantes.DEPOSITO_DE + ObjMovimientoRealizar.Valor.ToString();
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
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// EstadoCuentaMovimiento
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <returns>Detalle del Estado Cuenta</returns>
        public async Task<ICollection<DtoMovimientoEstadoCuenta>> EstadoCuentaMovimiento(DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta)
        {
            try
            {
                List<DtoMovimientoEstadoCuenta> resultado = new();

                var DetalleCliente = await IMovimientoRepositorio.ConsultarDetallesCliente(ObjMovimientoConsultaEstadoCuenta.IdCliente);
                if (DetalleCliente == null)
                    throw new Exception(Constantes.CLIENTE_NO_EXISTE);

                if (ObjMovimientoConsultaEstadoCuenta.FechaInicio.Date > ObjMovimientoConsultaEstadoCuenta.FechaFin.Date)
                    throw new Exception(Constantes.ERROR_RANGO_FECHAS);


                var CuentasCliente = await IMovimientoRepositorio.ConsultarCuentasCliente(ObjMovimientoConsultaEstadoCuenta.IdCliente);

                foreach (var cuentas in CuentasCliente)
                {
                    DtoMovimientoEstadoCuenta estadoCuentaDetalle = new()
                    {
                        TotalDebito = await IMovimientoRepositorio.ConsultarDebitosEstadoCuenta(ObjMovimientoConsultaEstadoCuenta, cuentas.IdCuenta),
                        TotalCredito = await IMovimientoRepositorio.ConsultarCreditosEstadoCuenta(ObjMovimientoConsultaEstadoCuenta, cuentas.IdCuenta),
                        SaldoInicial = await IMovimientoRepositorio.ConsultarSaldoInicialEstadoCuenta(ObjMovimientoConsultaEstadoCuenta, cuentas.IdCuenta),
                        Cliente = DetalleCliente.Nombres,
                        Estado = true,
                        Fecha = ObjMovimientoConsultaEstadoCuenta.FechaInicio,
                        NumeroCuenta = cuentas.NumeroCuenta,
                        SaldoDisponible = cuentas.SaldoInicial,
                        Tipo = cuentas.TipoCuenta
                    };
                    resultado.Add(estadoCuentaDetalle);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
