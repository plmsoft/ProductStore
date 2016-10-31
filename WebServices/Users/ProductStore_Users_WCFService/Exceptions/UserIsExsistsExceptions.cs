using System.Net;
using System.ServiceModel.Web;

namespace ProductStore.Users_WCFService.Exceptions
{
    public class UserIsExsistsExceptions : WebFaultException
    {
        public UserIsExsistsExceptions(HttpStatusCode statusCode) : base(statusCode)
        {
        }
    }
}
