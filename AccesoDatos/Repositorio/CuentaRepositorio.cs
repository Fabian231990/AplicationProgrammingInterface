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
    public class CuentaRepositorio : ICuentaRepositorio
    {
        private readonly BDAppInterfaceContext DBContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public CuentaRepositorio(BDAppInterfaceContext dBContext)
        {
            DBContext = dBContext;
        }

        /// <summary>
        /// ConsultarCuenta
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        public async Task<DtoCuentaConsultar> ConsultarCuenta(int idCuenta)
        {
            try
            {
                var resultado = (from c in DBContext.Cuenta
                                 join cl in DBContext.Clientes on c.IdCliente equals cl.IdCliente
                                 join p in DBContext.Personas on cl.IdPersona equals p.IdPersona
                                 where c.IdCuenta == idCuenta && c.Estado == true
                                 select new DtoCuentaConsultar
                                 {
                                     NumeroCuenta = c.NumeroCuenta,
                                     Tipo = c.TipoCuenta,
                                     SaldoInicial = c.SaldoInicial,
                                     Estado = c.Estado,
                                     Cliente = p.Nombre

                                 }).SingleOrDefaultAsync();
                return await resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// CrearCuenta
        /// </summary>
        /// <param name="CuentaNueva"></param>
        /// <returns></returns>
        public async Task<int> CrearCuenta(ECuenta CuentaNueva)
        {
            try
            {
                Cuenta nueva = new()
                {
                    IdCliente = CuentaNueva.IdCliente,
                    NumeroCuenta = CuentaNueva.NumeroCuenta,
                    TipoCuenta = CuentaNueva.TipoCuenta,
                    SaldoInicial = CuentaNueva.SaldoInicial,
                    Estado = true
                };

                var resultado = (from c in DBContext.Cuenta
                                 where c.NumeroCuenta == nueva.NumeroCuenta && c.Estado == true
                                 select c).SingleOrDefaultAsync();

                if (resultado.Result != null)
                    throw new Exception("Cuenta existe");

                await DBContext.Set<Cuenta>().AddAsync(nueva);
                await DBContext.SaveChangesAsync();

                return nueva.IdCuenta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ObtenerDetalleCuenta
        /// </summary>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<ECuenta> ObtenerDetalleCuenta(int IdCuenta)
        {
            try
            {
                var resultado = (from c in DBContext.Cuenta
                                 where c.IdCuenta == IdCuenta && c.Estado == true
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
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ModificarCuenta
        /// </summary>
        /// <param name="CuentaModificar"></param>
        /// <returns></returns>
        public async Task<int> ModificarCuenta(DtoCuentaModificar CuentaModificar)
        {
            try
            {
                Cuenta modificarCuenta = new()
                {
                    IdCuenta = CuentaModificar.IdCuenta,
                    IdCliente = CuentaModificar.IdCliente,
                    NumeroCuenta = CuentaModificar.NumeroCuenta,
                    TipoCuenta = CuentaModificar.TipoCuenta,
                    SaldoInicial = CuentaModificar.SaldoInicial,
                    Estado = true
                };
                DBContext.Set<Cuenta>().Attach(modificarCuenta);
                DBContext.Entry(modificarCuenta).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return modificarCuenta.IdCuenta;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EliminarCuenta
        /// </summary>
        /// <param name="IdCuenta"></param>
        /// <param name="DetalleCuenta"></param>
        /// <returns></returns>
        public async Task<int> EliminarCuenta(int IdCuenta, ECuenta DetalleCuenta)
        {
            try
            {
                Cuenta eliminarCuenta = new()
                {
                    IdCuenta = IdCuenta,
                    IdCliente = DetalleCuenta.IdCliente,
                    NumeroCuenta = DetalleCuenta.NumeroCuenta,
                    TipoCuenta = DetalleCuenta.TipoCuenta,
                    SaldoInicial = DetalleCuenta.SaldoInicial,
                    Estado = false
                };

                DBContext.Set<Cuenta>().Attach(eliminarCuenta);
                DBContext.Entry(eliminarCuenta).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return eliminarCuenta.IdCuenta;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
