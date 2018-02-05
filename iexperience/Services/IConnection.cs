using System.Data.SQLite;
namespace iexperience.Services
{
    public interface IConnection
    {
        SQLiteConnection GetConnection();
    }
}
