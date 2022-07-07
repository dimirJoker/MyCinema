using MyCinema.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyCinema.Services
{
    public class SeatsTableActions
    {
        private static MySqlConnectionStringBuilder _connectionStringBuilder = new()
        {
            Server = "localhost",
            Database = "moviesdb",
            UserID = "root",
            Password = "root"
        };

        private static MySqlConnection _connection = new(_connectionStringBuilder.ConnectionString);

        public List<SeatModel> GetAllSeatsListByMovieId(uint id)
        {
            List<SeatModel> seatsList = new();

            using (_connection)
            {
                MySqlCommand command = new("SELECT * FROM seatstable WHERE Movie_Id = @id", _connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        seatsList.Add(new SeatModel
                        {
                            Id = (uint)reader[0],
                            Movie_Id = (uint)reader[1],
                            Seats_Row = (uint)reader[2],
                            Seat_Number = (uint)reader[3],
                            Seat_Status = (uint)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return seatsList;
        }

        public SeatModel BuySeatByIds(uint movieId, uint  seatId)
        {
            SeatModel seat = null;

            using (_connection)
            {
                MySqlCommand command = new("UPDATE seatstable SET Seat_Status = 1 WHERE Id = @id; SELECT * FROM seatstable WHERE Id = @id;", _connection);
                command.Parameters.AddWithValue("@id", seatId);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        seat = new SeatModel
                        {
                            Id = (uint)reader[0],
                            Movie_Id = (uint)reader[1],
                            Seats_Row = (uint)reader[2],
                            Seat_Number = (uint)reader[3],
                            Seat_Status = (uint)reader[4]
                        };
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return seat;
        }
    }
}