using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMovies.Data
{
    public partial class MyMoviesDBContext : DbContext
    {
        public MyMoviesDBContext()
        {
        }

        public MyMoviesDBContext(DbContextOptions<MyMoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies1> Movies1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesDB; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Movies1>(entity =>
            {
                entity.Property(e => e.Cast).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });
        }
    }
}
