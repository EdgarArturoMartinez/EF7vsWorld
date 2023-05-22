using System.Diagnostics;
using EF7_vs_World;
using EF7_vs_World.ModelsEF7;
using EF7_vs_World.Scenarios;
using Microsoft.EntityFrameworkCore;

ExecuteCreateValidationTable objexecuteCreateValidationTable = new ExecuteCreateValidationTable();
int validationTable = objexecuteCreateValidationTable.CheckBenchmarkTable();
if (validationTable == 1)
{
    MenuApp objMenuApp = new MenuApp();
    await objMenuApp.MainMenu();
}
else if (validationTable == 0)
{
    ExecuteCreateBenchmarkTable objexecuteCreateBenchmarkTable = new ExecuteCreateBenchmarkTable();
    objexecuteCreateBenchmarkTable.CreateTableBenchmark();

    MenuApp objMenuApp = new MenuApp();
    await objMenuApp.MainMenu();
}
















