using EF7_vs_World.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF7_vs_World.ModelsEF7;
using System.Threading.Channels;

namespace EF7_vs_World
{
    class MenuApp
    {
        #region "TotalRows"
        const int SCN1 = 500000;
        const int SCN2 = 1000000;
        const int SCN3 = 5000000;
        const int SCN4 = 10000000;
        const int SCN5 = 50000000;
        #endregion

        #region "ObjectBuilder"
        ExecuteEF7 objExecuteEF7 = new ExecuteEF7();
        ExecuteLinqToDB objExecuteLinqToDB = new ExecuteLinqToDB();
        ExecuteLinqToSQL objExecuteLinqToSQL = new ExecuteLinqToSQL();
        ExecuteADODataAdapter objExecuteADODataAdapter = new ExecuteADODataAdapter();
        ExecuteADODataReader objExecuteADODataReader = new ExecuteADODataReader();
        #endregion
        public async Task<bool> MainMenu()
        {
            Console.WriteLine($"**********************************************");
            Console.WriteLine($"   Welcome to Entity Framework vs World App   ");
            Console.WriteLine($"----------------------------------------------\n");
            Console.WriteLine($"\r\nBenchmarking report in Miliseconds for : ");
            Console.WriteLine($"1.  500K Rows");
            Console.WriteLine($"2.  1M   Rows");
            Console.WriteLine($"3.  5M   Rows");
            Console.WriteLine($"4.  10M  Rows");
            Console.WriteLine($"5.  50M  Rows");
            Console.WriteLine($"0.  Exit App \n");
            int optionMainMenu = Convert.ToInt32(Console.ReadLine());
            switch (optionMainMenu)
            {
                case 0:
                    Console.WriteLine($"You have finished the App.!!");
                    return false;
                case 1:
                    objExecuteADODataAdapter.ExecuteADODataAdapters(SCN1);
                    objExecuteADODataReader.ExecuteADODataReaderWithMappings(SCN1);
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN1);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN1);                    
                    await objExecuteEF7.ExecuteEF7Query(SCN1);
                    
                    return true;
                case 2:
                    objExecuteADODataAdapter.ExecuteADODataAdapters(SCN2);
                    objExecuteADODataReader.ExecuteADODataReaderWithMappings(SCN2);
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN2);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN2);                    
                    await objExecuteEF7.ExecuteEF7Query(SCN2);

                    return true;
                case 3:
                    objExecuteADODataAdapter.ExecuteADODataAdapters(SCN3);
                    objExecuteADODataReader.ExecuteADODataReaderWithMappings(SCN3);
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN3);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN3);                    
                    await objExecuteEF7.ExecuteEF7Query(SCN3);

                    return true;
                case 4:
                    objExecuteADODataAdapter.ExecuteADODataAdapters(SCN4);
                    objExecuteADODataReader.ExecuteADODataReaderWithMappings(SCN4);
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN4);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN4);                    
                    await objExecuteEF7.ExecuteEF7Query(SCN4);

                    return true;
                case 5:
                    objExecuteADODataAdapter.ExecuteADODataAdapters(SCN5);
                    objExecuteADODataReader.ExecuteADODataReaderWithMappings(SCN5);
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN5);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN5);                    
                    await objExecuteEF7.ExecuteEF7Query(SCN5);

                    return true;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine($"You have choosen a wrong option.!!");
                    return true;
            }
        }
    }
}
