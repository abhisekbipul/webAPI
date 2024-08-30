using Microsoft.EntityFrameworkCore;
using WebAPIApp.Models;

namespace WebAPIApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Emp> employee { get; set; }
    }
}
