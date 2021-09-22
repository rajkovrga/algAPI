using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using System;
using Alg.Core.Models;
using Alg.Data.Interfaces;

namespace Alg.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
