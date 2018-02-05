using System;
using iexperience.Services;
using System.Data.SQLite;

namespace iexperience.Repositories
{
    public class Connection : IConnection
    {
        public string StartupPath { get; set; }
        public Connection()
        {
            StartupPath = "Data Source=" + Environment.CurrentDirectory +
                                     "/wwwroot/Resources/ExpDataStore.db;";
        }

        public SQLiteConnection GetConnection() => new SQLiteConnection(StartupPath);
    }
}
