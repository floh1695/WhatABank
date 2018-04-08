using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WhatABank.Account;

namespace WhatABank.User
{
    static class UserService
    {
        public static AccountData GetAccount(UserData data, string accountName)
        {
            return data.Accounts[accountName];
        }

        internal static void Display(UserData user)
        {
            Console.WriteLine($"user.Name => {user.Name}");
            foreach (var accountKey in user.Accounts.Keys)
            {
                Console.WriteLine($"user.Accounts[\"{accountKey}\"].Amount => {user.Accounts[accountKey].Amount}");
            };
        }
    }
}
