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

        public static void Display(UserData user)
        {
            foreach (var accountKey in user.Accounts.Keys)
            {
                Console.WriteLine($"{accountKey} => {user.Accounts[accountKey].Amount}");
            };
        }

        public static AccountData HandleAccountChoice(UserData user)
        {
            AccountData account;

            Display(user);
            while (true)
            {
                Console.Write("Which account? ");
                var key = Console.ReadLine();
                user.Accounts.TryGetValue(key, out account);
                if (account != null) { break; }
                Console.WriteLine($"\"{key}\" is not a valid account");
            }

            return account;
        }
    }
}
