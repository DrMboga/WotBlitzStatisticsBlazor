using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public class WagramingApiClientBase
	{
		private Dictionary<RealmType, string> _blitzApiUrls = new Dictionary<RealmType, string>();
		private Dictionary<RealmType, string> _wotApiUrls = new Dictionary<RealmType, string>();


		private readonly HttpClient _httpClient;
		private readonly IWargamingApiSettings _wargamingApiSettings;

		public WagramingApiClientBase(
			HttpClient httpClient,
			IWargamingApiSettings wargamingApiSettings)
		{
			_httpClient = httpClient;
			_wargamingApiSettings = wargamingApiSettings;
			_blitzApiUrls[RealmType.Eu] = "https://api.wotblitz.eu/wotb/";
			_blitzApiUrls[RealmType.Ru] = "https://api.wotblitz.ru/wotb/";
			_blitzApiUrls[RealmType.Na] = "https://api.wotblitz.com/wotb/";
			_blitzApiUrls[RealmType.Asia] = "https://api.wotblitz.asia/wotb/";

			_wotApiUrls[RealmType.Eu] = "https://api.worldoftanks.eu/wot/";
			_wotApiUrls[RealmType.Ru] = "https://api.worldoftanks.ru/wot/";
			_wotApiUrls[RealmType.Na] = "https://api.worldoftanks.com/wot/";
			_wotApiUrls[RealmType.Asia] = "https://api.worldoftanks.asia/wot/";
		}

		protected async Task<T> GetFromBlitzApi<T>(
			RealmType realmType,
			RequestLanguage language,
			string method,
			params string[] queryParameters)
		{
			string uri = GetUri(realmType, language, method, queryParameters);

			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await _httpClient.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();

			var responseBody = JsonConvert.DeserializeObject<ResponseBody<T>>(responseString);
			if (responseBody.Status == "ok")
			{
				return responseBody.Data;
			}
			if (responseBody.Status == "error")
			{
				var error = responseBody.Error;
				var message = $"Field:{error.Field}  Message:{error.Message}  Value:{error.Value}  Code:{error.Code}";
				throw new ArgumentException(message);
			}
			return default(T);
		}

		private string GetUri(RealmType realmType, RequestLanguage language, string method, string[] queryParameters)
		{
			var uri = new StringBuilder($"{_blitzApiUrls[realmType]}{method}");
			uri.Append("?application_id=")
				.Append(_wargamingApiSettings.ApplicationId)
				.Append("&language=")
				.Append(language.ToString().ToLower());
			if (queryParameters != null)
			{
				foreach (var param in queryParameters)
				{
					uri.Append("&")
						.Append(param);
				}
			}
			return uri.ToString();
		}
	}
}
