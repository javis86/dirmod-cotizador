using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dirmod.Cotizador.Application.Core;
using Dirmod.Cotizador.Application.Interfaces;
using Dirmod.Cotizador.Application.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dirmod.Cotizador.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotizacionController : ControllerBase
    {
        private readonly ILogger<CotizacionController> _logger;
        private readonly ICotizadorExternoService cotizadorExternoService;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizadorExternoService cotizadorExternoService)
        {
            _logger = logger;
            this.cotizadorExternoService = cotizadorExternoService;
        }

        [HttpGet("{moneda}")]
        public async Task<ActionResult<Task<Cotizacion>>> GetAsync(string moneda)
        {
            try
            {
                IStrategy estrategia = ObtenerEstrategiaDeConversion(moneda);
                return Ok(await estrategia.Execute());                
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IStrategy ObtenerEstrategiaDeConversion(string moneda)
        {
            switch (moneda)
            {
                case "dolar":
                    return new DolarStrategy(this.cotizadorExternoService);
                case "euro":
                    return new EuroStrategy(this.cotizadorExternoService);
                case "real":
                    return new RealStrategy(this.cotizadorExternoService);
                default:
                    throw new Exception("No se ha encontrado la moneda");
            }
        }
    }
}
