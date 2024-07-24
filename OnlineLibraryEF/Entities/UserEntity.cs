using System.Net;

namespace OnlineLibraryEF.Entities
{
    internal class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

        //навигационное свойство для связи с BookEntity
        public List<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
