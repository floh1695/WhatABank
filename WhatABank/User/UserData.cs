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
        public Dictionary<string, AccountData> Accounts { get; }

        public UserData(string name)
        {
            Name = name;
            Accounts = new Dictionary<string, AccountData>();
            foreach (var accountName in new string[] { "checkings", "savings" })
            {
                Accounts[accountName] = new AccountData();
            }
        }
    }
}
