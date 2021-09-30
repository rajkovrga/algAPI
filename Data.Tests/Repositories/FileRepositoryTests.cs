using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alg.Data.Repositories;
using Alg.Data;
using NSubstitute;
using System.IO;
using Data.Tests.Services;

namespace Data.Tests.Repositories
{
    public class FileRepositoryTests : IDisposable
    {

        private IFileContext _fileContext;
        private TestService _fileService;
        public FileRepositoryTests()
        {
            _fileContext = Substitute.For<IFileContext>();
            _fileService = new TestService();
        }

        public void Dispose()
        {
            _fileService.RemoveAllTestFiles();            
        }

        [Theory]
        [InlineData("textfile1")]
        public void RepositoryTests_GetFromFIle_ReturnFromFile(string fileName)
        {
            var repos = new FileRepository(_fileContext);

            _fileService.CreateFile(fileName);

            _fileContext.getReader().Returns(new StreamReader(_fileService.BasePath  + fileName));
            
            Assert.Equal("example", repos.Read());

        }
    }
}
