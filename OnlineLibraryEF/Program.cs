using OnlineLibraryEF;
using OnlineLibraryEF.Actions;
using OnlineLibraryEF.Entities;
using OnlineLibraryEF.Repositories;

internal class Program 
{
    static void Main(string[] args) 
    {
        BookRepository bookRepository = new BookRepository();
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
    }
}