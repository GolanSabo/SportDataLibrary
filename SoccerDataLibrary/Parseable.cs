using Newtonsoft.Json.Linq;

namespace SoccerDataLibrary
{
    /// <summary>
    /// interface for json parsing.
    /// </summary>
    interface Parseable
    {
        /// <summary>
        /// parse json object.
        /// </summary>
        /// <param name="json"></param>
        void Parse(JObject json);
    }
}
