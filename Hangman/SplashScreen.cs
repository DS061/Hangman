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
using Android.Views.Animations;

namespace Hangman
{
    [Activity(Label = "Game" , MainLauncher = true)]
    public class SplashScreen : Activity
    {

         ImageView image;
        Animation anim;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.splashscreen);


            image = FindViewById<ImageView>(Resource.Id.image);

            anim = AnimationUtils.LoadAnimation(this,Resource.Animation.rotate);


            image.StartAnimation(anim);


            anim.SetAnimationListener(new MyAnimationListener(this));



        }
    }

    class MyAnimationListener : Java.Lang.Object,
        Android.Views.Animations.Animation.IAnimationListener
    {
        Activity self;

        public MyAnimationListener(Activity self)
        {
            this.self = self;
        }

        public void OnAnimationEnd(Animation animation)
        {
            self.StartActivity(new Intent(self, typeof(choice)));
            self.Finish();
        }

        public void OnAnimationRepeat(Animation animation)
        {
        }

        public void OnAnimationStart(Animation animation)
        {
        }
    }
}