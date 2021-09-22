using Alg.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IFileContext _fileContext;

        public FileRepository(IFileContext fileContext)
        {
            _fileContext = fileContext;
        }

        public string Read()
        {
            return _fileContext.getReader().ReadToEnd();
        }
    }
}
