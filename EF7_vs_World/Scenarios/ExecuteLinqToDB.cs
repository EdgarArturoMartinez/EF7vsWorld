using System.Diagnostics;
using EF7_vs_World.ModelsEF7;
using System.Globalization;

namespace EF7_vs_World.Scenarios
{
    class ExecuteLinqToDB
    {
        public void ExecuteLinq2DB(int totalRows)
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (var context = new AdventureWorks2019Context())
                {
                    timeMeasure.Start();
                    var query = from th in context.TransactionHistories
                                join p in context.Products on th.ProductId equals p.ProductId
                                join tha in context.TransactionHistoryArchives on th.Quantity equals tha.Quantity
                                select new
                                {
                                    p.Name,
                                    p.ProductNumber,
                                    th,
                                    tha
                                };
                    var result = query.Take(totalRows).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Linq2DB : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                    ExecuteCreatedBenchmarkLog objexecuteCreatedBenchmarkLog = new ExecuteCreatedBenchmarkLog();
                    objexecuteCreatedBenchmarkLog.InsertBenchmark(totalRows.ToString("#,#", CultureInfo.InvariantCulture), "Linq2DB", timeMeasure.Elapsed.TotalMilliseconds);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error has occurred executing Query with Linq2DB: {ex.Message}");
            }            
        }
    }
}
