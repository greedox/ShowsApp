using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace ShowsApp
{
    class ShowsAdapter : RecyclerView.Adapter
    {
        private List<ShowsModel> shows;
        private Context context;

        public ShowsAdapter(Context context, List<ShowsModel> shows)
        {
            this.shows = shows;
            this.context = context;
        }

        public override int ItemCount => shows.Count;

        public void RefreshRecyclerView() => NotifyItemInserted(ItemCount - 1);

        class ShowsViewHolder : RecyclerView.ViewHolder
        {
            public TextView Name { get; private set; }
            public TextView Genre { get; private set; }
            public RatingBar RatingBar { get; private set; }

            public ShowsModel ShowsModel { get; set; }

            public ShowsViewHolder(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                Name = itemView.FindViewById<TextView>(Resource.Id.item_name);
                Genre = itemView.FindViewById<TextView>(Resource.Id.item_genre);
                RatingBar = itemView.FindViewById<RatingBar>(Resource.Id.ratingBar_indicator);


                itemView.Click += (sender, args) =>
                {
                    Intent intent = new Intent(itemView.Context, typeof(ShowsInfoActivity));
                    intent.PutExtra("model", ShowsModel.ToString());
                    itemView.Context.StartActivity(intent);
                };

            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ShowsViewHolder vh = holder as ShowsViewHolder;
            vh.Name.Text = shows[position].Name;
            vh.Genre.Text = shows[position].Genre;
            vh.ShowsModel = shows[position];
            vh.RatingBar.Rating = shows[position].Rating;

            if (position == shows.Count - 1)
            {
                IMDBShowsManager.LoadShows(1);
            }
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                    Inflate(Resource.Layout.item_shows, parent, false);
            ShowsViewHolder vh = new ShowsViewHolder(itemView);
            return vh;
        }
    }
}