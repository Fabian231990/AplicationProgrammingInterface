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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BDAppInterfaceContext DBContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public ClienteRepositorio(BDAppInterfaceContext dBContext)
        {
            DBContext = dBContext;
        }

        /// <summary>
        /// ConsultarCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<DtoClienteConsultar> ConsultarCliente(int idCliente)
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
        /// CrearCliente
        /// </summary>
        /// <param name="ClienteNuevo"></param>
        /// <returns></returns>
        public async Task<int> CrearCliente(ECliente ClienteNuevo)
        {
            try
            {
                Cliente nuevo = new()
                {
                    IdPersona = ClienteNuevo.IdPersona,
                    Contrasena = ClienteNuevo.Contrasena,
                    Estado = true
                };

                var resultado = (from c in DBContext.Clientes
                                 where c.IdPersona == nuevo.IdPersona && c.Estado == true
                                 select c).SingleOrDefaultAsync();

                if (resultado.Result != null)
                    throw new Exception("Cliente existe");

                await DBContext.Set<Cliente>().AddAsync(nuevo);
                await DBContext.SaveChangesAsync();

                return nuevo.IdCliente;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// ObtenerIdPersona
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<int> ObtenerIdPersona(int idCliente)
        {
            try
            {
                var resultado = (from c in DBContext.Clientes
                                 where c.IdCliente == idCliente && c.Estado == true
                                 select c.IdPersona).SingleOrDefaultAsync();

                return await resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ModificarCliente
        /// </summary>
        /// <param name="ClienteModificar"></param>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public async Task<int> ModificarCliente(DtoClienteModificar ClienteModificar, int IdPersona)
        {
            try
            {
                Cliente modificarCliente = new()
                {
                    IdCliente = ClienteModificar.IdCliente,
                    IdPersona = IdPersona,
                    Contrasena = ClienteModificar.Contrasena,
                    Estado = true
                };
                DBContext.Set<Cliente>().Attach(modificarCliente);
                DBContext.Entry(modificarCliente).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                Persona modificarPersona = new()
                {
                    IdPersona = IdPersona,
                    Nombre = ClienteModificar.Nombres,
                    Genero = ClienteModificar.Genero,
                    Edad = ClienteModificar.Edad,
                    Identificacion = ClienteModificar.Identificacion,
                    Direccion = ClienteModificar.Direccion,
                    Telefono = ClienteModificar.Telefono,
                    Estado = true,
                };

                DBContext.Set<Persona>().Attach(modificarPersona);
                DBContext.Entry(modificarPersona).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return modificarCliente.IdCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EliminarCliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public async Task<int> EliminarCliente(int IdCliente, int IdPersona)
        {
            try
            {
                Cliente modificarCliente = new()
                {
                    IdCliente = IdCliente,
                    IdPersona = IdPersona,
                    Contrasena = string.Empty,
                    Estado = false
                };
                DBContext.Set<Cliente>().Attach(modificarCliente);
                DBContext.Entry(modificarCliente).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return modificarCliente.IdCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
