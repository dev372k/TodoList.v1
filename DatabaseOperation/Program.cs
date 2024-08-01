using System;
using System.Data.SqlClient;

namespace DatabaseOperation;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=alishnadb_;User Id=alishnadb_;Password=pass123;Trusted_Connection=False;TrustServerCertificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Disable foreign key constraints
            DisableForeignKeyConstraints(connection);

            // Step 2: Drop all tables
            DropAllTables(connection);

            // Step 3: Optionally, re-enable foreign key constraints (if needed)
            // ReenableForeignKeyConstraints(connection);
        }
    }

    static void DisableForeignKeyConstraints(SqlConnection connection)
    {
        string disableConstraintsQuery = @"
                DECLARE @sql NVARCHAR(MAX) = N'';
                SELECT @sql += 'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + ' NOCHECK CONSTRAINT ' + QUOTENAME(name) + ';'
                FROM sys.foreign_keys;
                EXEC sp_executesql @sql;";

        using (SqlCommand command = new SqlCommand(disableConstraintsQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    static void DropAllTables(SqlConnection connection)
    {
        string dropTablesQuery = @"
                DECLARE @sql NVARCHAR(MAX) = N'';
                SELECT @sql += 'DROP TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(object_id)) + '.' + QUOTENAME(name) + ';'
                FROM sys.tables;
                EXEC sp_executesql @sql;";

        using (SqlCommand command = new SqlCommand(dropTablesQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    static void ReenableForeignKeyConstraints(SqlConnection connection)
    {
        string enableConstraintsQuery = @"
                DECLARE @sql NVARCHAR(MAX) = N'';
                SELECT @sql += 'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + ' CHECK CONSTRAINT ' + QUOTENAME(name) + ';'
                FROM sys.foreign_keys;
                EXEC sp_executesql @sql;";

        using (SqlCommand command = new SqlCommand(enableConstraintsQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
