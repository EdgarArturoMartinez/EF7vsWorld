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
                                    th.ProductId,
                                    tha.Quantity
                                };
                    var result = query.Take(totalRows).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {totalRows} Rows in Linq2DB : {timeMeasure.Elapsed.TotalMilliseconds} ms");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error has occurred executing Query for Linq2DB: {ex.Message}");
            }            
        }
    }
}
