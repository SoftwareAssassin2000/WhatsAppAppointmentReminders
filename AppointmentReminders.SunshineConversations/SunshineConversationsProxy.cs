using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Dynamic;
using System.Threading.Tasks;

using Newtonsoft.Json;

using AppointmentReminders.Model;

namespace AppointmentReminders.SunshineConversations
{
	public class SunshineConversationsProxy : ISunshineConversationsProxy
	{
		public async Task SendMessage(Message input)
		{
			var key = "app_5f0518b96597cb000c9d13b4";
			var secret = "O0MX_Ta612D068SB9atsg_a_7EBIUOXaLudG4jrI67Z94Pu4Aq5SckSF6F9c4iHm2lSXg8G7N03JSN1ByYIjBQ";
			var auth = string.Format("{0}:{1}", key, secret);

			var appId = "5efa971669572a000dfda338";

			var endpoint = string.Format("https://api.smooch.io/v1.1/apps/{0}/appusers/{1}/messages", appId, input.RecipientUserId);

			dynamic data = new ExpandoObject();
			data.role = "appMaker";
			data.type = "text";
			data.text = input.Text;

			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)));
			await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
		}
	}
}
