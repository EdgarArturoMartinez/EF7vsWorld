using System.Diagnostics;
using EF7_vs_World.ModelsEF7;
using Microsoft.EntityFrameworkCore;

Stopwatch timeMeasure = new Stopwatch();

using (var context = new AdventureWorks2019Context())
{
    timeMeasure.Start();

    //Code
    //await context.Products.Take(100).ToListAsync();
    await context.TransactionHistories
        .Join(context.Products,
            th => th.ProductId,
            p => p.ProductId,
            (th, p) => new { TransactionHistories = th, Products = p })
        .Join(context.TransactionHistoryArchives,
            joined => joined.TransactionHistories.Quantity,
            tha => tha.Quantity,
            (joined, tha) => new { joined.TransactionHistories, joined.Products, TransactionHistoryArchive = tha })
        .Take(1000000)
        .ToListAsync();

    timeMeasure.Stop();

    Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms");
}



