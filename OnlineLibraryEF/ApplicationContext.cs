using Microsoft.EntityFrameworkCore;
using OnlineLibraryEF.Entities;

namespace OnlineLibraryEF
{
    //контекст данных, используемый для взаимодействия с базой данных
    internal class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<GenreEntrity> Genres { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        //переобпределенный метод для настройки подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ILIA\SQLEXPRESS;Database=OnlineLibrary_EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
