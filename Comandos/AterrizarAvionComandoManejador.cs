using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TorreDeControl.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace TorreDeControl.Comandos
{
    public class AterrizarAvionComandoManejador : IRequestHandler<AterrizarAvionComando, Unit>
    {
        private readonly List<Avion> _aviones;

        public AterrizarAvionComandoManejador(List<Avion> aviones)
        {
            _aviones = aviones;
        }

        public Task<Unit> Handle(AterrizarAvionComando request, CancellationToken cancellationToken)
        {
            var avion = _aviones.FirstOrDefault(a => a.Id == request.AvionId);
            if (avion != null)
            {
                avion.Estado = "Aterrizado";
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
