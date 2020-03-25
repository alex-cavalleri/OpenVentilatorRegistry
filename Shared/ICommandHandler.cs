using MediatR;
using System.Threading.Tasks;

namespace Shared
{
    public interface ICommandHandler<T, R> : IRequestHandler<T, R> where T : ICommand, IRequest<R>
    {
    }
}
