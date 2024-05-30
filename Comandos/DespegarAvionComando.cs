using MediatR;

namespace TorreDeControl.Comandos
{
    public record DespegarAvionComando(string AvionId) : IRequest;
}
