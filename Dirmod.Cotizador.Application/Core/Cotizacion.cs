namespace Dirmod.Cotizador.Application.Core
{
    public class Cotizacion
    {
        public string Moneda { get; set; }
        public double Precio { get; set; }
        
        public Cotizacion(){}
        public Cotizacion(string moneda, double precio)
        {
            this.Moneda = moneda;
            this.Precio = precio;
        }
    }
}