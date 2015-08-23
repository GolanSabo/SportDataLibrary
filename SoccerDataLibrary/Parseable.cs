using Newtonsoft.Json.Linq;

namespace SoccerDataLibrary
{
    interface Parseable
    {
        void Parse(JObject json);
    }
}
