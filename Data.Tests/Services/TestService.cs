using Alg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests.Services
{
    public class TestService
    {
        public string BasePath { get; set; }
        public IConfiguration Configuration { get; set; }
        public TestService()
        {
            BasePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\";
            Configuration = new ConfigurationBuilder()
               .SetBasePath(BasePath)
               .AddJsonFile("appsettings.json")
               .Build();
        }

        public void CreateFile(string path)
        {
            var outputPath = Path.Combine(BasePath,path + ".txt");
            var data = "example";
            File.AppendAllText(outputPath, data);
        }

        public void RemoveAllTestFiles()
        {
            foreach (string sFile in Directory.GetFiles(Path.Combine(BasePath), "*.txt"))
            {
                File.Delete(sFile);
            }
        }

        public DataContext MigrateDb(string dbName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(dbName));
            return new DataContext(optionsBuilder.Options);
        }
    }
}
