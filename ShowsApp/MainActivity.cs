using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using ShowsApp;
using System.Collections.Generic;

namespace TestRecycleView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager sLayoutManager;
        ShowsAdapter sAdapter;
        List<ShowsModel> shows;
        IMDBShowsLoader showsLoader = new IMDBShowsLoader();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            shows = new List<ShowsModel>();

            string site = "https://www.imdb.com/search/title?sort=user_rating,desc&title_type=tv_series,mini_series&num_votes=5000,";

            shows = showsLoader.GetShows(site);

            SetContentView(Resource.Layout.activity_main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.rv);
            sLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(sLayoutManager);
            sAdapter = new ShowsAdapter(this, shows);
            mRecyclerView.SetAdapter(sAdapter);


        }
    }
}
