using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Dirmod.Cotizador.Application.Core;
using Dirmod.Cotizador.Application.Interfaces;

namespace Dirmod.Cotizador.Application.Services
{
    public class CotizadorExternoService : ICotizadorExternoService
    {
        private const string URL = "https://api.cambio.today/v1/quotes/";
        private const string KEY = "4250|d10wdQi8tqXY^gMYv5HM*2O9AqcTGjUV";
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public CotizadorExternoService(IHttpClientFactory clientFactory, IMapper mapper)
        {
            this._clientFactory = clientFactory;
            this._mapper = mapper;
        }

        public async Task<Cotizacion> ObtenerCotizacion(string codigoMonedaOrigen, string codigoMonedaDestino)
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
                                                 $"{ URL }/{ codigoMonedaOrigen }/{ codigoMonedaDestino }/json?key={ KEY }");

            var client = _clientFactory.CreateClient();
            
            CotizacionExternaResponse respuesta;

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                respuesta = await JsonSerializer.DeserializeAsync<CotizacionExternaResponse>(responseStream);
            }
            else
            {
                throw new Exception("Error al obtener cotización externa");
            }

            return _mapper.Map<Cotizacion>(respuesta.result);
        }
    }
}