using Dominio;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    /// <summary>
    /// Movimientos Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoServicio IMovimientoServicio;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="iMovimientoServicio"></param>
        public MovimientosController(IMovimientoServicio iMovimientoServicio)
        {
            IMovimientoServicio = iMovimientoServicio;
        }

        /// <summary>
        /// Registrar Movimiento
        /// </summary>
        /// <param name="ObjMovimientoRealizar">Objeto Movimiento Realizar</param>
        /// <returns>Respuesta del Movimiento</returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearMovimiento([FromBody] DtoMovimientoRealizar ObjMovimientoRealizar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IMovimientoServicio.RegistrarMovimiento(ObjMovimientoRealizar);

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
        /// Estado Cuenta Movimiento
        /// </summary>
        /// <param name="ObjMovimientoConsultaEstadoCuenta">Objeto Movimiento Consulta Estado Cuenta</param>
        /// <returns>Consultar los Movimientos del Estado de Cuenta</returns>
        [HttpPost]
        [Route("EstadoCuentas")]
        public async Task<IActionResult> EstadoCuentasMovimiento([FromBody] DtoMovimientoConsultaEstadoCuenta ObjMovimientoConsultaEstadoCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await IMovimientoServicio.EstadoCuentaMovimiento(ObjMovimientoConsultaEstadoCuenta);

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
