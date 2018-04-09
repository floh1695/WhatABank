using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank.Account
{
    class AccountService
    {
        public static void Deposit(AccountData account, double amount)
        {
            account.Amount += amount;
            AccountLog.Log(account, $"deposited {amount}");
        }

        public static double Withdraw(AccountData account, double amount)
        {
            var delta = amount;
            if (account.Amount >= amount)
            {
                account.Amount -= amount;
            }
            else
            {
                Console.WriteLine("Could not withdraw that much!");
                delta = 0;
            }
            AccountLog.Log(account, $"Withdrew {delta}");
            return delta;
        }

        internal static void Transfer(AccountData withdrawee, AccountData depositee, double amount)
        {
            AccountLog.Log(withdrawee, $"attempted to transfer out {amount}");
            AccountLog.Log(depositee, $"preparing to accept in {amount}");
            Deposit(depositee, Withdraw(withdrawee, amount));
        }
    }
}
