using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

    }
}
