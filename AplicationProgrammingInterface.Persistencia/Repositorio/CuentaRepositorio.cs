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
    /// Cuenta Repositorio
    /// </summary>
    public class CuentaRepositorio : ICuentaRepositorio
    {
        private readonly BDAppInterfaceContext DBContext;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="dBContext"></param>
        public CuentaRepositorio(BDAppInterfaceContext dBContext)
        {
            DBContext = dBContext;
        }

        /// <summary>
        /// Consultar Cuenta
        /// </summary>
        /// <param name="idCuenta">Identificador Cuenta</param>
        /// <returns>Detalle Cuenta</returns>
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
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crear Cuenta
        /// </summary>
        /// <param name="ObjEntidadCuenta">Objeto Entidada Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> CrearCuenta(ECuenta ObjEntidadCuenta)
        {
            try
            {
                Cuenta nueva = new()
                {
                    IdCliente = ObjEntidadCuenta.IdCliente,
                    NumeroCuenta = ObjEntidadCuenta.NumeroCuenta,
                    TipoCuenta = ObjEntidadCuenta.TipoCuenta,
                    SaldoInicial = ObjEntidadCuenta.SaldoInicial,
                    Estado = true
                };

                var resultado = (from c in DBContext.Cuenta
                                 where c.NumeroCuenta == nueva.NumeroCuenta && c.Estado == true
                                 select c).SingleOrDefaultAsync();

                if (resultado.Result != null)
                    throw new Exception(Constantes.CUENTA_EXISTE);

                await DBContext.Set<Cuenta>().AddAsync(nueva);
                await DBContext.SaveChangesAsync();

                return nueva.IdCuenta;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtener Detalle Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Objeto Entidada Cuenta</returns>
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
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Modificar Cuenta
        /// </summary>
        /// <param name="ObjCuentaModificar">Objeto Cuenta Modificar</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> ModificarCuenta(DtoCuentaModificar ObjCuentaModificar)
        {
            try
            {
                Cuenta modificarCuenta = new()
                {
                    IdCuenta = ObjCuentaModificar.IdCuenta,
                    IdCliente = ObjCuentaModificar.IdCliente,
                    NumeroCuenta = ObjCuentaModificar.NumeroCuenta,
                    TipoCuenta = ObjCuentaModificar.TipoCuenta,
                    SaldoInicial = ObjCuentaModificar.SaldoInicial,
                    Estado = true
                };
                DBContext.Set<Cuenta>().Attach(modificarCuenta);
                DBContext.Entry(modificarCuenta).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return modificarCuenta.IdCuenta;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <param name="ObjEntidadCuenta">Objeto Entidad Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> EliminarCuenta(int IdCuenta, ECuenta ObjEntidadCuenta)
        {
            try
            {
                Cuenta eliminarCuenta = new()
                {
                    IdCuenta = IdCuenta,
                    IdCliente = ObjEntidadCuenta.IdCliente,
                    NumeroCuenta = ObjEntidadCuenta.NumeroCuenta,
                    TipoCuenta = ObjEntidadCuenta.TipoCuenta,
                    SaldoInicial = ObjEntidadCuenta.SaldoInicial,
                    Estado = false
                };

                DBContext.Set<Cuenta>().Attach(eliminarCuenta);
                DBContext.Entry(eliminarCuenta).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return eliminarCuenta.IdCuenta;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
