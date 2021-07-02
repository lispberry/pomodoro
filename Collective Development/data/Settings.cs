using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collective_Development.data
{
    public class Settings
    {
        public int DefaultDelayTime { get; set; }
        public bool BlockKeyBoard { get; set; }
        public bool AddSound { get; set; }

        public static bool Exists(string login)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT COUNT(*) from settings WHERE login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);

                return ((Int64)cmd.ExecuteScalar()) == 1;
            }
        }

        public static Settings GetSettings(string login)
        {
            if (!Exists(login))
            {
                using (var conn = new NpgsqlConnection(Constants.ConnectionString))
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = "INSERT INTO settings (login) VALUES (@login)"
                    };
                    cmd.Parameters.AddWithValue("login", login);

                    cmd.ExecuteNonQuery();
                }
            }

            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT addsound, defaultdelaytime, blockkeyboard from settings WHERE login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Settings()
                    {
                        AddSound = (bool)reader[0],
                        DefaultDelayTime = (int)reader[1],
                        BlockKeyBoard = (bool)reader[2]
                    };
                } else
                {
                    return null;
                }
            }
        }

        public static void Update(string login, Settings settings)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "UPDATE settings SET addsound=@AddSound, defaultdelaytime=@DefaultDelayTime, blockkeyboard=@BlockKeyBoard WHERE login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("AddSound", settings.AddSound);
                cmd.Parameters.AddWithValue("DefaultDelayTime", settings.DefaultDelayTime);
                cmd.Parameters.AddWithValue("BlockKeyBoard", settings.BlockKeyBoard);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
