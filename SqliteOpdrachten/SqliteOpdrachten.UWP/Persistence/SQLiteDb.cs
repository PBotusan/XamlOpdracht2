using SQLite;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using SqliteOpdrachten.UWP.Persistence;
using SqliteOpdrachten.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]

namespace SqliteOpdrachten.UWP.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
