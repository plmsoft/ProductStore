using ProductStore.Customer_WCFService;
using ProductStore.Product_WCFService.BO;
using ProductStore.Product_WCFService.Repository;
using System;
using System.Linq;

namespace ProductStore.Product_WCFService
{

	public class ProductService : IProductService
    {
        private int GetQtyDiscount(int qty)
        {
            if (qty >= 10 && qty <= 20)
            {
                return 2;
            }
            else if (qty >= 20)
            {
                return 5;
            }

            return 0;
        }

        private int GetCustomerDiscount(int customerId)
        {
            var customerService = new CustomerService();
            return (int)customerService.GetDiscount(customerId);
        }

		public Product[] GetProducts(int customerId, string patternSearch)
		{
			var productItems = new ProductRepository().GetProducts();

			if (productItems != null && productItems.Length > 0)
			{
				int qty = 10;
				int customerDiscount = GetCustomerDiscount(customerId);
				int qtyDiscount = GetQtyDiscount(qty);
				int discount = customerDiscount + qtyDiscount;

				//Apply discount
				foreach (var productItem in productItems)
				{
					var discountValue = decimal.Round(productItem.OriginalPrice * discount / 100, 2);

					productItem.DiscountPrice = discountValue < productItem.OriginalPrice ? productItem.OriginalPrice - discountValue : productItem.OriginalPrice;
				}
			}

			if (patternSearch.Equals("*", StringComparison.OrdinalIgnoreCase))
				return productItems;
			

            return productItems.Where(d => d.Name.IndexOf(patternSearch, StringComparison.OrdinalIgnoreCase) >= 0).ToArray();
		}

        
	}
}
