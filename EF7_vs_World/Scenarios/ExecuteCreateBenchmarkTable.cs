using EF7_vs_World.HandlerADO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7_vs_World.Scenarios
{
    class ExecuteCreateBenchmarkTable : DataBaseHandler
    {
        public void CreateTableBenchmark()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    string query = $" CREATE TABLE [dbo].[Benchmark.Log]( " +
                        "[IdTransaction] [int] IDENTITY(1,1) NOT NULL, " +
                        "[Rows] [nvarchar](250) NULL, " +
                        "[Scenario] [nvarchar](250) NULL, " +
                        "[Time_Elapsed] [float] NULL, " +
                        "[Date_Transaction] [datetime] NULL, " +
                        "CONSTRAINT [PK_Benchmark.Log] PRIMARY KEY CLUSTERED " +
                        "( " +
                        "[IdTransaction] ASC " +
                        ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY] " +
                        ") ON [PRIMARY] ";

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
