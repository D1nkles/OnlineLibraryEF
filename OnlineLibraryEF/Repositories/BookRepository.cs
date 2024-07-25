using Microsoft.EntityFrameworkCore;
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

        public BookEntity SelectBookById(int id)
        {
            using (var db = new ApplicationContext())
            {
                var selectedBook = db.Books.FirstOrDefault(book => book.Id == id);
                return selectedBook;
            }
        }

        public void AddNewBook(string title, string authorFirstName, string authorLastName, string genreName, int year)
        {
            using (var db = new ApplicationContext())
            {
                var authorId = db.Authors.Where(a => a.FirstName == authorFirstName && a.LastName == authorLastName)
                    .Select(a => a.Id)
                    .FirstOrDefault();

                var genreId = db.Genres.Where(g => g.Name == genreName)
                    .Select(g => g.Id)
                    .FirstOrDefault();

                var newBook = new BookEntity { Title = title, AuthorId = authorId, GenreId = genreId, ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void AddNewBook(string title, string description, string authorFirstName, string authorLastName, string genreName, int year)
        {
            using (var db = new ApplicationContext())
            {
                var authorId = db.Authors.Where(a => a.FirstName == authorFirstName && a.LastName == authorLastName)
                    .Select(a => a.Id)
                    .FirstOrDefault();

                var genreId = db.Genres.Where(g => g.Name == genreName)
                    .Select(g => g.Id)
                    .FirstOrDefault();

                var newBook = new BookEntity { Title = title, Description = description , AuthorId = authorId, GenreId = genreId, ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void DeleteBook(string title, int year) 
        {
            using (var db = new ApplicationContext()) 
            {
                db.Books.Where(book => book.Title == title && book.ReleaseYear == year)
                    .ExecuteDelete();
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

        public List<BookEntity> GetBookList(string genreName, int firstYear, int lastYear) 
        {
            using (var db = new ApplicationContext()) 
            {
                var bookList = db.Books.Where(b => b.Genre.Name == genreName && (b.ReleaseYear >= firstYear && b.ReleaseYear <= lastYear))
                    .ToList();
                return bookList;
            }
        }

        public int BooksCountByAuthor(string firstName, string lastName) 
        {
            using (var db = new ApplicationContext()) 
            {
                int bookCount = db.Books.Where(b => b.Author.FirstName == firstName && b.Author.LastName == lastName)
                    .Count();
                return bookCount;
            }
        }

        public int BooksCountByGenre(string genreName) 
        {
            using (var db = new ApplicationContext()) 
            {
                int bookCount = db.Books.Where(b => b.Genre.Name == genreName)
                    .Count();
                return bookCount;
            }
        }

        public bool BookExistsByAuthorAndTitle(string firstName, string lastName, string bookTitle) 
        {
            using (var db = new ApplicationContext()) 
            {
                var book = db.Books.Where(b => b.Author.FirstName == firstName && b.Author.LastName == lastName && b.Title == bookTitle)
                    .FirstOrDefault();

                if(book != null) 
                    return true;
                
                return false;
            }
        }

        public BookEntity GetLastReleasedBook() 
        {
            using (var db = new ApplicationContext()) 
            {
                var lastReleaseYear = db.Books.Select(b => b.ReleaseYear).Max();
                var lastReleasedBook = db.Books.Where(b => b.ReleaseYear == lastReleaseYear).FirstOrDefault();

                return lastReleasedBook;
            }
        }

        public List<BookEntity> GetBookListAlphabetSorted() 
        {
            using (var db = new ApplicationContext()) 
            {
                var books = db.Books.OrderBy(b => b.Title).ToList();
                return books;
            }
        }

        public List<BookEntity> GetBookListReleaseYearSorted() 
        {
            using (var db = new ApplicationContext()) 
            {
                var books = db.Books.OrderByDescending(b => b.ReleaseYear).ToList();
                return books;
            }
        }
    }
}
