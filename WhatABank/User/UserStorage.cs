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
        private static void VerifyDirectoryStructure()
        {
            throw new NotImplementedException();
        }

        public static UserData Read(string username)
        {
            return null;
        }

        public static void Write(UserData data)
        {
            var bf = new BinaryFormatter();
            //var userFile = new FileStream("../../");
        }
    }
}
