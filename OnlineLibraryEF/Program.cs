using OnlineLibraryEF;
using OnlineLibraryEF.Actions;
using OnlineLibraryEF.Entities;
using OnlineLibraryEF.Repositories;

internal class Program 
{
    static void Main(string[] args) 
    {
        BookRepository bookRepository = new BookRepository();
        UserRepository userRepository = new UserRepository();

        var bookList = bookRepository.GetBookList("Ужасы", 1960, 2000);
        foreach (var book in bookList)
        {
            Console.WriteLine(book.Title);
        }
        Console.WriteLine();

        Console.WriteLine(bookRepository.BooksCountByAuthor("Пугач", "Пугачевов"));
        Console.WriteLine();

        Console.WriteLine(bookRepository.BooksCountByGenre("Фэнтези"));
        Console.WriteLine();

        Console.WriteLine(bookRepository.BookExistsByAuthorAndTitle("Фантазер", "Фантазеров", "Фэнтезийная Книга"));
        Console.WriteLine();

        var user = userRepository.SelectUserById(3);
        var Thatbook = bookRepository.SelectBookById(7);
        var userActions = new UserActions(user);

        Console.WriteLine(userActions.HasBook(Thatbook.Title, Thatbook.ReleaseYear));
        Console.WriteLine();

        Console.WriteLine(bookRepository.GetLastReleasedBook().Title);
        Console.WriteLine();

        var booksAlphaSorted = bookRepository.GetBookListAlphabetSorted();
        foreach (BookEntity book in booksAlphaSorted)
        {
            Console.WriteLine(book.Title);
        }
        Console.WriteLine();

        var booksYearsSorted = bookRepository.GetBookListReleaseYearSorted();
        foreach (BookEntity book in booksYearsSorted)
        {
            Console.WriteLine(book.Title);
        }
        Console.WriteLine();
    }
}