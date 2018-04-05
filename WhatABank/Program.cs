using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User(Console.ReadLine());

            var prompt = new Prompt();
            prompt.RegisterCommand(new Command("help", "this help message", null, Special.HELP));
            prompt.RegisterCommand(new Command("exit", "exit the program", () => { Console.WriteLine("Goodbye!"); }, Special.EXIT));

            prompt.Run();
        }
    }
}
