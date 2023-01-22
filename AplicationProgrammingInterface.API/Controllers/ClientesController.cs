using Dominio;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    /// <summary>
    /// Clientes Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServicio IClienteServicio;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="iClienteServicio"></param>
        public ClientesController(IClienteServicio iClienteServicio)
        {
            IClienteServicio = iClienteServicio;
        }

        /// <summary>
        /// Consultar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Detalle Cliente</returns>
        [HttpGet]
        [Route("Consultar/{idCliente:int}")]
        public async Task<IActionResult> ConsultarCliente(int idCliente)
        {
            try
            {
                var response = await IClienteServicio.ConsultarCliente(idCliente);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        /// <summary>
        /// Crear Cliente
        /// </summary>
        /// <param name="ObjClienteCrear">Objeto Cliente Crear</param>
        /// <returns>Identificador Cliente</returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCliente([FromBody] DtoClienteCrear ObjClienteCrear)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IClienteServicio.CrearCliente(ObjClienteCrear);

                return Created($"/{response}", new
                {
                    IdCliente = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        /// <summary>
        /// Modificar Cliente
        /// </summary>
        /// <param name="ObjClienteModificar">Objeto Cliente Modificar</param>
        /// <returns>Identificador Cliente</returns>
        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> ModificarCliente(DtoClienteModificar ObjClienteModificar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IClienteServicio.ModificarCliente(ObjClienteModificar);

                return Ok(new
                {
                    IdCliente = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        /// <summary>
        /// Eliminar Cliente
        /// </summary>
        /// <param name="idCliente">Identificador Cliente</param>
        /// <returns>Identificador Cliente</returns>
        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public async Task<IActionResult> EliminarCliente(int idCliente)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IClienteServicio.EliminarCliente(idCliente);

                return Ok(new
                {
                    IdCliente = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }
    }
}
