using CodeFirstApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<employe>employes { get; set; }
       
    }
}
