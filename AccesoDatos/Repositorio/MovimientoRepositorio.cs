using AccesoDatos.Models;
using Dominio;
using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
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
        /// ConsultarParametro
        /// </summary>
        /// <param name="Parametro"></param>
        /// <returns></returns>
        public async Task<decimal> ConsultarParametro(string Parametro)
        {
            try
            {
                var resultado = (from p in DBContext.Parametros
                                 where p.Descripcion == Parametro
                                 select p.Valor).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarDetalleCuenta
        /// </summary>
        /// <param name="NumeroCuenta"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarDetallesCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
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
                                     Contrasena = c.Contrasena,
                                     Estado = c.Estado
                                 }).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// CrearMovimiento
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ActualizarSaldoInicial
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarDebitoDiario
        /// </summary>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<decimal> ConsultarDebitoDiario(int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals("Debito")
                                 && m.Fecha.Date >= DateTime.Now.Date
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarDebitosEstadoCuenta
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<decimal> ConsultarDebitosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals("Debito")
                                 && (m.Fecha.Date >= entrada.FechaInicio.Date && m.Fecha.Date <= entrada.FechaFin.Date)
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarCreditosEstadoCuenta
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<decimal> ConsultarCreditosEstadoCuenta(DtoMovimientoConsultaEstadoCuenta entrada, int IdCuenta)
        {
            try
            {
                var resultado = (from m in DBContext.Movimientos
                                 where m.IdCuenta == IdCuenta
                                 && m.TipoMovimiento.Equals("Credito")
                                 && (m.Fecha.Date >= entrada.FechaInicio.Date && m.Fecha.Date <= entrada.FechaFin.Date)
                                 select m.Valor).SumAsync();
                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarSaldoInicialEstadoCuenta
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ConsultarCuentasCliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
