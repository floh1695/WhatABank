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
                    UserService.Display(user);

                    var accountPrompt = new Prompt();
                    accountPrompt.RegisterCommand(new Command("deposit", "deposit money into your account",
                        () =>
                        {
                            var account = UserService.HandleAccountChoice(user);
                            Console.Write($"how much would you like to deposit into the account? ");
                            double amount = 0;
                            double.TryParse(Console.ReadLine(), out amount);
                            AccountService.Deposit(account, amount);
                            UserStorage.Write(user);
                            UserService.Display(user);
                        }));
                    accountPrompt.RegisterCommand(new Command("withdraw", "withdraw money from your account",
                        () =>
                        {
                            var account = UserService.HandleAccountChoice(user);
                            Console.Write($"how much would you like to withdraw from the account? ");
                            double amount = 0;
                            double.TryParse(Console.ReadLine(), out amount);
                            AccountService.Withdraw(account, amount);
                            UserStorage.Write(user);
                            UserService.Display(user);
                        }));
                    accountPrompt.RegisterCommand(new Command("transfer", "transfer to another account",
                        () =>
                        {
                            Console.WriteLine("select account to withdraw from");
                            var withdrawee = UserService.HandleAccountChoice(user);
                            Console.WriteLine("select account to deposit to");
                            var depositee = UserService.HandleAccountChoice(user);
                            Console.Write($"how much would you like to transfer? ");
                            double amount = 0;
                            double.TryParse(Console.ReadLine(), out amount);
                            AccountService.Transfer(withdrawee, depositee, amount);
                            UserStorage.Write(user);
                            UserService.Display(user);
                        }));

                    Console.WriteLine($"welcome {user.Name}!");
                    accountPrompt.Run();
                    Console.WriteLine("logging out");
                }));
            //loginPrompt.RegisterCommand(CreateTestCommand());

            loginPrompt.Run();
            Console.WriteLine("goodbye!");
            Console.ReadLine();
        }

        /**
         * Contains all interactive tests
         */
        private static Command CreateTestCommand()
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
                                    user.Accounts["some fake account"] = new AccountData("some fake account", "false name 1234567890");
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
