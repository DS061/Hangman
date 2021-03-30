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
    [Activity(Label = "choice")]
    public class choice : Activity
    {
         GridView gv;
        EditText edtname;
        string[] item;
        string temp="";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.choice);
            gv = FindViewById<GridView>(Resource.Id.gv);
            edtname = FindViewById<EditText>(Resource.Id.edtname);


            item = new string[] {
            "NewZealand Cities",
            "Seven oceans",
            "Flowers",
            "Android Versions",
          "Birds","Animals",
        };

            
          
            gv.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, item);

            gv.ItemClick += (s, e) => {
                 temp = ""+e.Position;

                if (temp.Equals(""))
                {
                    Toast.MakeText(this, "Please Make Your Choice", ToastLength.Long).Show();
                }
                else if (edtname.Text.ToString().Equals(""))
                {
                    Toast.MakeText(this, "Please Enter Name", ToastLength.Long).Show();
                }
                else
                {
                    StartActivity(new Intent(this, typeof(Game)).PutExtra("sid", "" + temp).PutExtra("name", edtname.Text.ToString()));
                    Finish();
                }


                Toast.MakeText(this, "Your Choice is "+item[e.Position]+" !", ToastLength.Long).Show();

            };

          
        }



        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.menu1, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_menu:
                    {
                        
                        StartActivity(new Intent(this, typeof(Totalscores)));
                        Finish();
                        return true;
                    }
               
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}