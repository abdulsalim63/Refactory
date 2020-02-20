using System;
using Npgsql;

namespace Week3DI
{
    public interface IDatabase
    {
        int Create(UserRequest user);
        void Read();
        void Update();
        void Delete();
    }

    public class Database : IDatabase
    {
        NpgsqlConnection _connection;

        public Database(NpgsqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }


    }
}
