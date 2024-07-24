using OnlineLibraryEF.Entities;

namespace OnlineLibraryEF.Repositories
{
    internal class BookRepository
    {
        public List<BookEntity> SelectAllBooks()
        {
            using (var db = new ApplicationContext())
            {
                var selectedBooks = db.Books.ToList();
                return selectedBooks;
            }
        }

        public BookEntity SelectUserById(int id)
        {
            using (var db = new ApplicationContext())
            {
                var selectedUser = db.Books.FirstOrDefault(book => book.Id == id);
                return selectedUser;
            }
        }

        public void AddNewBook(string title, int year)
        {
            using (var db = new ApplicationContext())
            {
                var newBook = new BookEntity { Title = title, ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void AddNewBook(string title, string author, string description , int year)
        {
            using (var db = new ApplicationContext())
            {
                var newBook = new BookEntity { Title = title, Description = description , ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void DeleteBook(string title, string author, int year) 
        {
            using (var db = new ApplicationContext()) 
            {
                var newBook = new BookEntity { Title = title, ReleaseYear = year };

                db.Books.Remove(newBook);
                db.SaveChanges();
            }
        }

        public void DeleteBook(string title, string author, string description , int year)
        {
            using (var db = new ApplicationContext())
            {
                var newBook = new BookEntity { Title = title, Description = description ,ReleaseYear = year };

                db.Books.Remove(newBook);
                db.SaveChanges();
            }
        }

        public void UpdateBookReleaseYearById(int id, int newReleaseYear) 
        {
            using (var db = new ApplicationContext()) 
            {
                var selectedBook = db.Books.FirstOrDefault(book => book.Id == id);

                if (selectedBook != null)
                {
                    selectedBook.ReleaseYear = newReleaseYear;
                    db.SaveChanges();
                }
                else
                    Console.WriteLine($"Ошибка: Книга под Id {id} не найдена!!!");
            }
        }
    }
}
