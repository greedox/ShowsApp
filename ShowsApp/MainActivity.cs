using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content;
using ShowsApp;

namespace TestRecycleView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager sLayoutManager;
        ShowsAdapter sAdapter;
        List<ShowsModel> shows;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            shows = new List<ShowsModel>();
            shows.AddRange(new ShowsModel[] { new ShowsModel { Name = "The Big Bang Theory", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Flash", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Game of Thrones", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Vikings", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Gothem", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Flash", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Game of Thrones", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Vikings", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Gothem", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Flash", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Game of Thrones", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Vikings", Genre = "16+ | 22min | Comedy, Romance" },
            new ShowsModel { Name = "Gothem", Genre = "16+ | 22min | Comedy, Romance" }});

            SetContentView(Resource.Layout.activity_main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.rv);
            sLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(sLayoutManager);
            sAdapter = new ShowsAdapter(this, shows);
            mRecyclerView.SetAdapter(sAdapter);
        }
    }
}
