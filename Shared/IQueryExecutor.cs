using System.Threading.Tasks;

namespace Shared
{
    public interface IQueryExecutor<T, R> where T : IQuery
    {
        Task<R> Execute(T query);
    }
}