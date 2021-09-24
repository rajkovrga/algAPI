using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Core.Services;
using Alg.Data.Repositories;
using Alg.Services.Factories;
using Alg.Services.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Services.Tests.Factories
{
    public class DataFactoryTests
    {
        private IDbRepository<Item> _dbRepository;
        private IFileRepository _fileRepository;

        public DataFactoryTests()
        {
            _dbRepository = Substitute.For<IDbRepository<Item>>();
            _fileRepository = Substitute.For<IFileRepository>();
        }

        [Fact]
        public void GetInstance_Pass2_ReturnDbService()
        {
            var factory = new DataFactory(_fileRepository, _dbRepository);
            Assert.IsAssignableFrom<DbService>(factory.GetInstance(2));
        }
        [Fact]
        public void GetInstance_Pass3_ReturnEntryService()
        {
            var factory = new DataFactory(_fileRepository, _dbRepository);
            Assert.IsAssignableFrom<EntryService>(factory.GetInstance(3));
        }
        [Fact]
        public void GetInstance_Pass1_ReturnFileService()
        {
            var factory = new DataFactory(_fileRepository, _dbRepository);
            Assert.IsAssignableFrom<FileService>(factory.GetInstance(1));
        }

        [Fact]
        public void GetInstance_Pass10_ReturnException()
        {
            var factory = new DataFactory(_fileRepository, _dbRepository);
            Assert.Throws<ArgumentException>(() => factory.GetInstance(10));
        }

    }
}
