using Dominio;
using Dto;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServicio IClienteServicio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iClienteServicio"></param>
        public ClientesController(IClienteServicio iClienteServicio)
        {
            IClienteServicio = iClienteServicio;
        }

        /// <summary>
        /// ConsultarCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
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
        /// CrearCliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCliente([FromBody] DtoClienteCrear request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IClienteServicio.CrearCliente(request);

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
        /// ModificarCliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> ModificarCliente(DtoClienteModificar request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IClienteServicio.ModificarCliente(request);

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
        /// EliminarCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
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
