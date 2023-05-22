using System.Diagnostics;
using EF7_vs_World.HandlerADO;
using Microsoft.Data.SqlClient;
using System.Globalization;
using EF7_vs_World.ModelsEF7;

namespace EF7_vs_World.Scenarios
{
    class ExecuteADODataReader : DataBaseHandler
    {
        public void ExecuteADODataReaderWithMappings(int totalRows)
        {
            Stopwatch timeMeasure = new Stopwatch();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    timeMeasure.Start();
                    sqlConnection.Open();

                    string query = $"SELECT Top({totalRows}) " +
                        "p.Name, " +
                        "p.ProductNumber, " +
                        "th.*, " +
                        "tha.* " +
                        "FROM Production.TransactionHistory th " +
                        "INNER JOIN Production.Product p ON (P.ProductID = th.ProductID) " +
                        "INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity) ";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<ModelsEF7.TransactionHistory> transactionHistories = new List<ModelsEF7.TransactionHistory>();

                            while (reader.Read())
                            {
                                TransactionHistory transactionHistory = new TransactionHistory();
                                Product product = new Product();
                                TransactionHistoryArchive transactionHistoryArchive = new TransactionHistoryArchive();
                                product.Name = (string)reader["Name"];
                                product.ProductNumber = (string)reader["ProductNumber"];
                                transactionHistory.ProductId = (int)reader["ProductID"];
                                transactionHistoryArchive.Quantity = (int)reader["Quantity"];

                                transactionHistories.Add(transactionHistory);
                            }
                        }
                    }

                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in ADO.Net With Data Reader and Manual Mappings : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                    ExecuteCreatedBenchmarkLog objexecuteCreatedBenchmarkLog = new ExecuteCreatedBenchmarkLog();
                    objexecuteCreatedBenchmarkLog.InsertBenchmark(totalRows.ToString("#,#", CultureInfo.InvariantCulture), "ADO.Net With Data Reader and Manual Mappings", timeMeasure.Elapsed.TotalMilliseconds);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error has occurred executing Query ADO.Net with Data Reader And Manual Mappings : {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
