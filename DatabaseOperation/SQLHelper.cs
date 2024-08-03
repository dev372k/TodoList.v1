using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperation
{
    public class SQLHelper
    {
        public void DisableForeignKeyConstraints(SqlConnection connection)
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

        public void DropAllTables(SqlConnection connection)
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

        public void ReenableForeignKeyConstraints(SqlConnection connection)
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
}
