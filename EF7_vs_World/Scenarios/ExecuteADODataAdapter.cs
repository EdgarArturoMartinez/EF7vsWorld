using System.Diagnostics;
using EF7_vs_World.HandlerADO;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace EF7_vs_World.Scenarios
{
    class ExecuteADODataAdapter : DataBaseHandler
    {
        public void ExecuteADODataAdapters(int totalRows)
        {
            Stopwatch timeMeasure = new Stopwatch();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    timeMeasure.Start();
                    sqlConnection.Open();

                    string query = $"SELECT Top({totalRows}) " +
                        "p.Name, p.ProductNumber, th.*, tha.* " +
                        "FROM Production.TransactionHistory th " +
                        "INNER JOIN Production.Product p ON (P.ProductID = th.ProductID) " +
                        "INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    System.Data.DataSet dataSet = new System.Data.DataSet();
                    dataAdapter.Fill(dataSet);

                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in ADO.Net With Data Adapters : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                    ExecuteCreatedBenchmarkLog objexecuteCreatedBenchmarkLog = new ExecuteCreatedBenchmarkLog();
                    objexecuteCreatedBenchmarkLog.InsertBenchmark(totalRows.ToString("#,#", CultureInfo.InvariantCulture), "ADO.Net With Data Adapters", timeMeasure.Elapsed.TotalMilliseconds);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error has occurred executing Query ADO.Net with Data Adapter : {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
