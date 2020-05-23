namespace WotBlitzStatisticsPro.Common
{
	/// <summary>
	/// Represents Application settings section related with Wargaming API
	/// </summary>
	public interface IWargamingApiSettings
	{
		/// <summary>
		/// Wargaming applicationId
		/// </summary>
		string ApplicationId { get; set; }
	}
}
