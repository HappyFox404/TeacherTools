using System;
using System.Security.Cryptography;
using System.Text;

namespace TeacherTools.Function
{
    public class Utils
    {
        public static string GetMD5(string str) {
            return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str)));
        }
    }
}
