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
    [Activity(Label = "Leaders")]
    public class Totalscores : Activity
    {
        TextView score;
        public List<model> list;
        model c;
        DataStore dataStore;
        Button ret;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.totalscores);
            score = FindViewById<TextView>(Resource.Id.txtscore);
            ret = FindViewById<Button>(Resource.Id.btnret);
            // Create your application here
            dataStore = new DataStore(this);

            list = new List<model>();

            list = dataStore.getscore(this);

           // Toast.MakeText(this, "" + list.Count, ToastLength.Long).Show();

            for (int i = 0; i < list.Count; i++)
            {
                c = new model();
                c.Subid = list[i].Subid;
                c.Name = list[i].Name;

                score.Text = score.Text + "\n" + c.Name + " " + c.Subid;
            }

            ret.Click += (s, e) => {

                StartActivity(new Intent(this, typeof(choice)));
                Finish();

            };

        }
    }
}