using Dapper;
using Db.Models;
using Npgsql;
using PostgreSQLCopyHelper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Db
{
    public class DbClient
    {
        private string ConnectionString { get; }

        public DbClient(string connectionString)
        {
            ConnectionString = connectionString;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public Guid InsertReturningGuid(string query)
        {
            using (var connection = OpenConnection())
            {
                return connection.QuerySingleOrDefault<Guid>(query);
            }
        }

        public Guid InsertReturningGuid(string query, DynamicParameters dp)
        {
            using (var connection = OpenConnection())
            {
                return connection.QuerySingleOrDefault<Guid>(query, dp);
            }
        }

        public IEnumerable<T> Query<T>(string query)
        {
            using (var connection = OpenConnection())
            {
                return connection.Query<T>(query);
            }
        }

        public IEnumerable<T> Query<T>(string query, DynamicParameters dp)
        {
            using (var connection = OpenConnection())
            {
                return connection.Query<T>(query, dp);
            }
        }

        public T QuerySingle<T>(string query)
        {
            using (var connection = OpenConnection())
            {
                return connection.QuerySingleOrDefault<T>(query);
            }
        }

        public T QuerySingle<T>(string query, DynamicParameters dp)
        {
            using (var connection = OpenConnection())
            {
                return connection.QuerySingleOrDefault<T>(query, dp);
            }
        }

        public void Execute(string query)
        {
            using (var connection = OpenConnection())
            {
                connection.Query(query);
            }
        }

        public void Execute(string query, DynamicParameters dp)
        {
            using (var connection = OpenConnection())
            {
                connection.Query(query, dp);
            }
        }

        public void BulkCopyUserCategory(IEnumerable<UserCategory> entities)
        {
            var mapper = new PostgreSQLCopyHelper<UserCategory>("quota", "user_category")
                    .MapUUID("user_id", x => x.UserId)
                    .MapUUID("category_id", x => x.CategoryId)
                    .MapUUID("tariff_id", x => x.TariffId)
                    .MapTimeStampTz("expired_date", x => x.ExpiredDate);
            using (var connection = OpenConnection())
                mapper.SaveAll((NpgsqlConnection)connection, entities);
        }

        public void BulkCopyUserOrders(IEnumerable<UsersOrder> entities)
        {
            var mapper = new PostgreSQLCopyHelper<UsersOrder>("users", "orders")
                    .MapUUID("category_id", x => x.CategoryId)
                    .MapUUID("tariff_id", x => x.TariffId)
                    .MapUUID("user_id", x => x.UserId)
                    .MapUUID("order_id", x => x.OrderId)
                    .MapDouble("price", x => x.Price)
                    .MapTimeStampTz("created_date", x => x.CreatedDate)
                    .MapBoolean("is_completed", x => x.IsCompleted)
                    .MapBoolean("is_extended", x => x.IsExtended);
            using (var connection = OpenConnection())
                mapper.SaveAll((NpgsqlConnection)connection, entities);
        }

        private IDbConnection OpenConnection()
        {
            var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
