using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank
{
    class Prompt
    {

        public string PromptStyle { get; set; } = "> ";

        private List<Command> Commands = new List<Command>();

        public void Run()
        {
            HelpMessage();
            while (true)
            {
                Console.Write(PromptStyle);
                var input = Console.ReadLine();

                var helpCommand = new Command("help", "this help message", null, Special.HELP);
                var exitCommand = new Command("exit", "exit the program", null, Special.EXIT);
                var errorCommand = new Command(() => Console.WriteLine($"'{input}' is not a valid command"));

                Command command;
                if (input == "help") { command = helpCommand; }
                else if (input == "exit") { command = exitCommand; }
                else
                {
                    command = Commands
                        .FirstOrDefault((cmd) => input == cmd.TextCommand)
                        ?? errorCommand;
                }

                command.Callback();
                if (command.SpecialOption == Special.EXIT)
                {
                    break;
                }
                else if (command.SpecialOption == Special.HELP)
                {
                    HelpMessage();
                }
            }
        }

        private void HelpMessage()
        {
            Console.WriteLine("help : this help message");
            foreach (var command in Commands.Where(cmd => cmd.TextCommand != ""))
            {
                Console.WriteLine($"{command.TextCommand} : {command.Help}");
            }
            Console.WriteLine("exit : exit the prompt");
        }

        public void RegisterCommand(Command command)
        {
            Commands.Add(command);
        }

        public Prompt()
        {
            RegisterCommand(new Command(null));
        }
    }
}
