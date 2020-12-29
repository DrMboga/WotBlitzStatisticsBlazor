using Newtonsoft.Json;

namespace WotBlitzStatisticsPro.WgApiClient
{
	public class ResponseBody<T> where T: class
	{
		[JsonProperty("status")]
		public string? Status { get; set; }

		[JsonProperty("meta")]
		public Meta? Meta { get; set; }

		[JsonProperty("data")]
		public T? Data { get; set; }

		[JsonProperty("error")]
		public Error? Error { get; set; }
	}

	public class Meta
	{
		[JsonProperty("count")]
		public int Count { get; set; }
	}

	public class Error
	{
		[JsonProperty("field")]
		public string? Field { get; set; }

		[JsonProperty("message")]
		public string? Message { get; set; }

		[JsonProperty("code")]
		public string? Code { get; set; }

		[JsonProperty("value")]
		public string? Value { get; set; }
	}
}
