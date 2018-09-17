using System;
using System.IO;
using SQLite;
using Xamarin.Forms;


using Foundation;
using SqliteOpdrachten.Persistence;
using UIKit;
using SqliteOpdrachten.iOS.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]

namespace SqliteOpdrachten.iOS.Persistence
{
   public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }

    }
}