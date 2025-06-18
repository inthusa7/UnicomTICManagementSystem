using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class UserController
    {
        private readonly DBConfig config = new DBConfig();

        public async Task<User> ValidateStudentAsync(string name, string studentId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Students WHERE Name = @name AND StudentID = @id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", studentId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(reader["StudentID"]),
                            UserName = reader["Name"].ToString(),
                            Password = reader["StudentID"].ToString(),
                            Role = "Student"
                        };
                    }
                }
            }


            return null;
        }
        

        public async Task<User> ValidateLecturerAsync(string name, string id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Lecturers WHERE Name = @name AND LecturerID = @id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(reader["LecturerID"]),
                            UserName = reader["Name"].ToString(),
                            Role = "Lecturer"
                        };
                    }
                }
            }

            return null;
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Users WHERE Username = @username AND Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }
        public async Task<User> ValidateStaffAsync(string name, string staffId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Staffs WHERE Name = @name AND StaffID = @id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", staffId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(reader["StaffID"]),
                            UserName = reader["Name"].ToString(),
                            Role = "Staff"
                        };
                    }
                }
            }
            return null;
        }
    }
}
