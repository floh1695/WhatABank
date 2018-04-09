using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank.Account
{
    [Serializable]
    class AccountData
    {
        public double Amount = 0;
        public string Name { get; }
        public string UserName { get; }

        public AccountData(string name, string userName)
        {
            Name = name;
            UserName = userName;
        }
    }
}
