using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Alg.Data
{
    public class FileContext : IFileContext
    {
        public StreamReader getReader()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration.GetSection("FileDetector:File").Value);
            var r = new StreamReader(Path.GetFullPath(path), Encoding.ASCII, true);
            return r;
        }
      
    }
}
