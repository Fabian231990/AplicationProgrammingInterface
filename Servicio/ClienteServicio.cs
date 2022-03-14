using Dominio;
using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System;
using System.Threading.Tasks;

namespace Servicio
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio IClienteRepositorio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iClienteRepositorio"></param>
        public ClienteServicio(IClienteRepositorio iClienteRepositorio)
        {
            IClienteRepositorio = iClienteRepositorio;
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
                DtoClienteConsultar ClienteRespuesta = new();
                var ClienteEncontrado = await IClienteRepositorio.ConsultarCliente(idCliente);
                if (ClienteEncontrado == null)
                    throw new Exception ("Cliente no existe");

                ClienteRespuesta.Nombres = ClienteEncontrado.Nombres;
                ClienteRespuesta.Direccion = ClienteEncontrado.Direccion;
                ClienteRespuesta.Telefono = ClienteEncontrado.Telefono;
                ClienteRespuesta.Contrasena = ClienteEncontrado.Contrasena;
                ClienteRespuesta.Estado = ClienteEncontrado.Estado;

                return ClienteRespuesta;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// CrearCliente
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<int> CrearCliente(DtoClienteCrear entrada)
        {
            try
            {
                ECliente nuevo = new()
                {
                    IdPersona = entrada.IdPersona,
                    Contrasena = entrada.Contrasena
                };

                return await IClienteRepositorio.CrearCliente(nuevo);
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
        /// <returns></returns>
        public async Task<int> ModificarCliente(DtoClienteModificar ClienteModificar)
        {
            try
            {
                int IdPersona = await IClienteRepositorio.ObtenerIdPersona(ClienteModificar.IdCliente);

                if (IdPersona == 0)
                    throw new Exception("Cliente no existe");

                return await IClienteRepositorio.ModificarCliente(ClienteModificar, IdPersona);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// EliminarCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<int> EliminarCliente(int idCliente)
        {
            try
            {
                int IdPersona = await IClienteRepositorio.ObtenerIdPersona(idCliente);

                if (IdPersona == 0)
                    throw new Exception("Cliente no existe");

                return await IClienteRepositorio.EliminarCliente(idCliente, IdPersona);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
