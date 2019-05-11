using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShowsApp
{

    class ShowsModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public string PosterLink { get; set; }
        public float Rating { get; set; }
        public string Title { get; set; }
        public string ImdbID { get; set; }

        /// <summary>
        /// Converts to Json
        /// </summary>
        public override string ToString() =>
            JsonConvert.SerializeObject(this);

        public static ShowsModel FromString(string json) =>
            JObject.Parse(json ?? "{}").ToObject<ShowsModel>();
    }
}