using System.Net;

namespace OnlineLibraryEF.Entities
{
    internal class GenreEntrity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //навигационное свойство для связи с EntityBooks
        public List<BookEntity> Books { get; set; }
    }
}
