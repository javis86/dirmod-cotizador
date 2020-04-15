using System.Threading.Tasks;
using Dirmod.Cotizador.Application.Core;

namespace Dirmod.Cotizador.Application.Interfaces
{
    public interface ICotizadorExternoService
    {
        Task<Cotizacion> ObtenerCotizacion(string codigoMonedaOrigen, string codigoMonedaDestino);
    }
}