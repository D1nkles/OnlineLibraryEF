using OnlineLibraryEF;
using OnlineLibraryEF.Actions;
using OnlineLibraryEF.Entities;
using OnlineLibraryEF.Repositories;

internal class Program 
{
    static void Main(string[] args) 
    {
        using (var db = new ApplicationContext()) 
        {
            var user1 = new UserEntity() { Name = "Юзер1", Email = "емаил.ру" };
            var user2 = new UserEntity() { Name = "Юзер2", Email = "гмаил.ру" };
            var user3 = new UserEntity() { Name = "Юзер3", Email = "ямаил.ру" };
            var user4 = new UserEntity() { Name = "Юзер4", Email = "дмаил.ру" };

            var book1 = new BookEntity() { Title = "Книга1", ReleaseYear = 1984 };
            var book2 = new BookEntity() { Title = "Книга2", ReleaseYear = 1984 };
            var book3 = new BookEntity() { Title = "Книга3", ReleaseYear = 1984 };

            db.Users.AddRange(user1, user2, user3, user4);
            db.Books.AddRange(book1, book2, book3);
            db.SaveChanges();

            var user2Actions = new UserActions(user2);
            user2Actions.BorrowBook(book3);
            db.SaveChanges();
        }
    }
}