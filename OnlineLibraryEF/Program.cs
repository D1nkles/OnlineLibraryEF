using OnlineLibraryEF;
using OnlineLibraryEF.Entities;
using OnlineLibraryEF.Repositories;

internal class Program 
{
    static void Main(string[] args) 
    {
        using (var db = new ApplicationContext()) 
        {
            var user = new UserEntity() { Name = "ТутИмя", Email = "sample@gmail.com" };
            var book = new BookEntity() { Title = "Книга о всяком", ReleaseYear = 1984};

            book.Users.Add(user);
            
            db.Users.Add(user);
            db.Books.Add(book);
            db.SaveChanges();
        }
    }
}