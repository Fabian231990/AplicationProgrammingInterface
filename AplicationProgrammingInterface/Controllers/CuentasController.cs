using Dominio;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaServicio ICuentaServicio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iCuentaServicio"></param>
        public CuentasController(ICuentaServicio iCuentaServicio)
        {
            ICuentaServicio = iCuentaServicio;
        }

        /// <summary>
        /// ConsultarCuenta
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("Consultar/{idCuenta:int}")]
        public async Task<IActionResult> ConsultarCuenta(int idCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.ConsultarCuenta(idCuenta);

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
        /// CrearCuenta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCuenta([FromBody] DtoCuentaCrear request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.CrearCuenta(request);

                return Created($"/{response}", new
                {
                    IdCuenta = response
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
        /// ModificarCuenta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> ModificarCuenta(DtoCuentaModificar request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.ModificarCuenta(request);

                return Ok(new
                {
                    IdCuenta = response
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
        /// EliminarCuenta
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar/{idCuenta:int}")]
        public async Task<IActionResult> EliminarCuenta(int idCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.EliminarCuenta(idCuenta);

                return Ok(new
                {
                    IdCuenta = response
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
