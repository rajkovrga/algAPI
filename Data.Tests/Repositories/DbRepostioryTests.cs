using Alg.Core.Models;
using Alg.Data;
using Alg.Data.Interfaces;
using Alg.Data.Repositories;
using Data.Tests.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Data.Tests.Repositories
{
    public class DbRepostioryTests
    {
        private TestService _testService;
        private DataContext _dataContext;
        public DbRepostioryTests()
        {
            _testService = new TestService();
            _dataContext = _testService.MigrateDb("Db1");
        }

        [Fact]
        public void DbRepository_NothingPass_ReturnItem()
        {
            var repos = new DbRepository(_dataContext);


            _dataContext.Database.Migrate();

            Item item = new Item
            {
                Description = "example"
            };
            _dataContext.Items.Add(item);
            _dataContext.SaveChanges();

            var row = repos.getFirstElement();

            Assert.Equal("example", row.Description);
        }
    }
}
