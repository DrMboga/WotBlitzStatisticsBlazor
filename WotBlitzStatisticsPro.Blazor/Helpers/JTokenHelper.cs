using Newtonsoft.Json.Linq;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class JTokenHelper
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
                    (token.Type == JTokenType.Array && !token.HasValues) ||
                    (token.Type == JTokenType.Object && !token.HasValues) ||
                    (token.Type == JTokenType.String && token.ToString() == string.Empty) ||
                    (token.Type == JTokenType.Null);
        }
    }
}
