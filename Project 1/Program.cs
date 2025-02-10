// TO DOS:
//  - Rename Root and put all json handling into json package? - may already be done?
//  - Clean up code - methods to print menu, handle menu options?, print intro message, tasks in each of the switch statements
//  - Any other error/unexpected input that might need to be handled? give option to re-enter URL?
//  - Add comments - adequately detailed module operations and maintenance history as well as function prologue, annotated throughout
//  - Check that methods are less than 50 lines each
//  - Create documentation - model of classes and relationships

using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Welcome to the NFL Game Stats Processor!\n");

        JsonHandler jsonHandler = new JsonHandler();
        MenuHandler menuHandler = new MenuHandler(jsonHandler);

        await menuHandler.LoadJsonData();
        menuHandler.ShowMenu();
    }
}
