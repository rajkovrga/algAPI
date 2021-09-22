using Alg.Core.Services;
using System;

namespace Alg.Services.Services
{
    public class EntryService : IEntryService
    {
        public int GetLength(string desc = "")
        {
            return desc.Length;
        }
    }
}
