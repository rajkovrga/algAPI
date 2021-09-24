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
            var r = _fileRepository.Read();

            if (r == null)
                return 0;

            return r.Length;
        }
    }
}
