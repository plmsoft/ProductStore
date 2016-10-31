using ProductStore_Users_WCFService.BO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProductStore.Users_WCFService
{
	[ServiceContract]
    public interface IUserService
	{
		[OperationContract]
		[WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GET")]
        User[] GetUsers();
        [OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/NEW")]
        void CreateUser(User user);
        [OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/UPDATE")]
        void ChangeUser(User user);
        [OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/DELETE")]
        void DeleteUser(int Id);
    }
}
