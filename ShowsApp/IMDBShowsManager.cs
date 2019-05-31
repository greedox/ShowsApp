﻿using Newtonsoft.Json;
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

        public delegate void ShowsClearContainer();
        static public event ShowsAddContainer ShowsClear;

        public enum ShowsLoadCount
        {
            Small = 1,
            Middle = 5,
            Large = 10
        }

        static IMDBShowsManager()
        {
            Init();
        }

        static public void Init()
        {
            ImdbIDs.Clear();
            Shows.Clear();
            ShowsClear?.Invoke();
            ImdbIDs = GetShowsImdbID();
            LoadShows(ShowsLoadCount.Large);
        }

        static public bool IsRun = false;
        static public void LoadShows(ShowsLoadCount loadCount)
        {
            Task.Run(() =>
            {
                if (IsRun) return;
                IsRun = true;
                int count = (int)loadCount;

                var ids = ImdbIDs.GetRange(0, count);
                ImdbIDs.RemoveRange(0, count);

                foreach (var id in ids)
                {
                    var show = GetShow(id);
                    Shows.Add(show);
                }
                IsRun = false;
                ShowsAdd?.Invoke();
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