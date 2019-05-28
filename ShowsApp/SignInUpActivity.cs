using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ShowsApp
{
    [Activity(Label = "@string/app_name")]
    class SignInUpActivity: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sign_in_up);

            // Locate and cache view references:
            var Email = FindViewById<EditText>(Resource.Id.editText_email);
            var Password = FindViewById<EditText>(Resource.Id.editText_password);
            var ButtonSignInUp = FindViewById<Button>(Resource.Id.button_sign_in_up);
            var TextViewSignInUp = FindViewById<Button>(Resource.Id.textView_sign_in_up);
            
            bool isSignIn = true;
            ReplaceText(isSignIn, ButtonSignInUp, TextViewSignInUp);

            TextViewSignInUp.Click += (sender, args) => 
            {
                isSignIn = !isSignIn;
                ReplaceText(isSignIn, ButtonSignInUp, TextViewSignInUp);
            };

            ButtonSignInUp.Click += (sender, args) =>
            {
                if (isSignIn)
                    SignIn(Email.Text, Password.Text);
                else
                    SignUp(Email.Text, Password.Text);
            };
        }

        private void ReplaceText(bool signIn,Button button, TextView textView)
        {
            if (signIn)
            {
                button.Text = "Sign in";
                textView.Text = GetString(Resource.String.string_sign_in);
            }
            else
            {
                button.Text = "Sign up";
                textView.Text = GetString(Resource.String.string_sign_up);
            }
        }

        private void SignIn(string email, string password)
        {

        }

        private void SignUp(string email, string password)
        {

        }

    }
}