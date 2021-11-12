using System;
using System.Data;
using ListManagement.WebApp.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ListManagement.WebApp.Data
{
    public class ItemRepository
    {
        private readonly string _connectionString;
        public ItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQLServer");
        }

        public int Insert(Item item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Items (Name, Description, EndDate, GroupId, StatusId) VALUES(@Name, @Description, @EndDate, @GroupId, @StatusId); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? id = db.Query<int>(sqlQuery, item).FirstOrDefault();
                return id.Value;
            }

        }

        public int Update(Item item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Items SET Name = @Name, Description = @Description, EndDate = @EndDate, GroupId = @GroupId, StatusId = @StatusId WHERE Id = @Id";
                db.Execute(sqlQuery, item);
                return item.Id;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Items WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<Item> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Item>("SELECT * FROM Items").ToList();
            }
        }

        /// <summary>
        /// Получение задачи по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Item>("SELECT * FROM Items WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }


        /// <summary>
        /// Получение списка задач по идентификатору группы
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<Item> GetItemsByGroupId(int groupId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Item>("SELECT * FROM Items WHERE GroupId = @groupId", new { groupId }).ToList();
            }
        }

        /// <summary>
        /// Получение списка несгруппированных задач
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<Item> GetWithoutGroup()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Item>("SELECT * FROM Items WHERE GroupId IS NULL").ToList();
            }
        }
        
    }
}

