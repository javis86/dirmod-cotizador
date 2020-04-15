using System.Threading.Tasks;
using Dirmod.Cotizador.Application.Interfaces;
using Dirmod.Cotizador.Application.Interfaces.Base;

namespace Dirmod.Cotizador.Application.Core
{
    public class RealStrategy : IStrategy
    {
        public ICotizadorExternoService CotizadorService { get; }
        private const string CODIGO_MONEDA_ORIGEN = "BRL";
        private const string CODIGO_MONEDA_DESTINO = "ARS";
        private const string CODIGO_INTERNO = "real";

        public RealStrategy(ICotizadorExternoService cotizadorService)
        {
            CotizadorService = cotizadorService;
        }


        public async Task<Cotizacion> Execute()
        {
            Cotizacion cotizacion = await this.CotizadorService.ObtenerCotizacion(CODIGO_MONEDA_ORIGEN, CODIGO_MONEDA_DESTINO);
            cotizacion.Moneda = CODIGO_INTERNO;

            return cotizacion;
        }

    }
}