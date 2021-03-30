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

namespace Hangman
{
    [Activity(Label = "Result")]
    public class Result : Activity
    {

        Button btnhome;
        TextView txtname;
        string uname,points;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.result);
            // Create your application here
            txtname = FindViewById<TextView>(Resource.Id.txtname);
            btnhome = FindViewById<Button>(Resource.Id.btnhome);

            txtname.Text= "Hey "+Intent.GetStringExtra("name")+" ! \n"+"Your score is "+ Intent.GetStringExtra("score");


            btnhome.Click += (s, e) => {

                StartActivity(new Intent(this, typeof(choice)));
            Finish();

            };

        }
    }
}