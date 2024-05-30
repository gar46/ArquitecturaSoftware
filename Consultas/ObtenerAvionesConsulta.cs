using MediatR;
using TorreDeControl.Modelos;
using System.Collections.Generic;
using System;

namespace TorreDeControl.Consultas
{
    public record ObtenerAvionesConsulta : IRequest<List<Avion>>;
}
