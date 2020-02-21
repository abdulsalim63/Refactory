using System;
using Npgsql;
using Week3DI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Week3DI
{
    public interface IDatabase
    {
        int Create(Contact contact);
        List<Contact> Read(object id=null);
        List<Contact> Update(int id, Contact contact);
        List<Contact> Delete(int id);
    }

    public class Database : IDatabase
    {
        NpgsqlConnection _connection;

        public Database(NpgsqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public int Create(Contact contact)
        {
            var command = new NpgsqlCommand("INSERT INTO contact(username, pass, email, fullname) VALUES(@username, @pass, @email, @fullname) RETURNING id", _connection);
                command.Parameters.AddWithValue("@username", contact.Username);
                command.Parameters.AddWithValue("@pass", contact.Pass);
                command.Parameters.AddWithValue("@email", contact.Email);
                command.Parameters.AddWithValue("@fullname", contact.Full_Name);

            command.Prepare();
            var result = command.ExecuteScalar();
            return (int)result;
        }

        public List<Contact> Read(object Id = null)
        {
            var result = new List<Contact>();
            NpgsqlCommand command;
            if (Id == null)
            {
                command = new NpgsqlCommand("SELECT * FROM contact", _connection);
            }
            else
            {
                command = new NpgsqlCommand($"SELECT * FROM contact WHERE id = {Id}", _connection);
            }
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Contact { Id = (int)reader[0], Username = (string)reader[1], Pass = (string)reader[2], Email = (string)reader[3], Full_Name = (string)reader[4] });
                }
            }
            return result;
        }

        public List<Contact> Delete(int id)
        {
            var retur = Read(id);
            var command = new NpgsqlCommand($"DELETE FROM contact WHERE id = {id}", _connection);
            var result = command.ExecuteNonQuery();
            return retur;
        }

        public List<Contact> Update(int id, Contact contact)
        {
            var username = (contact.Username == null) ? null : $"username = {contact.Username},";
            var pass = (contact.Pass == null) ? null : $"pass = {contact.Pass},";
            var email = (contact.Email == null) ? null : $"email = {contact.Email},";
            var fullname = (contact.Full_Name == null) ? null : $"fullname = {contact.Full_Name}";
            var command = new NpgsqlCommand($"UPDATE contact SET {username} {pass} {email} {fullname} WHERE id = {id}", _connection);

            var result = command.ExecuteNonQuery();
            return new List<Contact>() { contact};
        }
    }
}
