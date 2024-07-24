using OnlineLibraryEF;
using OnlineLibraryEF.Repositories;

internal class Program 
{
    static void Main(string[] args) 
    {
        using (var db = new ApplicationContext()) { }
    }
}