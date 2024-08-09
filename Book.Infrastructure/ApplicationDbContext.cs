using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <BookE> Books {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookE>().ToTable("Books");

            // Seed data
            modelBuilder.Entity<BookE>().HasData(
                new BookE() { BookId = Guid.NewGuid(), BookTitle = "Book 1" },
                new BookE() { BookId = Guid.NewGuid(), BookTitle = "Book 2" }
            );
        }

    }
}
