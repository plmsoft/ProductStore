using ProductStore.Users_WCFService.Exceptions;
using ProductStore_Users_WCFService.BO;
using System;
using System.Linq;
using System.Net;

namespace ProductStore.Users_WCFService.Repository
{
	public class UserRepository: IUserRepository
    {
        private User[] _users;
        private int _sequenceUserID= 0;

        public UserRepository()
        {
            _users = new User[] { new User("Admin", "Admin")};
            _users[0].ID = ++_sequenceUserID;
        }

        public void ChangeUser(User user)
        {
            var fuser = _users.FirstOrDefault(d => d.ID == user.ID);
            if (fuser != null)
            {
                if (!_users.Any(d => (d.UserName.Equals(user.UserName, StringComparison.OrdinalIgnoreCase) || d.Password.Equals(user.Password, StringComparison.OrdinalIgnoreCase)) && (d.ID != user.ID)))
                {
                    fuser.UserName = user.UserName;
                    fuser.Password = user.Password;
                }
                else
                {
                    throw new UserIsExsistsExceptions(HttpStatusCode.Conflict);
                }
            }
            else
            {
                throw new UserNotFoundExceptions(HttpStatusCode.NotFound);
            }
        }

        public void CreateUser(User user)
        {
            if (!_users.Any(d => d.UserName.Equals(user.UserName, StringComparison.OrdinalIgnoreCase) || d.Password.Equals(user.Password, StringComparison.OrdinalIgnoreCase)))
            {
                Array.Resize<User>(ref _users, _users.Length + 1);
                _users[_users.Length - 1] = user;
                _users[_users.Length - 1].ID = ++_sequenceUserID;
                _users[_users.Length - 1].UserName = user.UserName;
                _users[_users.Length - 1].Password = user.Password;
            }
            else
            {
                throw new UserIsExsistsExceptions(HttpStatusCode.Conflict);
            }
        }

        public void DeleteUser(int Id)
        {
            if (Id != 1 && _users.Any(d=> d.ID == Id))
            {
                var newUsers = _users.Where(d => d.ID != Id).ToArray();
                Array.Resize<User>(ref _users, _users.Length - 1);
                newUsers.CopyTo(_users, 0);
            }
            else
            {
				throw new UserNotFoundExceptions(HttpStatusCode.NotFound);
            }
        }

        public User[] GetUsers()
        {
            return _users;
        }
    }
}
