using Dapper;
using microservice.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Transactions;

namespace microservice.Models
{
    /// <summary>
    /// User Database Initialization Class
    /// </summary>
    public class Initializer
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializer class constructor
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public Initializer(string connectionString) => this.connectionString = connectionString;

        /// <summary>
        /// Creates a user database and table. Used Dapper
        /// </summary>
        public void InitializeDb()
        {
            using SqlConnection db = new SqlConnection(connectionString);

            db.Open();

            db.Query("BEGIN\r\n" +
                "IF DB_ID('Auth_For_Online_shop') IS NOT NULL\r\n" +
                "BEGIN\r\n" +
                "ALTER DATABASE [Auth_For_Online_shop] SET SINGLE_USER WITH ROLLBACK IMMEDIATE\r\n" +
                "DROP DATABASE[Auth_For_Online_shop]\r\n" +
                "END\r\n" +
            "END\r\n" +
                "CREATE DATABASE [Auth_For_Online_shop]");

            using DbTransaction transaction = db.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);

            try
            {   
                db.Execute("USE Auth_For_Online_shop\r\n" +
                    "BEGIN\r\n" +
                    "CREATE TABLE Users (\r\n" +
                    "Id INT PRIMARY KEY IDENTITY (1, 1),\r\n" +
                    "Email VARCHAR(100),\r\n" +
                    "Password VARCHAR(100),\r\n" +
                    "IsAdmin BIT\r\n" +
                    ")\r\n" +
                    "END", transaction: transaction);

                db.Execute("USE Auth_For_Online_shop\r\n" +
                    "INSERT INTO Users\r\n" +
                    "(Email, Password, IsAdmin)\r\n" +
                    "VALUES ('admin@email.com','admin', 1), ('user@email.com','123456', 0)", transaction: transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Debug.WriteLine($"!!! Initializer Exeption:{ex.Message}");
            }
        }
    }
}

