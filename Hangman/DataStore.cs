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
using Android.Database.Sqlite;
using Android.Database;

namespace Hangman
{
    public class DataStore : SQLiteOpenHelper
    {

        private const string _DatabaseName = "mydatabase1.db";
        private const string TableName = "category";
        private const string ColumnID = "id";
        private const string ColumnName = "name";
        private const string SubcatID = "subid";

        public const string CreateQuery = "CREATE TABLE " + TableName + " ( "
      + ColumnID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
            + SubcatID + " INTEGER,"
      + ColumnName + " VARCHAR(50))";

        public const string Createscore = "CREATE TABLE score1("
      + ColumnID + " INTEGER PRIMARY KEY AUTOINCREMENT,name VARCHAR(50),score VARCHAR(10))";
      


        public const string DeleteQuery = "DROP TABLE IF EXISTS " + TableName;

        public DataStore(Context context) : base(context, _DatabaseName, null, 1)
        {
            
        }

        // Default function to create the database. 
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateQuery);
            db.ExecSQL(Createscore);

        }

        // Default function to upgrade the database.
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(DeleteQuery);
            OnCreate(db);
        }


        public void insercat(Context context, model c)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put(SubcatID, c.Subid);
            contentValues.Put(ColumnName, c.Name);

            db.Insert(TableName, null, contentValues);
            db.Close();
        }

        public void inserscore(Context context,string name,string score)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put("name", name);
            contentValues.Put("score", score);

            db.Insert("score1", null, contentValues);
           // Toast.MakeText(context, "insert" , ToastLength.Long).Show();
            db.Close();
        }

        public List<model> getcat(Context context,string sid)
        {
            List<model> c = new List<model>();
            SQLiteDatabase db = new DataStore(context).ReadableDatabase;
            //string[] columns = new string[] { ColumnID, ColumnName , SubcatID };
            string query="select * from "+TableName+" where "+SubcatID+"="+sid;
            using (ICursor cursor = db.RawQuery( query,null))
            {
                while (cursor.MoveToNext())
                {
                    c.Add(new model
                    {
                        Id = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnID)),
                        Name = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnName)),
                        Subid= cursor.GetString(cursor.GetColumnIndexOrThrow(SubcatID)),
                    });
                }
            }
            //Toast.MakeText(context, "" + c.Count, ToastLength.Long).Show();
            db.Close();
            return c;
        }

      

        public  void deleterecord(Context context)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
             string del = "delete from " + TableName;
            db.ExecSQL(del);


        db.Close();
        }

        public List<model> getscore(Context context)
        {
            List<model> c = new List<model>();
            SQLiteDatabase db = new DataStore(context).ReadableDatabase;
            //string[] columns = new string[] { ColumnID, ColumnName , SubcatID };
            string query = "select * from score1";
            using (ICursor cursor = db.RawQuery(query, null))
            {
                while (cursor.MoveToNext())
                {
                    //Toast.MakeText(context, "" + cursor.GetString(cursor.GetColumnIndexOrThrow("score")), ToastLength.Long).Show();
                    c.Add(new model
                    {
                        Id = cursor.GetString(cursor.GetColumnIndexOrThrow(ColumnID)),
                        Name = cursor.GetString(cursor.GetColumnIndexOrThrow("name")),
                        Subid = cursor.GetString(cursor.GetColumnIndexOrThrow("score")),
                      
                });
                }
            }
          
            db.Close();
            return c;
        }



    }
}