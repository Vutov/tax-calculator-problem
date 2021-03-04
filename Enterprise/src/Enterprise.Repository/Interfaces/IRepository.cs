using System.Threading.Tasks;

namespace Enterprise.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Get();
    }
}