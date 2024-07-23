using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CatWorx.BadgeMaker
{

class Program
{
    async static Task Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Please enter 'Y' to start entering employees.");
        string answer = Console.ReadLine() ?? "";

        var yesAnswer = new string[]{"Y", "y", "yes", "Yes", "YES"};

        if(yesAnswer.Contains(answer))
        {
            employees = PeopleFetcher.GetEmployees();
        }
        else
        {
            employees = await PeopleFetcher.GetFromApi();
        }

        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadge(employees);
        await PeopleFetcher.GetFromApi();
    }
}
}