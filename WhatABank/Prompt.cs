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
                var errorCommand = new Command(() => Console.WriteLine($"'{input}' is not a valid command"));
                var command = Commands.FirstOrDefault((cmd) => input == cmd.TextCommand) ?? errorCommand;
                command.Callback();
                if (command.SpecialOption == Special.EXIT)
                {
                    Console.ReadLine();
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
            foreach (var command in Commands.Where(cmd => cmd.TextCommand != ""))
            {
                Console.WriteLine($"{command.TextCommand} : {command.Help}");
            }
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
