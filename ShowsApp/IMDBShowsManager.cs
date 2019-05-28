using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowsApp
{
    static class IMDBShowsManager
    {
        static public List<string> ImdbIDs { get; set; } = new List<string>();
        static public List<ShowsModel> Shows { get; set; } = new List<ShowsModel>();

        public delegate void ShowsAddContainer();
        static public event ShowsAddContainer ShowsAdd;


        //static IMDBShowsManager()
        //{
        //    ImdbIDs = GetShowsImdbID();
        //    LoadShows(5);
        //}

        static public void Init()
        {
            ImdbIDs = GetShowsImdbID();
            LoadShows(5);
        }

        static public bool IsRun = false;
        static public void LoadShows(int count)
        {
            Task.Run(() =>
            {
                IsRun = true;
                var ids = ImdbIDs.GetRange(0, count);
                ImdbIDs.RemoveRange(0, count);

                foreach (var id in ids)
                {
                    var show = GetShow(id);
                    Shows.Add(show);
                    ShowsAdd?.Invoke();
                }
                IsRun = false;
            });
        }

        static public List<string> GetShowsImdbID()
        {
            string site = "http://www.webapiservicestrunin.somee.com/api/shows";
            var webClient = new System.Net.WebClient();
            string json = webClient.DownloadString(site);

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        static private ShowsModel GetShow(string imdbID)
        {
            string site = "http://www.webapiservicestrunin.somee.com/api/shows/";
            var webClient = new System.Net.WebClient();
            string json = webClient.DownloadString(site + imdbID);

            return JsonConvert.DeserializeObject<ShowsModel>(json);
        }
    }
}