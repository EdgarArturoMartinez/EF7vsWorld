using EF7_vs_World.HandlerADO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7_vs_World.Scenarios
{
    class ExecuteCreatedBenchmarkLog : DataBaseHandler
    {
        public void InsertBenchmark(string rows, string scenario, double time_elapsed)
        {
            string sqlRows = rows;
            string sqlScenario = scenario;
            double sqlTime_elapsed = time_elapsed;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    string query = $" INSERT INTO [dbo].[Benchmark.Log] " +
                        " ([Rows] " +
                        " ,[Scenario] " +
                        " ,[Time_Elapsed] " +
                        " ,[Date_Transaction]) " +
                        " VALUES " +
                        $" ('{sqlRows}', " +
                        $" '{sqlScenario}', " +
                        $" {sqlTime_elapsed}, " +
                        " GETDATE() ) ";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");                    
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
