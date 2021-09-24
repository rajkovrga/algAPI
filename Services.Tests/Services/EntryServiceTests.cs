using Alg.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Services.Tests.Services
{
    public class EntryServiceTests
    {
        [Fact]
        public void EntryService_PassString_ReturnLength()
        {
            var r = new EntryService();

            Assert.Equal(7, r.GetLength("example"));
        }

    }
}
