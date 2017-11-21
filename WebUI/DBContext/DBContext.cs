using System.Data.Entity;
using Domain.Entities;

namespace WebUI.DBContext
{
    public class DBContext
    {
       public DbSet<Product> Products { get; set; }
    }
}