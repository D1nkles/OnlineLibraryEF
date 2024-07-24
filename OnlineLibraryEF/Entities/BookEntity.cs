namespace OnlineLibraryEF.Entities
{
    internal class BookEntity
    {
        public int Id { get; set; }

        //внешний ключ, указывающий на AuthorEntity.Id
        public int? AuthorId { get; set; }

        //внешний ключ, указывающий на GenreEntity.Id
        public int? GenreId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }        
        public int ReleaseYear { get; set; }

        //навигационное свойство для связи с AuthorEntity
        public AuthorEntity Author { get; set; }

        //навигационное свойство для связи с GenreEntity
        public GenreEntrity Genre { get; set; }

        //навигационное свойство для связи с UserEntity
        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
