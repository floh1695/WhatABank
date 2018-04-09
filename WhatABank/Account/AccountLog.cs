using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WhatABank.User;

namespace WhatABank.Account
{
    class AccountLog
    {
        public static string MakeUrl(string accountName, string userName)
        {
            return $"../../userdata/{userName}-{accountName}.log.txt";
        }

        public static void Log(AccountData data, string message)
        {
            using (var writer = new StreamWriter(MakeUrl(data.Name, data.UserName), true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
