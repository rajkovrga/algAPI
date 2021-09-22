using Alg.Core.Repositories;
using Alg.Core.Services;
using System;

namespace Alg.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public int GetLength(string desc = "")
        {
            return _fileRepository.Read().Length;
        }
    }
}
