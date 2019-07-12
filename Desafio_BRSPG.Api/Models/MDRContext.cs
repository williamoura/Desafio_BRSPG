using Microsoft.EntityFrameworkCore;

namespace Desafio_BRSPG.Api.Models
{
    public class MDRContext : DbContext
    {
        public MDRContext(DbContextOptions<MDRContext> options)
            : base(options)
        {
        }

        public DbSet<AdquirenteMDR> AdquirenteMDRItems { get; set; }
    }
}