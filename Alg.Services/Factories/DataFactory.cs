using Alg.Core;
using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Core.Services;
using Alg.Data.Repositories;
using Alg.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg.Services.Factories
{
    public class DataFactory
    {
        private readonly IFileRepository _fileRepository;
        private readonly IDbRepository<Item> _dbRepository;

        public DataFactory(IFileRepository fileRepository, IDbRepository<Item> dbRepository)
        {
            _fileRepository = fileRepository;
            _dbRepository = dbRepository;
        }

        public IDataService GetInstance(int key)
        {
            switch ((key))
            {
                case 1:
                    return new FileService(_fileRepository);
                case 2:
                    return new DbService(_dbRepository);
                case 3:
                    return new EntryService();
                default:
                    throw new ArgumentException();
            }
        }

    }
}
