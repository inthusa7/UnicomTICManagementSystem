using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StaffController
    {
        public async Task<List<Staff>> GetAllAsync()
        {
            var list = new List<Staff>(); 
            using (var conn = DBConfig.GetConnection())
            { 
                var cmd = new SQLiteCommand("SELECT * FROM Staffs", conn);
                using (var reader = await cmd.ExecuteReaderAsync()) 
                { while (await reader.ReadAsync())
                    { 
                        list.Add(new Staff 
                        { 
                            StaffID = Convert.ToInt32(reader["StaffID"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            JobTitle = reader["JobTitle"].ToString()
                        }); 
                    }
                }
            } 
            return list;
        }

        public async Task AddAsync(Staff staff)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Staffs (Name, Address, JobTitle) VALUES (@name, @addr, @job)", conn);
                cmd.Parameters.AddWithValue("@name", staff.Name);
                cmd.Parameters.AddWithValue("@addr", staff.Address);
                cmd.Parameters.AddWithValue("@job", staff.JobTitle);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Staff staff)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Staffs SET Name = @name, Address = @addr, JobTitle = @job WHERE StaffID = @id", conn);
                cmd.Parameters.AddWithValue("@name", staff.Name);
                cmd.Parameters.AddWithValue("@addr", staff.Address);
                cmd.Parameters.AddWithValue("@job", staff.JobTitle);
                cmd.Parameters.AddWithValue("@id", staff.StaffID);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Staffs WHERE StaffID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
