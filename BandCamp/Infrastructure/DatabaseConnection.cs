using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Infrastructure
{
    internal class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private SQLiteConnection _connection;
        private const string DbFileName = "bandcamp.db";

        private DatabaseConnection()
        {
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            string connectionString = $"Data Source={dbPath};Version=3;";
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
            InitializeDatabase();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DatabaseConnection();
                    }
                }
                return _instance;
            }
        }

        public SQLiteConnection Connection => _connection;

        private void InitializeDatabase()
        {
            string sql = @"
        CREATE TABLE IF NOT EXISTS Bands (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Genre TEXT,
            FormationDate TEXT,
            Description TEXT
        );
        CREATE TABLE IF NOT EXISTS Members (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FullName TEXT NOT NULL,
            Role TEXT,
            JoinDate TEXT,
            PhotoPath TEXT,
            IsActive INTEGER DEFAULT 1
        );
        CREATE TABLE IF NOT EXISTS BandMembers (
            BandId INTEGER NOT NULL,
            MemberId INTEGER NOT NULL,
            PRIMARY KEY (BandId, MemberId),
            FOREIGN KEY (BandId) REFERENCES Bands(Id),
            FOREIGN KEY (MemberId) REFERENCES Members(Id)
        );
        CREATE TABLE IF NOT EXISTS Tours (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            BandId INTEGER NOT NULL,
            Name TEXT NOT NULL,
            StartDate TEXT,
            EndDate TEXT,
            Budget REAL,
            Country TEXT,
            FOREIGN KEY (BandId) REFERENCES Bands(Id)
        );
        CREATE TABLE IF NOT EXISTS Concerts (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            TourId INTEGER NOT NULL,
            City TEXT,
            Venue TEXT,
            Date TEXT,
            TicketsSold INTEGER,
            TicketPrice REAL,
            FOREIGN KEY (TourId) REFERENCES Tours(Id)
        );";

            using (var cmd = new SQLiteCommand(sql, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void Close()
        {
            _connection?.Close();
        }
    }
}
