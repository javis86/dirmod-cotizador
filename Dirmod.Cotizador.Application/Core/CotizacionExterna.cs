using System;

namespace Dirmod.Cotizador.Application.Core
{
    public class CotizacionExterna
    {
        public DateTime updated { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public double value { get; set; }
        public double quantity { get; set; }
        public double amount { get; set; }
    }
}