using Microsoft.EntityFrameworkCore;
using OnlineLibraryEF.Entities;
using System.Linq;

namespace OnlineLibraryEF.Repositories
{
    internal class UserRepository
    {
        public List<UserEntity> SelectAllUsers() 
        {
            using (var db = new ApplicationContext()) 
            {
                var selectedUsers = db.Users.ToList();
                return selectedUsers;
            }
        }

        public UserEntity SelectUserById(int id) 
        {
            using (var db = new ApplicationContext()) 
            {
                var selectedUser = db.Users.Include(u => u.Books).FirstOrDefault(user => user.Id == id);
                return selectedUser;
            }
        }

        public void AddNewUser(string name) 
        {
            using (var db = new ApplicationContext()) 
            {
                var newUser = new UserEntity { Name = name };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void AddNewUser(string name, string email) 
        {
            using (var db = new ApplicationContext())
            {
                var newUser = new UserEntity { Name = name, Email = email };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void DeleteUser(string name) 
        {
            using (var db = new ApplicationContext()) 
            {
                db.Users.Where(u => u.Name == name)
                    .ExecuteDelete();
                db.SaveChanges();
            }
        }

        public void DeleteUser(string name, string email)
        {
            using (var db = new ApplicationContext())
            {
                db.Users.Where(u => u.Name == name && u.Email == email)
                    .ExecuteDelete();
                db.SaveChanges();
            }
        }

        public void UpdateUserNameById(int id, string newName) 
        {
            using (var db = new ApplicationContext()) 
            {
                var selectedUser = db.Users.FirstOrDefault(user => user.Id == id);

                if (selectedUser != null)
                {
                    selectedUser.Name = newName;
                    db.SaveChanges();
                }
                else
                    Console.WriteLine($"Ошибка: Пользователь под Id {id} не найден!!!");
            }
        }

        
    }
}
