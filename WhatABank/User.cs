using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank
{
    class User
    {
        static string[] DEFAULT_ACCOUNT_NAMES = new string[] { "checking", "saving" };

        string Name;
        List<Account> Accounts = new List<Account>();

        public User(string name)
        {
            Name = name;
            foreach (var accountName in DEFAULT_ACCOUNT_NAMES)
            {
                Accounts.Add(new Account(accountName));
            }
        }
    }

}
