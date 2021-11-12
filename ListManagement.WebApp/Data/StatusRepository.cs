using System;
using System.Data;
using ListManagement.WebApp.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ListManagement.WebApp.Data
{
    public class StatusRepository
    {
        private readonly string _connectionString;
        public StatusRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQLServer");
        }

        public List<Status> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Status>("SELECT * FROM Statuses").ToList();
            }
        }

        
        
    }
}

