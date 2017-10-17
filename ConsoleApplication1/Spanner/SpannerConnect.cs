using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;

namespace BlackSholvesModelPricing.Spanner
{
    class SpannerConnect
    {
        public void connect()
        {
            // Initialize request connection string for database creation.
            
            string connectionString =
                $"Data Source=projects/{projectId}/instances/{instanceId}";
            // Make the request.
            using (var connection = new SpannerConnection(connectionString))
            {
                string createStatement = $"CREATE DATABASE `{databaseId}`";
                var cmd = connection.CreateDdlCommand(createStatement);
                await cmd.ExecuteNonQueryAsync();
            }
// Update connection string with Database ID for table creation.
            connectionString = connectionString + $"/databases/{databaseId}";
            using (var connection = new SpannerConnection(connectionString))
            {
                // Define create table statement for table #1.
                string createTableStatement =
                    @"CREATE TABLE Singers (
         SingerId INT64 NOT NULL,
         FirstName    STRING(1024),
         LastName STRING(1024),
         ComposerInfo   BYTES(MAX)
     ) PRIMARY KEY (SingerId)";
// Make the request.
                var cmd = connection.CreateDdlCommand(createTableStatement);
                await cmd.ExecuteNonQueryAsync();
// Define create table statement for table #2.
                createTableStatement =
                    @"CREATE TABLE Albums (
         SingerId     INT64 NOT NULL,
         AlbumId      INT64 NOT NULL,
         AlbumTitle   STRING(MAX)
     ) PRIMARY KEY (SingerId, AlbumId),
     INTERLEAVE IN PARENT Singers ON DELETE CASCADE";
                // Make the request.
                cmd = connection.CreateDdlCommand(createTableStatement);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }

    internal class connectionString
    {
    }
}
