using MediatR;

namespace TorreDeControl.Comandos
{
    public record AterrizarAvionComando(string AvionId) : IRequest;
}
