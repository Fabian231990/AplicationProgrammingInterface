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
    /// Cliente Repositorio
    /// </summary>
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BDAppInterfaceContext DBContext;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="dBContext"></param>
        public ClienteRepositorio(BDAppInterfaceContext dBContext)
        {
            DBContext = dBContext;
        }

        /// <summary>
        /// Consultar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle del Cliente</returns>
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
        /// Crear Cliente
        /// </summary>
        /// <param name="ObjEntidadCliente">Objeto Entidad Cliente</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> CrearCliente(ECliente ObjEntidadCliente)
        {
            try
            {
                Cliente nuevo = new()
                {
                    IdPersona = ObjEntidadCliente.IdPersona,
                    Contrasena = ObjEntidadCliente.Contrasenia,
                    Estado = true
                };

                var resultado = (from c in DBContext.Clientes
                                 where c.IdPersona == nuevo.IdPersona && c.Estado == true
                                 select c).SingleOrDefaultAsync();

                if (resultado.Result != null)
                    throw new Exception(Constantes.CLIENTE_EXISTE);

                await DBContext.Set<Cliente>().AddAsync(nuevo);
                await DBContext.SaveChangesAsync();

                return nuevo.IdCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtener Identificador Persona
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> ObtenerIdPersona(int idCliente)
        {
            try
            {
                var resultado = (from c in DBContext.Clientes
                                 where c.IdCliente == idCliente && c.Estado == true
                                 select c.IdPersona).SingleOrDefaultAsync();

                return await resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Cliente Modificar
        /// </summary>
        /// <param name="ObjClienteModificar">Objeto Cliente Modificar</param>
        /// <param name="IdPersona">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> ModificarCliente(DtoClienteModificar ObjClienteModificar, int IdPersona)
        {
            try
            {
                Cliente modificarCliente = new()
                {
                    IdCliente = ObjClienteModificar.IdCliente,
                    IdPersona = IdPersona,
                    Contrasena = ObjClienteModificar.Contrasenia,
                    Estado = true
                };
                DBContext.Set<Cliente>().Attach(modificarCliente);
                DBContext.Entry(modificarCliente).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                Persona modificarPersona = new()
                {
                    IdPersona = IdPersona,
                    Nombre = ObjClienteModificar.Nombres,
                    Genero = ObjClienteModificar.Genero,
                    Edad = ObjClienteModificar.Edad,
                    Identificacion = ObjClienteModificar.Identificacion,
                    Direccion = ObjClienteModificar.Direccion,
                    Telefono = ObjClienteModificar.Telefono,
                    Estado = true,
                };

                DBContext.Set<Persona>().Attach(modificarPersona);
                DBContext.Entry(modificarPersona).State = EntityState.Modified;
                await DBContext.SaveChangesAsync();

                return modificarCliente.IdCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="IdCliente">Identificador Cliente</param>
        /// <param name="IdPersona">Identificador Persona</param>
        /// <returns>Identificador Cliente</returns>
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
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
