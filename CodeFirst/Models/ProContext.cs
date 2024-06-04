using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class ProContext:DbContext
    {
        public ProContext() { }

        public ProContext(DbContextOptions<ProContext> options) : base(options) { }

        public DbSet<product> ProductTable { get; set; }

        public DbSet<order> OrderTable { get; set; }
    }
}
