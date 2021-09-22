using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg.Core.Repositories
{
    public interface IDbRepository<T>{
        public T getFirstElement();
    }
}
