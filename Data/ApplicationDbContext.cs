using Collections.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collections.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Item>()
                .HasOne(p => p.CollectionItem)
                .WithMany(t => t.Items)
                .HasForeignKey(p => p.CollectionId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collection>()
                .HasOne(p => p.AppUser)
                .WithMany(t => t.Collections)
                .HasForeignKey(p => p.UserCollectionId);
            base.OnModelCreating(modelBuilder);
        }
    }
}