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
                                (joined, tha) => new { joined.TransactionHistories, joined.Products, TransactionHistoryArchive = tha })
                            .Take(totalRows)
                            .ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows} Rows in Linq2SQL : {timeMeasure.Elapsed.TotalMilliseconds} ms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query for Linq2SQL: {ex.Message}");
            }
            
        }
    }
}
