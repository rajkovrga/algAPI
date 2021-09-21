using Alg.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Alg.Data
{
    public interface IDbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}
