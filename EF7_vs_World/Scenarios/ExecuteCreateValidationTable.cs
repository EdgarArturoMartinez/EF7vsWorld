using EF7_vs_World.HandlerADO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7_vs_World.Scenarios
{
    class ExecuteCreateValidationTable : DataBaseHandler
    {
        public int CheckBenchmarkTable()
        {
            int res = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    string query = $" SELECT IdTransaction " +
                        "FROM [dbo].[Benchmark.Log] ";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    return res = 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                    return res = 0;                    
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
