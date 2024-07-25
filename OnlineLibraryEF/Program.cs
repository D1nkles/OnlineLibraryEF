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
    }
}