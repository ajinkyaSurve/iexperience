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
                                     "/Resources/ExpDataStore.db;";
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(StartupPath);
        }
    }
}
