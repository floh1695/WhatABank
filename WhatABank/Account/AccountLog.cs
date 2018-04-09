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
        public static string MakeUrl(AccountData data)
        {
            return $"../../userdata/{data.UserName}-{data.Name}.log.txt";
        }

        public static void Log(AccountData data, string message)
        {
            using (var writer = new StreamWriter(MakeUrl(data), true))
            {
                writer.WriteLine(message);
            }
        }

        public static void Delete(AccountData data)
        {
            File.Delete(MakeUrl(data));
        }
    }
}
