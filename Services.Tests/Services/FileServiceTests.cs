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
    public class FileServiceTests
    {

        private readonly IFileRepository _fileRepository;

        public FileServiceTests()
        {
            _fileRepository = Substitute.For<IFileRepository>();

        }

        [Fact]
        public void FileService_GetFromFile_ReturnLength()
        {
            var service = new FileService(_fileRepository);
            _fileRepository.Read().Returns("example");


            Assert.Equal(7, service.GetLength());
        }

        [Fact]
        public void FileService_GetFromFile_ReturnZero()
        {
            var service = new FileService(_fileRepository);
            _fileRepository.Read().Returns(String.Empty);

            Assert.Equal(0, service.GetLength());
        }
    }
}
