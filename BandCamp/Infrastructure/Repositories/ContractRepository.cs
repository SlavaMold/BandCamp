using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly SQLiteConnection _conn;

        public ContractRepository()
        {
            _conn = DatabaseConnection.Instance.Connection;
        }

        public List<Contract> GetAll()
        {
            var list = new List<Contract>();
            string sql = "SELECT * FROM Contracts ORDER BY StartDate DESC";
            using (var cmd = new SQLiteCommand(sql, _conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(MapContract(reader));
            }
            return list;
        }

        public Contract GetById(int id)
        {
            string sql = "SELECT * FROM Contracts WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return MapContract(reader);
                }
            }
            return null;
        }

        public List<Contract> GetContractsByBandId(int bandId)
        {
            var list = new List<Contract>();
            string sql = "SELECT * FROM Contracts WHERE BandId = @BandId ORDER BY StartDate DESC";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BandId", bandId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapContract(reader));
                }
            }
            return list;
        }

        public List<Contract> GetContractsByType(ContractType type)
        {
            var list = new List<Contract>();
            string sql = "SELECT * FROM Contracts WHERE Type = @Type ORDER BY StartDate DESC";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Type", (int)type);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapContract(reader));
                }
            }
            return list;
        }

        public void Add(Contract contract)
        {
            string sql = @"INSERT INTO Contracts 
                (Type, StudioName, ResponsiblePerson, StartDate, EndDate, 
                 Payment, BandId, BandName, ProductName)
                VALUES 
                (@Type, @StudioName, @ResponsiblePerson, @StartDate, @EndDate,
                 @Payment, @BandId, @BandName, @ProductName)";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Type", (int)contract.Type);
                cmd.Parameters.AddWithValue("@StudioName", contract.StudioName ?? "");
                cmd.Parameters.AddWithValue("@ResponsiblePerson", contract.ResponsiblePerson ?? "");
                cmd.Parameters.AddWithValue("@StartDate", contract.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", contract.EndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Payment", contract.Payment);
                cmd.Parameters.AddWithValue("@BandId", contract.BandId);
                cmd.Parameters.AddWithValue("@BandName", contract.BandName ?? "");
                cmd.Parameters.AddWithValue("@ProductName", contract.ProductName ?? "");
                cmd.ExecuteNonQuery();
                contract.Id = (int)(long)new SQLiteCommand(
                    "SELECT last_insert_rowid()", _conn).ExecuteScalar();
            }
        }

        public void Update(Contract contract)
        {
            string sql = @"UPDATE Contracts SET
                Type=@Type, StudioName=@StudioName, ResponsiblePerson=@ResponsiblePerson,
                StartDate=@StartDate, EndDate=@EndDate, Payment=@Payment,
                BandId=@BandId, BandName=@BandName, ProductName=@ProductName
                WHERE Id=@Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Type", (int)contract.Type);
                cmd.Parameters.AddWithValue("@StudioName", contract.StudioName ?? "");
                cmd.Parameters.AddWithValue("@ResponsiblePerson", contract.ResponsiblePerson ?? "");
                cmd.Parameters.AddWithValue("@StartDate", contract.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", contract.EndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Payment", contract.Payment);
                cmd.Parameters.AddWithValue("@BandId", contract.BandId);
                cmd.Parameters.AddWithValue("@BandName", contract.BandName ?? "");
                cmd.Parameters.AddWithValue("@ProductName", contract.ProductName ?? "");
                cmd.Parameters.AddWithValue("@Id", contract.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Contracts WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private Contract MapContract(SQLiteDataReader r) => new Contract
        {
            Id = Convert.ToInt32(r["Id"]),
            Type = (ContractType)Convert.ToInt32(r["Type"]),
            StudioName = r["StudioName"].ToString(),
            ResponsiblePerson = r["ResponsiblePerson"].ToString(),
            StartDate = DateTime.Parse(r["StartDate"].ToString()),
            EndDate = DateTime.Parse(r["EndDate"].ToString()),
            Payment = Convert.ToDecimal(r["Payment"]),
            BandId = Convert.ToInt32(r["BandId"]),
            BandName = r["BandName"].ToString(),
            ProductName = r["ProductName"].ToString()
        };
    }
}