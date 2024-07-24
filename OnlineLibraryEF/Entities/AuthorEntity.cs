namespace OnlineLibraryEF.Entities
{
    internal class AuthorEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }

        //навигационное свойство для связи с EntityBooks
        public List<BookEntity> Books { get; set; }
    }
}
