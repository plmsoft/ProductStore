namespace ProductStore.Customer_WCFService
{
	public class CustomerService : ICustomerService
    {
        public int GetDiscount(int customerId)
        {
            if (customerId == 1)
            {
                return 10;
            }

            return 0;
        }
    }
}
