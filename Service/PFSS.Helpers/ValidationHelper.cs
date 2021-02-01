﻿using System;
using System.Collections.Generic;

namespace PFSS.Helpers
{
    public static class ValidationHelper
    {
        public static bool isValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public static bool isValidCharRange(this string text,int min, int max)
        {
            return text != null && text.Length >= min && text.Length <= max;
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return text==null || text.Length==0;
        }


        public static bool isIn<T>(this T check,List<T> arr)
        {

            foreach(T value in arr)
            {
                if (value.Equals(check))
                    return true;
            }
            return false;
        }
        public static bool not(this bool value)
        {
            return !value;
        }


    }
}