using System.Threading.Tasks;
using Enterprise.Models;
using Enterprise.Repository.Interfaces;

namespace Enterprise.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly Context.Context context;

        public Repository(Context.Context context)
        {
            this.context = context;
        }
        
        public async Task<T> Get()
        {
            // Imagine we run EF and this is proper context call :)
            return await Task.FromResult(this.context.TaxConfig as T);
        }
    }
}