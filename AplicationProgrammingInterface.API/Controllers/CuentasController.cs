using Dominio;
using Dto.Entrada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AplicationProgrammingInterface.Controllers
{
    /// <summary>
    /// Cuentas Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaServicio ICuentaServicio;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="iCuentaServicio"></param>
        public CuentasController(ICuentaServicio iCuentaServicio)
        {
            ICuentaServicio = iCuentaServicio;
        }

        /// <summary>
        /// Consultar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Detalle Cuenta</returns>

        [HttpGet]
        [Route("Consultar/{idCuenta:int}")]
        public async Task<IActionResult> ConsultarCuenta(int IdCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.ConsultarCuenta(IdCuenta);

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
        /// Crear Cuenta
        /// </summary>
        /// <param name="ObjCuentaCrear">Objeto Cuenta Crear</param>
        /// <returns>Identificador Cuenta</returns>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCuenta([FromBody] DtoCuentaCrear ObjCuentaCrear)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.CrearCuenta(ObjCuentaCrear);

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
        /// Modificar Cuenta
        /// </summary>
        /// <param name="ObjCuentaModificar">Objeto Cuenta Modificar</param>
        /// <returns>Identificador Cuenta</returns>
        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> ModificarCuenta(DtoCuentaModificar ObjCuentaModificar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.ModificarCuenta(ObjCuentaModificar);

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
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        [HttpDelete]
        [Route("Eliminar/{idCuenta:int}")]
        public async Task<IActionResult> EliminarCuenta(int IdCuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await ICuentaServicio.EliminarCuenta(IdCuenta);

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
