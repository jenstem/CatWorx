﻿using System;
using System.Reflection.Metadata.Ecma335;

namespace CatWorx.BadgeMaker
{
    class Program
    {
    static void Main(string[] args)
    {
        string stringNum = "2";
        int intNum = Convert.ToInt32(stringNum);
        Console.WriteLine(intNum);
        Console.WriteLine(intNum.GetType());
    }
    }
}
