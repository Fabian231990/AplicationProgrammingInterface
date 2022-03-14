using Dominio;
using Dto.Entidades;
using Dto.Entrada;
using Dto.Salida;
using System;
using System.Threading.Tasks;

namespace Servicio
{
    public class CuentaServicio : ICuentaServicio
    {
        private readonly ICuentaRepositorio ICuentaRepositorio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iCuentaRepositorio"></param>
        public CuentaServicio(ICuentaRepositorio iCuentaRepositorio)
        {
            ICuentaRepositorio = iCuentaRepositorio;
        }

        /// <summary>
        /// ConsultarCuenta
        /// </summary>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<DtoCuentaConsultar> ConsultarCuenta(int IdCuenta)
        {
            try
            {
                DtoCuentaConsultar resultado = new();

                var respuesta = await ICuentaRepositorio.ConsultarCuenta(IdCuenta);

                if (respuesta == null)
                    throw new Exception("Cuenta no existe");

                resultado.NumeroCuenta = respuesta.NumeroCuenta;
                resultado.Tipo = respuesta.Tipo;
                resultado.SaldoInicial = respuesta.SaldoInicial;
                resultado.Estado = respuesta.Estado;
                resultado.Cliente = respuesta.Cliente;

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// CrearCuenta
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<int> CrearCuenta(DtoCuentaCrear entrada)
        {
            try
            {
                ECuenta nueva = new()
                {
                    IdCliente = entrada.IdCliente,
                    NumeroCuenta = entrada.NumeroCuenta,
                    TipoCuenta = entrada.TipoCuenta,
                    SaldoInicial = entrada.SaldoInicial
                };

                return await ICuentaRepositorio.CrearCuenta(nueva);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ModificarCuenta
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<int> ModificarCuenta(DtoCuentaModificar entrada)
        {
            try
            {
                var DetalleCuenta = await ICuentaRepositorio.ObtenerDetalleCuenta(entrada.IdCuenta);

                if (DetalleCuenta == null)
                    throw new Exception("Cuenta no existe");

                if (DetalleCuenta.IdCliente != entrada.IdCliente)
                    throw new Exception("Cuenta no pertenece al cliente");

                return await ICuentaRepositorio.ModificarCuenta(entrada);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// EliminarCuenta
        /// </summary>
        /// <param name="IdCuenta"></param>
        /// <returns></returns>
        public async Task<int> EliminarCuenta(int IdCuenta)
        {
            try
            {
                var DetalleCuenta = await ICuentaRepositorio.ObtenerDetalleCuenta(IdCuenta);

                if (DetalleCuenta == null)
                    throw new Exception("Cuenta no existe");

                return await ICuentaRepositorio.EliminarCuenta(IdCuenta, DetalleCuenta);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
