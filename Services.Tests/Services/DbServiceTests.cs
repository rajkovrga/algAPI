using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Services.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Services.Tests.Services
{
    public class DbServiceTests
    {
        private IDbRepository<Item> _dbRepository;
        public DbServiceTests()
        {
            _dbRepository = Substitute.For<IDbRepository<Item>>();
            
        }

        [Fact]
        public void DbService_GetFromDb_ReturnLength()
        {
            var service = new DbService(_dbRepository);

            _dbRepository.getFirstElement().Returns<Item>(new Item
            {
                Description = "example"
            });

            Assert.Equal(7, service.GetLength());
        }

        [Fact]
        public void DbService_GetFromDb_ReturnZero()
        {
            var service = new DbService(_dbRepository);

            _dbRepository.getFirstElement().Returns<object>(null);

            Assert.Equal(0, service.GetLength());
        }

    }
}
