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
    internal class RoomController
    {
        public async Task<List<Room>> GetAllAsync()
        {
            var list = new List<Room>();
            using (var conn = DBConfig.GetConnection()) 
            { 
                var cmd = new SQLiteCommand("SELECT * FROM Rooms", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    { 
                        list.Add(new Room
                        { 
                            RoomId = reader.GetInt32(0), 
                            RoomName = reader.GetString(1),
                            RoomType = reader.GetString(2)
                        });
                    } 
                }
            } 
            return list;
        }

        public async Task AddAsync(Room room)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Rooms (RoomName, RoomType) VALUES (@name, @type)", conn);
                cmd.Parameters.AddWithValue("@name", room.RoomName);
                cmd.Parameters.AddWithValue("@type", room.RoomType);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Room room)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Rooms SET RoomName = @name, RoomType = @type WHERE RoomID = @id", conn);
                cmd.Parameters.AddWithValue("@name", room.RoomName);
                cmd.Parameters.AddWithValue("@type", room.RoomType);
                cmd.Parameters.AddWithValue("@id", room.RoomId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DBConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Rooms WHERE RoomID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }


    }


}