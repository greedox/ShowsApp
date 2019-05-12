using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShowsApp
{
    class IMDBShowsLoader
    {
        public List<ShowsModel> GetShows(string site)
        {
            var webClient = new System.Net.WebClient();
            string html = webClient.DownloadString(site);

            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            var list = doc.QuerySelectorAll("div.lister-item.mode-advanced");
            var shows = new List<ShowsModel>();

            foreach (var item in list)
            {
                var name = item.QuerySelector("h3.lister-item-header>a").TextContent;
                float rating = float.Parse(item.QuerySelector("div.inline-block.ratings-imdb-rating>strong").TextContent, CultureInfo.InvariantCulture)/2;
                var genre = item.QuerySelector("span.genre").TextContent.Replace("\n","");
                var id = item.QuerySelector("a>img").GetAttribute("data-tconst");
                var title = item.QuerySelectorAll("p.text-muted")[1].TextContent.Replace("\n","");
                var poster = item.QuerySelector("div.lister-item-image.float-left>a>img").GetAttribute("src");

                shows.Add(new ShowsModel
                {
                    Name = name,
                    Rating = rating,
                    Genre = genre,
                    ImdbID = id,
                    Title = title,
                    PosterLink = poster
                });
            }

            return shows;
        }

        private ShowsModel GetShow(string id)
        {
            var webClient = new System.Net.WebClient();
            var parser = new HtmlParser();
            string htmlShow = webClient.DownloadString("https://www.imdb.com/title/" + id);
            var docShow = parser.ParseDocument(htmlShow);
            var name = docShow.QuerySelector("div.title_wrapper>h1").TextContent;
            
            return new ShowsModel { Name = name };
        }
    }
}