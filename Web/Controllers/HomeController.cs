using HttpAnyPointServiceClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace www.ProductStore.Controllers
{

	public class HomeController : Controller
    {
        AnyPointServiceClient _anyPointServiceClient;

        [Authorize]
        public async Task<IActionResult> Index(string pattern)
        {
            var s = @"http://localhost:8084/ProductStore_Product_WCFService/ProductService/GetProducts?patternSearch={0}&customerId={1}";

			string url;

			var cId = HttpContext.Session.GetInt32("CustomerId");

			if (cId != null)
				url = string.Format(s, pattern, cId);
			else
				url = string.Format(s, pattern, 1);

			_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

            var productList = await _anyPointServiceClient.GetProducts();

            return View(productList);
        }

		public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }


}
