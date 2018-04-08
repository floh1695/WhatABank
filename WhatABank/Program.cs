using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WhatABank.Account;
using WhatABank.PromptNS;
using WhatABank.User;

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

                    //Console.Write("password: ");
                    //var password = MaskedInput();

                    var user = UserStorage.Read(username);
                    var account = "checkings";

                    var accountPrompt = new Prompt();
                    accountPrompt.RegisterCommand(new Command("set account", "set account data",
                        () =>
                        {
                            var validAccountNames = new string[] { "checkings", "savings" };
                            foreach (var accountName in validAccountNames) { Console.WriteLine($": {accountName}"); }
                            Console.Write("what account would you like to use: ");
                            var newAccount = Console.ReadLine();
                            if (validAccountNames.Contains(newAccount)) { account = newAccount; }
                            else { Console.WriteLine($"{newAccount} is not a valid account name"); }
                        }));
                    accountPrompt.RegisterCommand(new Command("deposit", "deposit money into your account",
                        () =>
                        {
                            Console.Write($"how much would you like to deposit into {account}? ");
                            double amount = 0;
                            double.TryParse(Console.ReadLine(), out amount);
                            Console.WriteLine(amount);
                        }));
                    accountPrompt.RegisterCommand(new Command("withdraw", "withdraw money from your account",
                        () =>
                        {
                            Console.Write($"how much would you like to withdraw from {account}");
                            double amount = 0;
                            double.TryParse(Console.ReadLine(), out amount);
                            Console.WriteLine(amount);
                        }));

                    Console.WriteLine($"welcome {user.Name}!");
                    accountPrompt.Run();
                    Console.WriteLine("logging out");
                }));
            loginPrompt.RegisterCommand(createTestCommand());

            loginPrompt.Run();
            Console.WriteLine("goodbye!");
            Console.ReadLine();
        }

        /**
         * Contains all interactive tests
         */
        private static Command createTestCommand()
        {
            return new Command("test", "testing fields",
                () =>
                {
                    var prompt = new Prompt();
                    prompt.RegisterCommand(new Command("serialization", "Test serialization interactively",
                        () =>
                        {
                            var user = UserStorage.Read("serialization test user");

                            var serializationPrompt = new Prompt();
                            serializationPrompt.RegisterCommand(new Command("rw", "read/write test",
                                () =>
                                {
                                    var originalName = user.Name;

                                    UserStorage.Write(user);
                                    Console.WriteLine("starting data");
                                    UserService.Display(user);

                                    Console.WriteLine("clobbered data");
                                    user = new UserData("false name 1234567890");
                                    user.Accounts["some fake account"] = new AccountData();
                                    UserService.Display(user);

                                    user = UserStorage.Read(originalName);
                                    Console.WriteLine("original data");
                                    UserService.Display(user);
                                }));

                            serializationPrompt.Run();
                        }));

                    prompt.Run();
                });
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
