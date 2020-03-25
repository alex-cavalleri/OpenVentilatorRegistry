using MediatR;
using System.Threading.Tasks;

namespace Shared
{
    public interface IQueryHandler<T, R> : IRequestHandler<T,R> where T : IQuery, IRequest<R>
    {
    }
}
