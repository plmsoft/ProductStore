using ProductStore.Product_WCFService;
using ProductStore.Users_WCFService;
using System;
using System.ServiceModel;

namespace ProductStore.WcfServicesHost
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost[] services = new ServiceHost[2] { new ServiceHost(typeof(UserService)) ,
			new ServiceHost(typeof(ProductService))};

			foreach(var service in services)
			{
				service.Open();
				Console.WriteLine(service.BaseAddresses[0].AbsoluteUri);
			}

			Console.WriteLine("Services is working.");
			Console.WriteLine("Please type <ENTER> for close.");
			Console.ReadLine();

			foreach (var service in services)
			{
				service.Close();
			}
		}
	}
}
