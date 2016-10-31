using ProductStore_Users_WCFService.BO;

namespace ProductStore.Users_WCFService.Repository
{
    public interface IUserRepository
    {
        User[] GetUsers();
        void CreateUser(User user);
        void ChangeUser(User user);
        void DeleteUser(int Id);
    }
}
