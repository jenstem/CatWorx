using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CatWorx.BadgeMaker
{
    class Program
    {
    static void Main(string[] args)
    {
        List<string> employees = new List<string>() { "adam", "amy" };

        employees.Add("barbara");
        employees.Add("billy");

        Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
    }
    }
}
