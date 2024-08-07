using System;
using System.Data.SqlClient;

namespace DatabaseOperation;

class Program
{
    static void Main(string[] args)
    {
        var sqlHelper = new SQLHelper();
        string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=rentaride_;User Id=rentaride_;Password=pass123;Trusted_Connection=False;TrustServerCertificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Disable foreign key constraints
            sqlHelper.DisableForeignKeyConstraints(connection);

            // Step 2: Drop all tables
            sqlHelper.DropAllTables(connection);

            // Step 3: Optionally, re-enable foreign key constraints (if needed)
            // sqlHelper.ReenableForeignKeyConstraints(connection);
        }
    }
}
