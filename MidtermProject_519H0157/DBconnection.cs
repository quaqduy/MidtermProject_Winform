using System;
using System.Data.SqlClient;

namespace MidtermProject_519H0157
{
    internal class DBconnection
    {
        private SqlConnection conn;
        private string connectionString;

        // Constructor to initialize with the connection string
        public DBconnection()
        {
            // Set up the connection string for the database
            connectionString = @"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }

        // Method to open the connection
        public SqlConnection OpenConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open(); // Open connection if it's closed
                }
            }
            catch (SqlException ex)
            {
                // Catch any connection errors
                Console.WriteLine("Database connection error: " + ex.Message);
            }
            return conn;
        }

        // Method to close the connection
        public void CloseConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close(); // Close connection if it's open
                }
            }
            catch (SqlException ex)
            {
                // Catch any errors when closing the connection
                Console.WriteLine("Database disconnection error: " + ex.Message);
            }
        }

        // Method to execute queries that do not return results (e.g., INSERT, UPDATE, DELETE)
        public void ExecuteQuery(string query)
        {
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    OpenConnection(); // Open connection
                    command.ExecuteNonQuery(); // Execute the query
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Query execution error: " + ex.Message);
                }
                finally
                {
                    CloseConnection(); // Close the connection after execution
                }
            }
        }

        // Method to execute queries that return results (e.g., SELECT)
        public SqlDataReader ExecuteReader(string query)
        {
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = null;

            try
            {
                OpenConnection(); // Open connection
                reader = command.ExecuteReader(); // Execute the query and get the results
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Query execution error: " + ex.Message);
            }

            return reader;
        }
    }
}
