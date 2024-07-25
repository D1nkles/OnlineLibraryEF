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

        public void AddNewBook(string title, AuthorEntity author, GenreEntrity genre, int year)
        {
            using (var db = new ApplicationContext())
            {
                var newBook = new BookEntity { Title = title, AuthorId = author.Id, GenreId = genre.Id, ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void AddNewBook(string title, string description, AuthorEntity author, GenreEntrity genre, int year)
        {
            using (var db = new ApplicationContext())
            {
                var newBook = new BookEntity { Title = title, Description = description , AuthorId = author.Id, GenreId = genre.Id, ReleaseYear = year };

                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void DeleteBook(string title, int year) 
        {
            using (var db = new ApplicationContext()) 
            {
                var newBook = new BookEntity { Title = title, ReleaseYear = year };

                db.Books.Where(book => book.Title == title && book.ReleaseYear == year).ExecuteDelete();
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
                var genreEntity = db.Genres.Where(g => g.Name == genreName).FirstOrDefault();

                var bookList = db.Books.Where(b => b.Genre.Id == genreEntity.Id && (b.ReleaseYear >= firstYear && b.ReleaseYear <= lastYear)).ToList();
                return bookList;
            }
        }



    }
}
