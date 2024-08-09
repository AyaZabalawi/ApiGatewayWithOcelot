using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Author.Core.Domain.Entities;

namespace Author.Infrastucture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet <AuthorE> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorE>().ToTable("Authors");

            // Seed data
            modelBuilder.Entity<AuthorE>().HasData
                (
                    new AuthorE { AuthorId = Guid.NewGuid(), AuthorName = "John Doe" },
                    new AuthorE { AuthorId = Guid.NewGuid(), AuthorName = "Jane Smith" }
                );
        }

    }
}
