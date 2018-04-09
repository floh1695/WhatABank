using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WhatABank.Account;

namespace WhatABank.User
{
    [Serializable]
    class UserData
    {
        public string Name { get; }
        private string Password;
        public Dictionary<string, AccountData> Accounts { get; }

        public UserData(string name, string password)
        {
            Name = name;
            Password = password;
            Accounts = new Dictionary<string, AccountData>();
            foreach (var accountName in new string[] { "checkings", "savings" })
            {
                Accounts[accountName] = new AccountData(accountName, Name);
            }
        }

        public bool TestPassword(string password)
        {
            Console.WriteLine($"Testing: \"{Password}\" == \"{password}\"");
            return Password == password;
        }
    }
}
