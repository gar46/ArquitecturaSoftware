using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TorreDeControl.Modelos;
using System.Collections.Generic;

namespace TorreDeControl.Consultas
{
    public class ObtenerAvionesConsultaManejador : IRequestHandler<ObtenerAvionesConsulta, List<Avion>>
    {
        private readonly List<Avion> _aviones;

        public ObtenerAvionesConsultaManejador(List<Avion> aviones)
        {
            _aviones = aviones;
        }

        public Task<List<Avion>> Handle(ObtenerAvionesConsulta request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_aviones);
        }
    }
}
