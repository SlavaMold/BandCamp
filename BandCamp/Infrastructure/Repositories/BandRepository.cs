using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly SQLiteConnection _conn;

        public BandRepository()
        {
            _conn = DatabaseConnection.Instance.Connection;
        }

        public List<Band> GetAll()
        {
            var bands = new List<Band>();
            string sql = "SELECT * FROM Bands";
            using (var cmd = new SQLiteCommand(sql, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    bands.Add(MapBand(reader));
            }
            return bands;
        }

        public Band GetById(int id)
        {
            string sql = "SELECT * FROM Bands WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var band = MapBand(reader);
                        band.Members = GetMembersByBandId(band.Id);
                        return band;
                    }
                }
            }
            return null;
        }

        public void Add(Band band)
        {
            string sql = @"INSERT INTO Bands (Name, Genre, FormationDate, Description)
                           VALUES (@Name, @Genre, @FormationDate, @Description)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Name", band.Name);
                cmd.Parameters.AddWithValue("@Genre", band.Genre);
                cmd.Parameters.AddWithValue("@FormationDate", band.FormationDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Description", band.Description ?? "");
                cmd.ExecuteNonQuery();
                band.Id = (int)new SQLiteCommand("SELECT last_insert_rowid()", _conn).ExecuteScalar();
            }
        }

        public void Update(Band band)
        {
            string sql = @"UPDATE Bands SET Name=@Name, Genre=@Genre,
                           FormationDate=@FormationDate, Description=@Description
                           WHERE Id=@Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Name", band.Name);
                cmd.Parameters.AddWithValue("@Genre", band.Genre);
                cmd.Parameters.AddWithValue("@FormationDate", band.FormationDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Description", band.Description ?? "");
                cmd.Parameters.AddWithValue("@Id", band.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Bands WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Member> GetMembersByBandId(int bandId)
        {
            var members = new List<Member>();
            string sql = @"SELECT m.* FROM Members m
                           INNER JOIN BandMembers bm ON m.Id = bm.MemberId
                           WHERE bm.BandId = @BandId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        members.Add(MapMember(reader));
                }
            }
            return members;
        }

        private Band MapBand(SQLiteDataReader r) => new Band
        {
            Id = Convert.ToInt32(r["Id"]),
            Name = r["Name"].ToString(),
            Genre = r["Genre"].ToString(),
            FormationDate = DateTime.Parse(r["FormationDate"].ToString()),
            Description = r["Description"].ToString()
        };

        private Member MapMember(SQLiteDataReader r) => new Member
        {
            Id = Convert.ToInt32(r["Id"]),
            FullName = r["FullName"].ToString(),
            Role = r["Role"].ToString(),
            JoinDate = DateTime.Parse(r["JoinDate"].ToString()),
            PhotoPath = r["PhotoPath"].ToString(),
            IsActive = Convert.ToBoolean(r["IsActive"])
        };
    }
}