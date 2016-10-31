using ProductStore.Users_WCFService.Repository;
using ProductStore_Users_WCFService.BO;
using System;
using System.Linq;

namespace ProductStore.Users_WCFService
{
    public class UserService : IUserService
    {
        public void ChangeUser(User user)
        {
            var _userRepository = UserRepositoryFactory.GetUserRepository();
            _userRepository.ChangeUser(user);
        }

        public void CreateUser(User user)
        {
            var _userRepository = UserRepositoryFactory.GetUserRepository();
            _userRepository.CreateUser(user);
        }

        public void DeleteUser(int Id)
        {
            var _userRepository = UserRepositoryFactory.GetUserRepository();
            _userRepository.DeleteUser(Id);
        }

        public User[] GetUsers()
        {
			var _userRepository = UserRepositoryFactory.GetUserRepository();

			var usersItems = _userRepository.GetUsers();

			return usersItems;
		}
    }
}
