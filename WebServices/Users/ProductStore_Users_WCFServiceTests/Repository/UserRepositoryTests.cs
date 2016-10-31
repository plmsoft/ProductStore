using ProductStore_Users_WCFService.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProductStore.Users_WCFService.Repository.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public void StartUpTest()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod()]
        public void ChangeUserTest()
        {
            var newUser = new User(string.Format("User{0}", 1), string.Format("Password{0}", 1));
            _userRepository.CreateUser(newUser);

            var newChangeUser = new User(2, string.Format("User{0}", 2), string.Format("Password{0}", 2));

            _userRepository.ChangeUser(newChangeUser);

            var searchUser = _userRepository.GetUsers().FirstOrDefault(d => d.ID== 2 && d.UserName == string.Format("User{0}", 2) && d.Password == string.Format("Password{0}", 2));

            if (searchUser == null)
                Assert.Fail();
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            var newUser = new User(string.Format("User{0}", 1), string.Format("Password{0}", 1));
            _userRepository.CreateUser(newUser);
            var searchUser = _userRepository.GetUsers().FirstOrDefault(d => d.UserName == string.Format("User{0}", 1) && d.Password == string.Format("Password{0}", 1));

            if (searchUser == null)
                Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            for(var i= 1; i <= 5; i++)
            {
                var newUser = new User(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                _userRepository.CreateUser(newUser);
            }

            for (var i= 1; i <= 6; i++)
            {
                _userRepository.DeleteUser(i);
            }
                
            var length = _userRepository.GetUsers().Length;

            if (length > 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            for (var i = 1; i <= 5; i++)
            {
                var newUser = new User(string.Format("User{0}", i), string.Format("Password{0}", i));
                _userRepository.CreateUser(newUser);
            }

            var users = _userRepository.GetUsers();

            if (users[0].ID != 1 || users[0].UserName != "Admin")
                Assert.Fail();

            for (var i = 1; i <= 5; i++)
            {
                var j = i;
                if (users[i].ID != ++j || !users[i].UserName.Equals(string.Format("User{0}", i)) || !users[i].Password.Equals(string.Format("Password{0}", i)))
                    Assert.Fail();
            }
        }
    }
}