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
    }
}
