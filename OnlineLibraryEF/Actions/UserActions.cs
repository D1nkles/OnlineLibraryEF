using OnlineLibraryEF.Entities;

namespace OnlineLibraryEF.Actions
{
    internal class UserActions
    {
        private UserEntity user;
        public UserActions(UserEntity user) 
        {
            this.user = user;
        }
        public void BorrowBook(BookEntity book) 
        {
            using (var db = new ApplicationContext())
                user.Books.Add(book);
        }
    }
}
