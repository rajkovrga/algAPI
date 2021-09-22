using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Data.Interfaces;
using System.Linq;

namespace Alg.Data.Repositories
{
    public class DbRepository : IDbRepository<Item>
    {
        private readonly IDataContext _dataContext;

        public DbRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Item getFirstElement()
        {
            var r = _dataContext.Items.FirstOrDefault();

            return new Item { 
                Description = r.Description,
                Id = r.Id
            };
        }
    }
}
