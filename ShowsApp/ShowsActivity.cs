using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Xamarin.Essentials;

namespace ShowsApp
{
    [Activity(Label = "ShowsActivity")]
    class ShowsActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        ShowsAdapter sAdapter;
        LinearLayoutManager layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_shows);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.rv);
            layoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(layoutManager);
            sAdapter = new ShowsAdapter(this, IMDBShowsManager.Shows);
            mRecyclerView.SetAdapter(sAdapter);
            IMDBShowsManager.ShowsAdd += sAdapter.RefreshRecyclerView;
            IMDBShowsManager.ShowsClear += sAdapter.RefreshRecyclerView;
            Accelerometer.ShakeDetected += (s, e) =>
            {
                Toast.MakeText(this, "Shake detected", ToastLength.Short).Show();
                IMDBShowsManager.Init();
            };
            SensorSpeed speed = SensorSpeed.Game;
            Accelerometer.Start(speed);
            IMDBShowsManager.Init();
        }
    }
}