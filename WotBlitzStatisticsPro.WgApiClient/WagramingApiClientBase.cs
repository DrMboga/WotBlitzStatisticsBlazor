using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<WagramingApiClientBase> _logger;

        public WagramingApiClientBase(
			HttpClient httpClient,
			IWargamingApiSettings wargamingApiSettings,
            ILogger<WagramingApiClientBase> logger)
		{
			_httpClient = httpClient;
			_wargamingApiSettings = wargamingApiSettings;
            _logger = logger;
            _blitzApiUrls[RealmType.Eu] = "https://api.wotblitz.eu/wotb/";
			_blitzApiUrls[RealmType.Ru] = "https://api.wotblitz.ru/wotb/";
			_blitzApiUrls[RealmType.Na] = "https://api.wotblitz.com/wotb/";
			_blitzApiUrls[RealmType.Asia] = "https://api.wotblitz.asia/wotb/";

			_wotApiUrls[RealmType.Eu] = "https://api.worldoftanks.eu/wot/";
			_wotApiUrls[RealmType.Ru] = "https://api.worldoftanks.ru/wot/";
			_wotApiUrls[RealmType.Na] = "https://api.worldoftanks.com/wot/";
			_wotApiUrls[RealmType.Asia] = "https://api.worldoftanks.asia/wot/";
		}

		protected Task<T?> GetFromBlitzApi<T>(
			RealmType realmType,
			RequestLanguage language,
			string method,
			params string[] queryParameters) where T: class
		{
			string uri = GetBlitzUri(realmType, language, method, queryParameters);

			return CallWgApi<T>(uri);
        }

		protected async Task<T?> CallWgApi<T>(string uri, bool postMethod = false) where T : class
		{
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage? response;
			if(postMethod)
            {
				// Create httpContent
				var requestBody = TransformUriToRequestBody(uri);
				var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");

				response = await _httpClient.PostAsync(uri, httpContent);
            }
            else
            {
				response = await _httpClient.GetAsync(uri);
			}
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();

			var responseBody = JsonConvert.DeserializeObject<ResponseBody<T>>(responseString);

			_logger.LogInformation($"HTTP {(postMethod ? "POST": "GET")} {uri} - {responseBody.Status}");

			switch (responseBody.Status)
			{
				case "ok":
					return responseBody.Data;
				case "error":
					{
						var error = responseBody.Error;
						var message = $"Field:{(error?.Field ?? "undefined")}  Message:{(error?.Message ?? "undefined")}  Value:{(error?.Value ?? "undefined")}  Code:{(error?.Code ?? "undefined")}";
						throw new ArgumentException(message);
					}
				default:
					throw new ArgumentException($"Unexpected response body status '{responseBody.Status}'");
			}
		}


		protected string GetWotUri(RealmType realmType, string method, string[]? queryParameters)
		{
			var uri = new StringBuilder($"{_wotApiUrls[realmType]}{method}");
			uri.Append("?application_id=")
				.Append(_wargamingApiSettings.ApplicationId);
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

		private string GetBlitzUri(RealmType realmType, RequestLanguage language, string method, string[] queryParameters)
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

		private string TransformUriToRequestBody(string request)
		{
			return request.Substring(request.IndexOf('?') + 1);
		}
	}
}
