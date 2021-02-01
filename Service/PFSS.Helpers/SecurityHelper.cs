using System.Text;
using System.Net.Mime;
using System;
using System.Security.Cryptography;

namespace PFSS.Helpers
{
    public class SecurityHelper
    {
        public static string computeHash(string text){
            using(var sha512=SHA512.Create()){
                byte[] arrayText = Encoding.ASCII.GetBytes(text);
                var hashArray=sha512.ComputeHash(arrayText);
                return Convert.ToBase64String(hashArray);
            }
        }

    }
}
