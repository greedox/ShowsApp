using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Gr.Net.MaroulisLib; //EasySplashScreen

namespace ShowsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Splash screen config
            var config = new EasySplashScreen(this)
                .WithFullScreen()
                .WithLogo(Resource.Drawable.logo)
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(SignInUpActivity)))
                .WithBackgroundColor(Color.ParseColor("#074E72"))
                .WithHeaderText("Hello!!!")
                .WithFooterText("Copyright 2019")
                .WithSplashTimeOut(5000);

            //Create view from config
            View view = config.Create();
            SetContentView(view);
        }
    }
}
