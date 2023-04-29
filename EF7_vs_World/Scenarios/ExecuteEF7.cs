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
    class ExecuteEF7
    {
        public async Task ExecuteEF7Query(int totalRows)
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (var context = new AdventureWorks2019Context())
                {
                    timeMeasure.Start();
                    var results = await context.TransactionHistories
                        .Join(context.Products,
                            th => th.ProductId,
                            p => p.ProductId,
                            (th, p) => new { TransactionHistories = th, Products = p })
                        .Join(context.TransactionHistoryArchives,
                            joined => joined.TransactionHistories.Quantity,
                            tha => tha.Quantity,
                            (joined, tha) => new { joined.Products.Name, joined.Products.ProductNumber, joined.TransactionHistories,  TransactionHistoryArchive = tha })
                        .Take(totalRows)
                        .ToListAsync();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Entity Framework7 Without Extra Settings : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"An error has occurred executing Query with Entity Framework 7 Without Extra Settings: {ex.Message}"); ;
            }
        }
    }
}
