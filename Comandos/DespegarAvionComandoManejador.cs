using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TorreDeControl.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace TorreDeControl.Comandos
{
    public class DespegarAvionComandoManejador : IRequestHandler<DespegarAvionComando, Unit>
    {
        private readonly List<Avion> _aviones;

        public DespegarAvionComandoManejador(List<Avion> aviones)
        {
            _aviones = aviones;
        }

        public Task<Unit> Handle(DespegarAvionComando request, CancellationToken cancellationToken)
        {
            var avion = _aviones.FirstOrDefault(a => a.Id == request.AvionId);
            if (avion != null)
            {
                avion.Estado = "EnVuelo";
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
