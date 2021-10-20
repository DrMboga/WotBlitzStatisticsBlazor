using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Prolong Wargaming Auth token response
    /// </summary>
    public class WargamingProlongInfo
    {
        /// <summary>
        /// Player Account Id
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// New access token
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// New expiration unix timestamp
        /// </summary>
        public int ExpirationTimeStamp { get; set; }
    }
}
