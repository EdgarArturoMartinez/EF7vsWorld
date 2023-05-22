using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EF7_vs_World.ModelsEF7;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EF7_vs_World.Scenarios
{
    class ExecuteEF7AsNoTracking
    {
        public async Task ExecuteEF7WithAsNoTracking(int totalRows)
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (var context = new AdventureWorks2019Context())
                {
                    timeMeasure.Start();
                    var results = await context.TransactionHistories
                        .AsNoTracking()
                            .Join(context.Products, 
                                th => th.ProductId, 
                                p => p.ProductId, 
                                (th, p) => new { TransactionHistory = th, Product = p })
                            .Join(context.TransactionHistoryArchives, 
                                joined => joined.TransactionHistory.Quantity, 
                                tha => tha.Quantity, 
                                (joined, tha) => new { joined.Product.Name, joined.Product.ProductNumber, joined.TransactionHistory.ProductId, tha.Quantity })
                    .Take(totalRows)                    
                    .ToListAsync();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Entity Framework7 With As No Tracking : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                    ExecuteCreatedBenchmarkLog objexecuteCreatedBenchmarkLog = new ExecuteCreatedBenchmarkLog();
                    objexecuteCreatedBenchmarkLog.InsertBenchmark(totalRows.ToString("#,#", CultureInfo.InvariantCulture), "Entity Framework7 With As No Tracking", timeMeasure.Elapsed.TotalMilliseconds);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"An error has occurred executing Query with Entity Framework 7 With As No Tracking: {ex.Message}"); ;
            }
        }
    }
}
