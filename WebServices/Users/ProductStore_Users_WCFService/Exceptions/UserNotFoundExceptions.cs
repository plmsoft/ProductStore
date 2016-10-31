using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace ProductStore.Users_WCFService.Exceptions
{
	public class UserNotFoundExceptions : WebFaultException
    {
        public UserNotFoundExceptions(HttpStatusCode statusCode) : base(statusCode)
        {
        }
    }
}
