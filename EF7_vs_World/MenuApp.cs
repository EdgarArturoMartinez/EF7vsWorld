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
        const int SCN1 = 10000000;
        ExecuteEF7 objExecuteEF7 = new ExecuteEF7();
        ExecuteLinqToDB objExecuteLinqToDB = new ExecuteLinqToDB();
        ExecuteLinqToSQL objExecuteLinqToSQL = new ExecuteLinqToSQL();
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
                    objExecuteLinqToDB.ExecuteLinq2DB(SCN1);
                    objExecuteLinqToSQL.ExecuteLinq2SQL(SCN1);
                    await objExecuteEF7.ExecuteEF7Query(SCN1);
                    
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
