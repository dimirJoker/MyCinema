using MyCinema.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyCinema.Services
{
    public class MoviesTableActions
    {
        private static MySqlConnectionStringBuilder _connectionStringBuilder = new()
        {
            Server = "localhost",
            Database = "moviesdb",
            UserID = "root",
            Password = "root"
        };

        private static MySqlConnection _connection = new(_connectionStringBuilder.ConnectionString);

        public List<MovieModel> GetAllMovies()
        {
            List<MovieModel> moviesList = new();

            using (_connection)
            {
                MySqlCommand command = new("SELECT * FROM moviestable", _connection);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        moviesList.Add(new MovieModel
                        {
                            Id = (uint)reader[0],
                            Name = (string)reader[1],
                            Description = (string)reader[2],
                            Duration = (TimeSpan)reader[3],
                            Thumbnail = (string)reader[4],
                            Price = (float)reader[5],
                            Genre = (string)reader[6]
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return moviesList;
        }
    }
}