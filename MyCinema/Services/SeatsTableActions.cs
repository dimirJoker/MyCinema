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

        public List<SeatModel> GetAllSeatsByMovieId(uint id)
        {
            List<SeatModel> seatsList = new();

            using (_connection)
            {
                MySqlCommand command = new($"SELECT * FROM movie_{id}_seats_table", _connection);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        seatsList.Add(new SeatModel
                        {
                            Id = (uint)reader[0],
                            Row = (uint)reader[1],
                            Status = (uint)reader[2]
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return seatsList;
        }
    }
}