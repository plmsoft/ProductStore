using System.Runtime.Serialization;

namespace ProductStore_Users_WCFService.BO
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }

        public User() { }
        
        public User(string name, string password)
        {
            UserName = name;
            Password = password;
        }

        public User(int Id, string name, string password)
        {
            ID = Id;
            UserName = name;
            Password = password;
        }

    }
}
