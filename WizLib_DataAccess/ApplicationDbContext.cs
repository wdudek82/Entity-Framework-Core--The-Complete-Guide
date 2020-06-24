using Microsoft.EntityFrameworkCore;
using WizLib_Models.Models;

namespace WizLib_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Gengres { get; set; }
    }
}
