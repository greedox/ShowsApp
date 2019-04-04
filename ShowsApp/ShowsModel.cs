using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestRecycleView
{
    
    class ShowsModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public string Poster { get; set; }
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