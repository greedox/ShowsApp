using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ShowsApp;

namespace TestRecycleView
{
    [Activity(Name = "TestRecycleView.TestRecycleView.ShowsInfoActivity")]
    class ShowsInfoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.item_shows);
            var Name = FindViewById<TextView>(Resource.Id.item_name);
            var Genre = FindViewById<TextView>(Resource.Id.item_genre);
            var RatingBar = FindViewById<RatingBar>(Resource.Id.ratingBar_indicator);
            var model = ShowsModel.FromString(Intent.GetStringExtra("model"));

            Name.Text = model.Name;
            Genre.Text = model.Genre;
            RatingBar.Rating = model.Rating;
        }
    }
}