using SQLite;

namespace SqliteOpdrachten.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
