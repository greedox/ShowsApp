using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
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
            TextView textView = FindViewById<TextView>(Resource.Id.item_name);
            var model = ShowsModel.FromString(Intent.GetStringExtra("model"));
            textView.Text = model.Name;
        }
    }
}