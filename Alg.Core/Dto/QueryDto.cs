using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg.Core.Dto
{
    public enum Type
    {
        File,
        Entry,
        Db
    }
    public class QueryDto
    {
        public string Description { get; set; }
        public Type Type { get; set; }
    }
}
