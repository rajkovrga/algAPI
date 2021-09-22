using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Core.Services;
using System;

namespace Alg.Services.Services
{
    public class DbService : IDbService
    {
        private readonly IDbRepository<Item> _dbRepository;

        public DbService(IDbRepository<Item> dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public int GetLength(string desc = "")
        {
            var r = _dbRepository.getFirstElement();

            if (r == null)
                return 0;

            return r.Description.Length;
        }
    }
}
