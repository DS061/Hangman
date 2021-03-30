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
    class LetterAdapter : BaseAdapter
    {

        Context context;
        private string[] letters;
        private LayoutInflater letterInf;

        public LetterAdapter(Context context)
        {
            this.context = context;


            letters = new string[26];
            for (int a = 0; a < letters.Length; a++)
            {
                letters[a] = "" + (char)(a + 'A');
            }
            //specify the context in which we want to inflate the layout
            // will be passed from the main activity
            letterInf = LayoutInflater.From(context);
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            // letterInf = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
              
          

            Button letterBtn;
          
          
     

            if (convertView == null)
            {
                //inflate the button layout
                letterBtn = (Button)letterInf.Inflate(Resource.Layout.letter, parent, false);
            }
            else
            {
                letterBtn = (Button)convertView;
            }
            //set the text to this letter
            letterBtn.Text=letters[position];
            return letterBtn;




  
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return letters.Length;
            }
        }

    }

   
}