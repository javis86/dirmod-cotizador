using System.Threading.Tasks;
using Dirmod.Cotizador.Application.Core;

namespace Dirmod.Cotizador.Application.Interfaces.Base
{
    public interface IStrategy
    {
        Task<Cotizacion> Execute();
    }    
}
