using AccesoDatos.Models;
using Dominio;
using Dto.Entidades;
using Dto.Entrada;
using Dto.General;
using Dto.Salida;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    /// <summary>
    /// Movimiento Repositorio
    /// </summary>
    public class MovimientoRepositorio : IMovimientoRepositorio
    {
        private readonly BDAppInterfaceContext DBContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public MovimientoRepositorio(BDAppInterfaceContext dBContext)
        {
            DBContext = dBContext;
        }

        /// <summary>
        /// Consultar Parametro
        /// </summary>
        /// <param name="Parametro">Parametro consultar detalle</param>
        /// <returns>Valor del Parametro</returns>
        public async Task<decimal> ConsultarParametro(string Parametro)
        {
            try
            {
                var resultado = (from p in DBContext.Parametros
                                 where p.Descripcion == Parametro
                                 select p.Valor).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Detalle Cuenta
        /// </summary>
        /// <param name="NumeroCuenta">Numero Cuenta</param>
        /// <returns>Detalle de la Cuenta</returns>
        public async Task<ECuenta> ConsultarDetalleCuenta(int NumeroCuenta)
        {
            try
            {
                var resultado = (from c in DBContext.Cuenta
                                 where c.NumeroCuenta == NumeroCuenta && c.Estado == true
                                 select new ECuenta
                                 {
                                     IdCuenta = c.IdCuenta,
                                     IdCliente = c.IdCliente,
                                     NumeroCuenta = c.NumeroCuenta,
                                     TipoCuenta = c.TipoCuenta,
                                     SaldoInicial = c.SaldoInicial,
                                     Estado = c.Estado
                                 }).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Detalles Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle del Cliente</returns>
        public async Task<DtoClienteConsultar> ConsultarDetallesCliente(int idCliente)
        {
            try
            {
                var resultado = (from c in DBContext.Clientes
                                 join p in DBContext.Personas on c.IdPersona equals p.IdPersona
                                 where c.IdCliente == idCliente && c.Estado == true
                                 select new DtoClienteConsultar
                                 {
                                     Nombres = p.Nombre,
                                     Direccion = p.Direccion,
                                     Telefono = p.Telefono,
                                     Contrasenia = c.Contrasena,
                                     Estado = c.Estado
                                 }).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crear Movimiento
        /// </summary>
        /// <param name="ObjEntidadMovimiento">Objeto Entidad Movimiento</param>
        /// <returns>Identificador del Movimiento</returns>
        public async Task<int> CrearMovimiento(EMovimiento entrada)
        {
            try
            {
                Movimiento movimiento = new()
                {
                    IdMovimiento = entrada.IdMovimiento,
                    IdCuenta = entrada.IdCuenta,
                    Fecha = entrada.Fecha,
                    SaldoInicial = entrada.SaldoInicial,
                    TipoMovimiento = entrada.TipoMovimiento,
                    Valor = entrada.Valor,
                    Saldo = entrada.Saldo
                };

                await DBContext.Set<Movimiento>().AddAsync(movimiento);
                await DBContext.SaveChangesAsync();

                return movimiento.IdMovimiento;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualizar Saldo Inicial
        /// </summary>
        /// <param name="ObjEntidadCuenta">Objeto Entidad Cuenta</param>
        /// <returns>Saldo de la Cuenta</returns>
        public async Task<int> ActualizarSaldoInicial(ECuenta entrada)
        {
            try
            {
                Cuenta cuenta = new()
                {
                    IdCuenta = entrada.IdCuenta,
                    IdCliente = entrada.IdCliente,
                    NumeroCuenta = entrada.NumeroCuenta,
                    TipoCuenta = entrada.TipoCuenta,
                    SaldoInicial = entrada.SaldoInicial,
                    Estado = entrada.Estado
                };

                DBContext.Set<Cuenta>().Attach(cuenta);
                DBContext.Entry(cuenta).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return cuenta.IdCuenta;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Debito Diario
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Consultar monto Debito Diario</returns>
        public async Task<decimal> ConsultarDebitoDiario(int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals(Constantes.DEBITO)
                                 && m.Fecha.Date >= DateTime.Now.Date
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Debitos Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle de Debitos en la Cuenta</returns>
        public async Task<decimal> ConsultarDebitosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals(Constantes.DEBITO)
                                 && (m.Fecha.Date >= entrada.FechaInicio.Date && m.Fecha.Date <= entrada.FechaFin.Date)
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Creditos Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle de Creditos en la Cuenta</returns>
        public async Task<decimal> ConsultarCreditosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals(Constantes.CREDITO)
                                 && (m.Fecha.Date >= entrada.FechaInicio.Date && m.Fecha.Date <= entrada.FechaFin.Date)
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Saldo Inicial Estado Cuenta
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Saldo que tiene en la Cuenta</returns>
        public async Task<decimal> ConsultarSaldoInicialEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && (m.Fecha.Date >= entrada.FechaInicio.Date && m.Fecha.Date <= entrada.FechaFin.Date)
                                 orderby m.Fecha.Date ascending
                                 select m.SaldoInicial).Take(1).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Consultar Cuentas Cliente
        /// </summary>
        /// <param name="IdCliente">Identificador Cliente</param>
        /// <returns>Retorna Cuenta del Cliente</returns>
        public async Task<ICollection<ECuenta>> ConsultarCuentasCliente(int IdCliente)
        {
            try
            {
                var resultado = (from c in DBContext.Cuenta
                                 where c.IdCliente == IdCliente && c.Estado == true
                                 select new ECuenta
                                 {
                                     IdCuenta = c.IdCuenta,
                                     IdCliente = c.IdCliente,
                                     NumeroCuenta = c.NumeroCuenta,
                                     TipoCuenta = c.TipoCuenta,
                                     SaldoInicial = c.SaldoInicial,
                                     Estado = c.Estado
                                 }).ToListAsync();
                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
