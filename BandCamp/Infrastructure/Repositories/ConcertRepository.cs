using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly SQLiteConnection _conn;

        public ConcertRepository()
        {
            _conn = DatabaseConnection.Instance.Connection;
        }

        public List<Concert> GetAll()
        {
            var list = new List<Concert>();
            string sql = "SELECT * FROM Concerts ORDER BY Date DESC";
            using (var cmd = new SQLiteCommand(sql, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(MapConcert(reader));
            }
            return list;
        }

        public Concert GetById(int id)
        {
            string sql = "SELECT * FROM Concerts WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return MapConcert(reader);
                }
            }
            return null;
        }

        public List<Concert> GetConcertsByBandId(int bandId)
        {
            var list = new List<Concert>();
            string sql = "SELECT * FROM Concerts WHERE BandId = @BandId ORDER BY Date DESC";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapConcert(reader));
                }
            }
            return list;
        }

        public void Add(Concert concert)
        {
            string sql = @"INSERT INTO Concerts
                (Name, BandId, BandName, Date, ResponsiblePerson, Payment, Comment, ContractId)
                VALUES
                (@Name, @BandId, @BandName, @Date, @ResponsiblePerson, @Payment, @Comment, @ContractId)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Name", concert.Name ?? "");
                cmd.Parameters.AddWithValue("@BandId", concert.BandId);
                cmd.Parameters.AddWithValue("@BandName", concert.BandName ?? "");
                cmd.Parameters.AddWithValue("@Date", concert.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ResponsiblePerson", concert.ResponsiblePerson ?? "");
                cmd.Parameters.AddWithValue("@Payment", concert.Payment);
                cmd.Parameters.AddWithValue("@Comment", concert.Comment ?? "");
                cmd.Parameters.AddWithValue("@ContractId", concert.ContractId.HasValue ? (object)concert.ContractId.Value : DBNull.Value);
                cmd.ExecuteNonQuery();
                concert.Id = (int)(long)new SQLiteCommand(
                    "SELECT last_insert_rowid()", _conn).ExecuteScalar();
            }
        }

        public void Update(Concert concert)
        {
            string sql = @"UPDATE Concerts SET
                Name=@Name, BandId=@BandId, BandName=@BandName, Date=@Date,
                ResponsiblePerson=@ResponsiblePerson, Payment=@Payment,
                Comment=@Comment, ContractId=@ContractId
                WHERE Id=@Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Name", concert.Name ?? "");
                cmd.Parameters.AddWithValue("@BandId", concert.BandId);
                cmd.Parameters.AddWithValue("@BandName", concert.BandName ?? "");
                cmd.Parameters.AddWithValue("@Date", concert.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ResponsiblePerson", concert.ResponsiblePerson ?? "");
                cmd.Parameters.AddWithValue("@Payment", concert.Payment);
                cmd.Parameters.AddWithValue("@Comment", concert.Comment ?? "");
                cmd.Parameters.AddWithValue("@ContractId", concert.ContractId.HasValue ? (object)concert.ContractId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", concert.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Concerts WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private Concert MapConcert(SQLiteDataReader r) => new Concert
        {
            Id = Convert.ToInt32(r["Id"]),
            Name = r["Name"].ToString(),
            BandId = Convert.ToInt32(r["BandId"]),
            BandName = r["BandName"].ToString(),
            Date = DateTime.Parse(r["Date"].ToString()),
            ResponsiblePerson = r["ResponsiblePerson"].ToString(),
            Payment = Convert.ToDecimal(r["Payment"]),
            Comment = r["Comment"].ToString(),
            ContractId = r["ContractId"] == DBNull.Value
                                ? (int?)null
                                : Convert.ToInt32(r["ContractId"])
        };
    }
}