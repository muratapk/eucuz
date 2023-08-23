using eucuz.Models;
using Microsoft.EntityFrameworkCore;


namespace eucuz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<kategoriler> kategorilers { get; set; }
        public DbSet<Urunler> urunlers { get; set; }
        public DbSet<siparisler> siparislers { get; set; }
        public DbSet<sepet> sepet { get; set; }

        public DbSet<Admin> admins { get; set; }
    }
}
