using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank
{
    class Command
    {
        public string TextCommand { get; }
        public string Help { get; }
        public Action Callback { get; }
        public Special? SpecialOption { get; }

        public Command()
            : this(null) { }
        public Command(Action command)
            : this("", "", command, null) { }
        public Command(string textCommand, string help, Action callback)
            : this(textCommand, help, callback, null) { }
        public Command(string textCommand, string help, Action callback, Special? special)
        {
            TextCommand = textCommand;
            Help = help;
            Callback = callback ?? (() => { /* Dummy action */ });
            SpecialOption = special;
        }
    }
}
