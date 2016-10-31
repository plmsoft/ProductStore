using ProductStore.Product_WCFService.BO;

namespace ProductStore.Product_WCFService.Repository
{

    public class ProductRepository
    {
        public Product[] GetProducts()
        {
            return new Product[]
                        {
                new Product
                {
                    ID = 1,
                    Sku = "124CXS2",
                    Name = "Product 1",
                    OriginalPrice = 14.00M,
                    RRP = 10.56M
                },

                new Product
                {
                    ID = 2,
                    Sku = "3244D21",
                    Name = "Product 2",
                    OriginalPrice = 11.00M,
                    RRP = 10.20M
                },

                new Product
                {
                    ID = 3,
                    Sku = "A676741",
                    Name = "Product 3",
                    OriginalPrice = 12.00M,
                    RRP = 11.33M
                },

                new Product
                {
                    ID = 4,
                    Sku = "A331444",
                    Name = "Product 4",
                    OriginalPrice = 9.20M,
                    RRP = 8.01M
                },

                new Product
                {
                    ID = 5,
                    Sku = "A331444",
                    Name = "Product 5",
                    OriginalPrice = 7.50M,
                    RRP = 6.11M
                }
            };
        }
    }

}
