using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using Dapper;
using EF7_vs_World.HandlerADO;

namespace EF7_vs_World.Scenarios
{
    class ExecuteDapper : DataBaseHandler
    {

        #region Dapper500k
        public IEnumerable<dynamic> ExecuteDapperMicroORM500K()
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    timeMeasure.Start();

                    const string sql = @"
                    SELECT top(500000)
                    p.Name,
                    p.ProductNumber,
                    th.*,
                    tha.*
                    FROM Production.TransactionHistory th
                    INNER JOIN Production.Product p ON (P.ProductID = th.ProductID)
                    INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    var results = sqlConnection.Query(sql).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {500000.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Dapper Micro-ORM : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");

                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Dapper Micro-ORM : {ex.Message}");
                return null;
            }
            
        }

        #endregion

        #region Dapper1M
        public IEnumerable<dynamic> ExecuteDapperMicroORM1M()
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    timeMeasure.Start();

                    const string sql = @"
                    SELECT top(1000000)
                    p.Name,
                    p.ProductNumber,
                    th.*,
                    tha.*
                    FROM Production.TransactionHistory th
                    INNER JOIN Production.Product p ON (P.ProductID = th.ProductID)
                    INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    var results = sqlConnection.Query(sql).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {1000000.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Dapper Micro-ORM : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");

                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Dapper Micro-ORM : {ex.Message}");
                return null;
            }

        }

        #endregion

        #region Dapper5M
        public IEnumerable<dynamic> ExecuteDapperMicroORM5M()
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    timeMeasure.Start();

                    const string sql = @"
                    SELECT top(5000000)
                    p.Name,
                    p.ProductNumber,
                    th.*,
                    tha.*
                    FROM Production.TransactionHistory th
                    INNER JOIN Production.Product p ON (P.ProductID = th.ProductID)
                    INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    var results = sqlConnection.Query(sql).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {5000000.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Dapper Micro-ORM : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");

                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Dapper Micro-ORM : {ex.Message}");
                return null;
            }

        }

        #endregion

        #region Dapper10M
        public IEnumerable<dynamic> ExecuteDapperMicroORM10M()
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    timeMeasure.Start();

                    const string sql = @"
                    SELECT top(10000000)
                    p.Name,
                    p.ProductNumber,
                    th.*,
                    tha.*
                    FROM Production.TransactionHistory th
                    INNER JOIN Production.Product p ON (P.ProductID = th.ProductID)
                    INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    var results = sqlConnection.Query(sql).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {10000000.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Dapper Micro-ORM : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");

                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Dapper Micro-ORM : {ex.Message}");
                return null;
            }

        }

        #endregion

        #region Dapper50M
        public IEnumerable<dynamic> ExecuteDapperMicroORM50M()
        {
            try
            {
                Stopwatch timeMeasure = new Stopwatch();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    timeMeasure.Start();

                    const string sql = @"
                    SELECT top(50000000)
                    p.Name,
                    p.ProductNumber,
                    th.*,
                    tha.*
                    FROM Production.TransactionHistory th
                    INNER JOIN Production.Product p ON (P.ProductID = th.ProductID)
                    INNER JOIN Production.TransactionHistoryArchive tha ON (th.Quantity = tha.Quantity)";

                    var results = sqlConnection.Query(sql).ToList();
                    timeMeasure.Stop();
                    Console.WriteLine($"Total Time For {50000000.ToString("#,#", CultureInfo.InvariantCulture)} Rows in Dapper Micro-ORM : {timeMeasure.Elapsed.TotalMilliseconds.ToString("#,##0.00", CultureInfo.InvariantCulture)} ms");

                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred executing Query with Dapper Micro-ORM : {ex.Message}");
                return null;
            }

        }
        #endregion
    }
}
