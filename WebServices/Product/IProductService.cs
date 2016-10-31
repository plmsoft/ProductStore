using ProductStore.Product_WCFService.BO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProductStore.Product_WCFService
{

    [ServiceContract]
    public interface IProductService
    {
		[OperationContract]
		[WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		Product[] GetProducts(int customerId, string patternSearch);
	}

}
