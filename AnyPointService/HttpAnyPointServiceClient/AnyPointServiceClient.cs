using AnyPointObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HttpAnyPointServiceClient
{
	public class AnyPointServiceClient
	{
		//access token if you use authentication:
		private string _accessToken;
		//address of your Web Api:
		private string _requestAddress;

		public AnyPointServiceClient(string accessToken, string serviceAddress)
		{
			_accessToken = accessToken;
			_requestAddress = serviceAddress;
		}

		//Now you can implement methods that you will invoke to perform selected operation related with Web Api:

		#region Methods

		public async Task<ProductViewModel[]> GetProducts()
		{
			ProductViewModel[] products = null;
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var data = await client.GetAsync(_requestAddress);
					var jsonResponse = await data.Content.ReadAsStringAsync();
					if (jsonResponse != null)
						products = JsonConvert.DeserializeObject<ProductViewModel[]>(jsonResponse);
					return products;
				}
			}
			catch (WebException exception)
			{
				throw new WebException("An error has occurred while calling GetProducts method: " + exception.Message);
			}
		}

		public async Task<UserViewModel[]> GetUsers()
		{
			UserViewModel[] products = null;
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var data = await client.GetAsync(_requestAddress);
					var jsonResponse = await data.Content.ReadAsStringAsync();
					if (jsonResponse != null)
						products = JsonConvert.DeserializeObject<UserViewModel[]>(jsonResponse);
					return products;
				}
			}
			catch (WebException exception)
			{
				throw new WebException("An error has occurred while calling GetUsers method: " + exception.Message);
			}
		}

		public async Task CreateUser(UserViewModel user)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var userObjectJson = JsonConvert.SerializeObject(user);
					var content = new StringContent(userObjectJson, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync(_requestAddress, content);

					if (response.StatusCode != HttpStatusCode.OK)
						throw new WebException("An error has occurred while calling CreateUser method: " + response.Content);
				}
			}
			catch (WebException exception)
			{
				throw new WebException("An error has occurred while calling CreateUser method: " + exception.Message);
			}
		}

		public async Task ChangeUser(UserViewModel user)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var userObjectJson = JsonConvert.SerializeObject(user);
					var content = new StringContent(userObjectJson, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync(_requestAddress, content);

					if (response.StatusCode != HttpStatusCode.OK)
						throw new WebException("An error has occurred while calling ChangeUser method: " + response.Content);
				}
			}
			catch (WebException exception)
			{
				throw new WebException("An error has occurred while calling ChangeUser method: " + exception.Message);
			}
		}

		public async Task DeleteUser(int Id)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var userObjectJson = JsonConvert.SerializeObject(Id);
					var content = new StringContent(userObjectJson, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync(_requestAddress, content);

					if (response.StatusCode != HttpStatusCode.OK)
						throw new WebException("An error has occurred while calling DeleteUser method: " + response.Content);
				}
			}
			catch (WebException exception)
			{
				throw new WebException("An error has occurred while calling DeleteUser method: " + exception.Message);
			}
		}

	}

	#endregion
}


