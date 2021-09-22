using Alg.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace Alg.Data.Interfaces
{
    public interface IDataContext
    {
        DbSet<Item> Items { get; set; }
    }
}
