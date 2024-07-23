using Microsoft.EntityFrameworkCore;
using OnlineLibraryEF.Entities;

namespace OnlineLibraryEF
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ILIA\SQLEXPRESS;Database=OnlineLibrary_EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
