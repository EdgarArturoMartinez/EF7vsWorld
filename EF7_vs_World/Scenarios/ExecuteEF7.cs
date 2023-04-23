using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EF7_vs_World.ModelsEF7;
using Microsoft.EntityFrameworkCore;

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
                            (joined, tha) => new { joined.TransactionHistories, joined.Products, TransactionHistoryArchive = tha })
                        .Take(totalRows)
                        .ToListAsync();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows} Rows in Entity Framework7 : {timeMeasure.Elapsed.TotalMilliseconds} ms");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"An error has occurred executing Query for Entity Framework 7: {ex.Message}"); ;
            }
        }
    }
}
