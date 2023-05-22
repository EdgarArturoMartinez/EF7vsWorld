using System.Diagnostics;
using EF7_vs_World.ModelsEF7;
using System.Globalization;

namespace EF7_vs_World.Scenarios
{
    class ExecuteLinqToSQL
    {
        public void ExecuteLinq2SQL(int totalRows)
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (var context = new AdventureWorks2019Context())
                {
                    timeMeasure.Start();
                    var query = context.TransactionHistories
                                .Join(context.Products,
                                th => th.ProductId,
                                p => p.ProductId,
                                (th, p) => new { TransactionHistories = th, Products = p })
                            .Join(context.TransactionHistoryArchives,
                                joined => joined.TransactionHistories.Quantity,
                                tha => tha.Quantity,
                                (joined, tha) => new { joined.Products.Name, joined.Products.ProductNumber, joined.TransactionHistories,  TransactionHistoryArchive = tha })
                            .Take(totalRows)
                            .ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Linq2SQL : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                    ExecuteCreatedBenchmarkLog objexecuteCreatedBenchmarkLog = new ExecuteCreatedBenchmarkLog();
                    objexecuteCreatedBenchmarkLog.InsertBenchmark(totalRows.ToString("#,#", CultureInfo.InvariantCulture), "Linq2SQL", timeMeasure.Elapsed.TotalMilliseconds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Linq2SQL: {ex.Message}");
            }
            
        }
    }
}
