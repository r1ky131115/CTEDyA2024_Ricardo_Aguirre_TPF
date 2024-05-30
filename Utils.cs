﻿using System.Text;

namespace tpfinal
{
    internal class Utils
    {
        private static string? patron;
        public static int lineCount;

        public static void init_patron()
        {
            patron = System.IO.Directory.GetCurrentDirectory() + "\\datasets\\dataset.csv";
            lineCount = File.ReadLines(@patron).Count();
        }

        public static void set_patron(string patron_parm)
        {
            patron = patron_parm;
            lineCount = File.ReadLines(@patron).Count();
        }

        public static string get_patron()
        {
            if (patron == null)
            {
                patron = System.IO.Directory.GetCurrentDirectory() + "\\datasets\\dataset.csv";
                //lineCount = File.ReadLines(@patron).Count();
            }
            
            return patron;  
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            //string str = str_input.Replace(' ', '_');
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
