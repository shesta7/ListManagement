using System;
using System.Data;
using Dapper;
using ListManagement.WebApp.Models;
using Microsoft.Data.SqlClient;

namespace ListManagement.WebApp.Data
{
    public class GroupRepository
    {
        private readonly string _connectionString;

        public GroupRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQLServer");
        }

        public int Insert(Group group)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Groups (Name) VALUES(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? id = db.Query<int>(sqlQuery, group).FirstOrDefault();
                return id.Value;
            }

        }

        public int Update(Group group)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Group SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, group);
                return group.Id;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Groups WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<Group> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Group>("SELECT * FROM Groups").ToList();
            }
        }

        /// <summary>
        /// Получение задачи по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Group GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Group>("SELECT * FROM Groups WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
    }
}

