using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WhatABank.User
{
    static class UserStorage
    {
        public static string MakeUrl(string name)
        {
            return $"../../userdata/{name}.user";
        }

        public static UserData Read(string username)
        {
            var bf = new BinaryFormatter();
            try
            {
                var userFile = new FileStream(MakeUrl(username), FileMode.Open, FileAccess.Read, FileShare.None);
                using (userFile)
                {
                    var data = (UserData)bf.Deserialize(userFile);
                    Write(data);
                    return data;
                }
            }
            catch
            {
                Console.WriteLine("Had to make a new one");
                return new UserData(username);
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
    }
}
