using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly SQLiteConnection _conn;

        public TourRepository()
        {
            _conn = DatabaseConnection.Instance.Connection;
        }

        public List<Tour> GetAll()
        {
            var tours = new List<Tour>();
            string sql = "SELECT * FROM Tours";
            using (var cmd = new SQLiteCommand(sql, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    tours.Add(MapTour(reader));
            }
            return tours;
        }

        public Tour GetById(int id)
        {
            string sql = "SELECT * FROM Tours WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return MapTour(reader);
                }
            }
            return null;
        }

        public List<Tour> GetToursByBandId(int bandId)
        {
            var tours = new List<Tour>();
            string sql = "SELECT * FROM Tours WHERE BandId = @BandId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        tours.Add(MapTour(reader));
                }
            }
            return tours;
        }

        public void Add(Tour tour)
        {
            string sql = @"INSERT INTO Tours (BandId, Name, StartDate, EndDate, Budget, Country)
                           VALUES (@BandId, @Name, @StartDate, @EndDate, @Budget, @Country)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", tour.BandId);
                cmd.Parameters.AddWithValue("@Name", tour.Name);
                cmd.Parameters.AddWithValue("@StartDate", tour.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", tour.EndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Budget", tour.Budget);
                cmd.Parameters.AddWithValue("@Country", tour.Country ?? "");
                cmd.ExecuteNonQuery();
                tour.Id = (int)new SQLiteCommand("SELECT last_insert_rowid()", _conn).ExecuteScalar();
            }
        }

        public void Update(Tour tour)
        {
            string sql = @"UPDATE Tours SET Name=@Name, StartDate=@StartDate,
                           EndDate=@EndDate, Budget=@Budget, Country=@Country
                           WHERE Id=@Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Name", tour.Name);
                cmd.Parameters.AddWithValue("@StartDate", tour.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", tour.EndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Budget", tour.Budget);
                cmd.Parameters.AddWithValue("@Country", tour.Country ?? "");
                cmd.Parameters.AddWithValue("@Id", tour.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Tours WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private Tour MapTour(SQLiteDataReader r) => new Tour
        {
            Id = Convert.ToInt32(r["Id"]),
            BandId = Convert.ToInt32(r["BandId"]),
            Name = r["Name"].ToString(),
            StartDate = DateTime.Parse(r["StartDate"].ToString()),
            EndDate = DateTime.Parse(r["EndDate"].ToString()),
            Budget = Convert.ToDecimal(r["Budget"]),
            Country = r["Country"].ToString()
        };
    }
}