using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SQLiteConnection _conn;

        public MemberRepository()
        {
            _conn = DatabaseConnection.Instance.Connection;
        }

        public List<Member> GetAll()
        {
            var members = new List<Member>();
            string sql = "SELECT * FROM Members";
            using (var cmd = new SQLiteCommand(sql, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    members.Add(MapMember(reader));
            }
            return members;
        }

        public Member GetById(int id)
        {
            string sql = "SELECT * FROM Members WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return MapMember(reader);
                }
            }
            return null;
        }

        public void Add(Member member)
        {
            string sql = @"INSERT INTO Members (FullName, Role, JoinDate, PhotoPath, IsActive)
                           VALUES (@FullName, @Role, @JoinDate, @PhotoPath, @IsActive)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Role", member.Role);
                cmd.Parameters.AddWithValue("@JoinDate", member.JoinDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@PhotoPath", member.PhotoPath ?? "");
                cmd.Parameters.AddWithValue("@IsActive", member.IsActive ? 1 : 0);
                cmd.ExecuteNonQuery();
                member.Id = (int)new SQLiteCommand("SELECT last_insert_rowid()", _conn).ExecuteScalar();
            }
        }

        public void Update(Member member)
        {
            string sql = @"UPDATE Members SET FullName=@FullName, Role=@Role,
                           JoinDate=@JoinDate, PhotoPath=@PhotoPath, IsActive=@IsActive
                           WHERE Id=@Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@FullName", member.FullName);
                cmd.Parameters.AddWithValue("@Role", member.Role);
                cmd.Parameters.AddWithValue("@JoinDate", member.JoinDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@PhotoPath", member.PhotoPath ?? "");
                cmd.Parameters.AddWithValue("@IsActive", member.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Members WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddMemberToBand(int memberId, int bandId)
        {
            string sql = @"INSERT OR IGNORE INTO BandMembers (BandId, MemberId)
                           VALUES (@BandId, @MemberId)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveMemberFromBand(int memberId, int bandId)
        {
            string sql = @"DELETE FROM BandMembers
                           WHERE BandId=@BandId AND MemberId=@MemberId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Band> GetBandsByMemberId(int memberId)
        {
            var bands = new List<Band>();
            string sql = @"SELECT b.* FROM Bands b
                           INNER JOIN BandMembers bm ON b.Id = bm.BandId
                           WHERE bm.MemberId = @MemberId";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        bands.Add(new Band
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Genre = reader["Genre"].ToString()
                        });
                }
            }
            return bands;
        }

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