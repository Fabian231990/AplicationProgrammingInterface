using Dominio;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoServicio IMovimientoServicio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iMovimientoServicio"></param>
        public MovimientosController(IMovimientoServicio iMovimientoServicio)
        {
            IMovimientoServicio = iMovimientoServicio;
        }

        /// <summary>
        /// CrearMovimiento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearMovimiento ([FromBody] DtoMovimientoRealizar request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IMovimientoServicio.RegistrarMovimiento(request);

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
        /// EstadoCuentasMovimiento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EstadoCuentas")]
        public async Task<IActionResult> EstadoCuentasMovimiento([FromBody] DtoMovimientoConsultaEstadoCuenta request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IMovimientoServicio.EstadoCuentaMovimiento(request);

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
    }
}
