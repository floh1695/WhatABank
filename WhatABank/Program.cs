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
            var loginPrompt = new Prompt();

            loginPrompt.RegisterCommand(new Command("login", "login your user",
                () =>
                {
                    Console.Write("username: ");
                    var username = Console.ReadLine();

                    Console.Write("password: ");
                    var password = MaskedInput();

                    var accountPrompt = new Prompt();
                    accountPrompt.RegisterCommand(new Command("set account", "set account data",
                        () =>
                        {
                            
                        }));

                    accountPrompt.Run();
                }));

            loginPrompt.Run();

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }

        static string MaskedInput()
        {
            var input = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Remove(input.Length - 1);
                    }
                    Console.Write("\b \b");
                }
                else
                {
                    input += keyInfo.KeyChar;
                    Console.Write('*');
                }
            }
            Console.WriteLine();
            return input;
        }
    }

}
