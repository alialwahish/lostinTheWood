using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperTest.Models;
using Microsoft.Extensions.Options;
using System;


namespace dapperTest.Factory
{
    public class UserFactory : IFactory<User>
    {
        private MySqlOptions _options;

        public UserFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            
            get
            {
                return new MySqlConnection(_options.Con);
            }
        }

        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }
        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO users(Name,Description ,Trail_Length,Elevation,Longitude,Latitude) VALUES (@Name , @Description , @Trail_Length,@Elevation,@Longitude,@Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }



        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @id", new { Id = id }).FirstOrDefault();
            }
        }






    }

}