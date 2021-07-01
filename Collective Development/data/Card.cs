using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collective_Development.data
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }

        public static IEnumerable<Card> GetCards(string login)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT id, min, sec, name from card where login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Card()
                    {
                        Id = (int)reader[0],
                        Min = (int)reader[1],
                        Sec = (int)reader[2],
                        Name = (string)reader[3]
                    };
                }
            }
        }

        public static void RemoveCards(string login)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "DELETE FROM card where login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);
                cmd.ExecuteNonQuery();
            }
        }

        public static int AddCard(string login, Card card)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "INSERT INTO card (min, sec, name, login) VALUES (@min, @sec, @name, @login) RETURNING id"
                };
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("min", card.Min);
                cmd.Parameters.AddWithValue("sec", card.Sec);
                cmd.Parameters.AddWithValue("name", card.Name);

                return (int)cmd.ExecuteScalar();
            }
        }

        public static void AddCards(string login, IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                AddCard(login, card);
            }
        }
    }
}
