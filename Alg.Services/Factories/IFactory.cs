using Alg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg.Services.Factories
{
    public interface IFactory
    {

        IDataService GetInstance(int key);
    }
}
