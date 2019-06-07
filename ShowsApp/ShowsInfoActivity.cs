using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ShowsApp
{
    [Activity(Label = "ShowsInfoActivity")]
    class ShowsInfoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_shows_info);

            var Name = FindViewById<TextView>(Resource.Id.item_name);
            var Genre = FindViewById<TextView>(Resource.Id.item_genre);
            var Image = FindViewById<ImageView>(Resource.Id.item_img);
            var RatingBar = FindViewById<RatingBar>(Resource.Id.ratingBar_indicator);
            var Title = FindViewById<TextView>(Resource.Id.textView_title);
            var Storyline = FindViewById<TextView>(Resource.Id.textView_storyline);
            
            int position = Intent.GetIntExtra("position", 0);
            var show = IMDBShowsManager.Shows[position];
            
            Name.Text = show.Name;
            Genre.Text = show.Genre;
            Image.SetImageBitmap(IMDBShowsManager.ShowsBitmaps[position]);
            RatingBar.Rating = show.Rating;
            Title.Text = show.Title;
            Storyline.Text = show.Storyline;
        }
    }
}