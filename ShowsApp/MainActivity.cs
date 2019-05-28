using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Threading;

namespace ShowsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        ShowsAdapter sAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.rv);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            sAdapter = new ShowsAdapter(this, IMDBShowsManager.Shows);
            mRecyclerView.SetAdapter(sAdapter);
            IMDBShowsManager.ShowsAdd += sAdapter.RefreshRecyclerView;

            IMDBShowsManager.Init();
            Thread.Sleep(1000);
            bool a = IMDBShowsManager.IsRun;
            
        }
    }
}
