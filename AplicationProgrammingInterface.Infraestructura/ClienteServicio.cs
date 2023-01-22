using Dominio;
using Dto.Entidades;
using Dto.Entrada;
using Dto.General;
using Dto.Salida;
using System;
using System.Threading.Tasks;

namespace Servicio
{
    /// <summary>
    /// Cliente Servicio
    /// </summary>
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio IClienteRepositorio;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="iClienteRepositorio">Interface Cliente Repositorio</param>
        public ClienteServicio(IClienteRepositorio iClienteRepositorio)
        {
            IClienteRepositorio = iClienteRepositorio;
        }

        /// <summary>
        /// Consultar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Retorna informacion del Cliente</returns>
        public async Task<DtoClienteConsultar> ConsultarCliente(int idCliente)
        {
            try
            {
                DtoClienteConsultar ClienteRespuesta = new();
                var ClienteEncontrado = await IClienteRepositorio.ConsultarCliente(idCliente);
                if (ClienteEncontrado == null)
                    throw new Exception(Constantes.CLIENTE_NO_EXISTE);

                ClienteRespuesta.Nombres = ClienteEncontrado.Nombres;
                ClienteRespuesta.Direccion = ClienteEncontrado.Direccion;
                ClienteRespuesta.Telefono = ClienteEncontrado.Telefono;
                ClienteRespuesta.Contrasenia = ClienteEncontrado.Contrasenia;
                ClienteRespuesta.Estado = ClienteEncontrado.Estado;

                return ClienteRespuesta;
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
        /// <param name="ObjClienteCrear">Objeto Cliente Crear</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> CrearCliente(DtoClienteCrear ObjClienteCrear)
        {
            try
            {
                ECliente nuevo = new()
                {
                    IdPersona = ObjClienteCrear.IdPersona,
                    Contrasenia = ObjClienteCrear.Contrasena
                };

                return await IClienteRepositorio.CrearCliente(nuevo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Modificar Cliente
        /// </summary>
        /// <param name="ObjClienteModificar">Objeto Cliente Modificar</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> ModificarCliente(DtoClienteModificar ObjClienteModificar)
        {
            try
            {
                int IdPersona = await IClienteRepositorio.ObtenerIdPersona(ObjClienteModificar.IdCliente);

                if (IdPersona == 0)
                    throw new Exception(Constantes.CLIENTE_NO_EXISTE);

                return await IClienteRepositorio.ModificarCliente(ObjClienteModificar, IdPersona);
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
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        public async Task<int> EliminarCliente(int idCliente)
        {
            try
            {
                int IdPersona = await IClienteRepositorio.ObtenerIdPersona(idCliente);

                if (IdPersona == 0)
                    throw new Exception(Constantes.CLIENTE_NO_EXISTE);

                return await IClienteRepositorio.EliminarCliente(idCliente, IdPersona);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
