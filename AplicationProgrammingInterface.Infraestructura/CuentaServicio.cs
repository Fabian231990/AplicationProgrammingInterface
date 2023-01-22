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
    /// Cuenta Servicio
    /// </summary>
    public class CuentaServicio : ICuentaServicio
    {
        private readonly ICuentaRepositorio ICuentaRepositorio;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="iCuentaRepositorio">Interface Cuenta Repositorio</param>
        public CuentaServicio(ICuentaRepositorio iCuentaRepositorio)
        {
            ICuentaRepositorio = iCuentaRepositorio;
        }

        /// <summary>
        /// Consultar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Retorna detalle de la Cuenta</returns>
        public async Task<DtoCuentaConsultar> ConsultarCuenta(int IdCuenta)
        {
            try
            {
                DtoCuentaConsultar resultado = new();

                var respuesta = await ICuentaRepositorio.ConsultarCuenta(IdCuenta);

                if (respuesta == null)
                    throw new Exception(Constantes.CUENTA_NO_EXISTE);

                resultado.NumeroCuenta = respuesta.NumeroCuenta;
                resultado.Tipo = respuesta.Tipo;
                resultado.SaldoInicial = respuesta.SaldoInicial;
                resultado.Estado = respuesta.Estado;
                resultado.Cliente = respuesta.Cliente;

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crear Cuenta
        /// </summary>
        /// <param name="ObjCuentaCrear">Objeto Cuenta Crear</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> CrearCuenta(DtoCuentaCrear ObjCuentaCrear)
        {
            try
            {
                ECuenta nueva = new()
                {
                    IdCliente = ObjCuentaCrear.IdCliente,
                    NumeroCuenta = ObjCuentaCrear.NumeroCuenta,
                    TipoCuenta = ObjCuentaCrear.TipoCuenta,
                    SaldoInicial = ObjCuentaCrear.SaldoInicial
                };

                return await ICuentaRepositorio.CrearCuenta(nueva);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Modificar Cuenta
        /// </summary>
        /// <param name="ObjCuentaModificar">Objeto Cuenta Modificar</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> ModificarCuenta(DtoCuentaModificar ObjCuentaModificar)
        {
            try
            {
                var DetalleCuenta = await ICuentaRepositorio.ObtenerDetalleCuenta(ObjCuentaModificar.IdCuenta);

                if (DetalleCuenta == null)
                    throw new Exception(Constantes.CUENTA_NO_EXISTE);

                if (DetalleCuenta.IdCliente != ObjCuentaModificar.IdCliente)
                    throw new Exception(Constantes.CUENTA_NO_CLIENTE);

                return await ICuentaRepositorio.ModificarCuenta(ObjCuentaModificar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Eliminar Cuenta
        /// </summary>
        /// <param name="IdCuenta">Identificador Cuenta</param>
        /// <returns>Identificador Cuenta</returns>
        public async Task<int> EliminarCuenta(int IdCuenta)
        {
            try
            {
                var DetalleCuenta = await ICuentaRepositorio.ObtenerDetalleCuenta(IdCuenta);

                if (DetalleCuenta == null)
                    throw new Exception(Constantes.CUENTA_NO_EXISTE);

                return await ICuentaRepositorio.EliminarCuenta(IdCuenta, DetalleCuenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception", ex.Message);
                throw;
            }
        }
    }
}
