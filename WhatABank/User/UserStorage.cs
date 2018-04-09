using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using WhatABank.Account;

namespace WhatABank.User
{
    static class UserStorage
    {
        public static string MakeUrl(string name)
        {
            return $"../../userdata/{name}.user.bin";
        }

        public static UserData Read(string username, string password)
        {
            var bf = new BinaryFormatter();
            try
            {
                var userFile = new FileStream(MakeUrl(username), FileMode.Open, FileAccess.Read, FileShare.None);
                using (userFile)
                {
                    var data = (UserData)bf.Deserialize(userFile);
                    if (data.TestPassword(password)) { return data; }
                    throw new Exception("password error");
                }
            }
            catch (Exception e)
            {
                if (e.Message == "password error") { throw e; } // This also makes me sick
                var data = new UserData(username, password);
                Write(data);
                return data;
            }
        }

        public static void Write(UserData data)
        {
            var bf = new BinaryFormatter();
            var userFile = new FileStream(MakeUrl(data.Name), FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (userFile)
                {
                    bf.Serialize(userFile, data);
                }

            }
            catch
            {
                Console.WriteLine($"Could not write to file: \"{userFile.Name}\"");
            }
        }

        internal static void Delete(UserData user)
        {
            File.Delete(MakeUrl(user.Name));
            foreach (var account in user.Accounts)
            {
                AccountLog.Delete(account.Value);
            }
        }
    }
}
