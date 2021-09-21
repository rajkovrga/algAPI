using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using Alg.Data.Models;
using System;

namespace Alg.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }

    }
}
