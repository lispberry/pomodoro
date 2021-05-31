using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collective_Development.data
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }

        public void Update()
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "UPDATE \"user\" SET name=@name, surname=@surname, age=@age WHERE login = @login"
                };
                cmd.Parameters.AddWithValue("login", Login);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("surname", Surname);
                cmd.Parameters.AddWithValue("age", Age);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
