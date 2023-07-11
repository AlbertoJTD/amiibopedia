using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amiibopedia.Helpers
{
	public class HttpHelper<T>
	{
		public async Task<T> GetRestServiceDataAsync(string serviceAddress)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(serviceAddress);

			var response = await client.GetAsync(client.BaseAddress);
			response.EnsureSuccessStatusCode();

			var jsonResult = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<T>(jsonResult);

			return result;
		}
	}
}
