using Dirmod.Cotizador.Application.Interfaces.Base;

namespace Dirmod.Cotizador.Application.Core.Base
{
    public class Context
    {
        IStrategy strategy;

        // Constructor
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Execute()
        {
            strategy.Execute();
        }
    }
}