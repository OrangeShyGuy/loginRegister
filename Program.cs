using System;
using System.Collections.Generic;

namespace loginRegister
{
    class Program
    {
        public static int checkMode(string input)
        {
            /* checks if string is used to login, register or is invalid
            0 - invalid
            1 - login
            2 - register
            */
            string lowInput = input.ToLower();
            if (lowInput.Contains("login"))
            {
                return 1;
            }
            else if (lowInput.Contains("register"))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public static List<string> registerMode(string register, List<String> logins)
        {
            int index = register.IndexOf(" ");
            string login = register.Substring(0, (index));
            string password = register.Substring(index);
            bool contain = false;
            bool hasSpecial = false;
            char[] special = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',';',':'};
            foreach (string log in logins)
            {
                if (login == log)
                {
                    contain = true;
                    Console.WriteLine("Login zajety");
                }
            }
            foreach (char letter in special)
            {
                if (login.Contains(letter))
                {
                    hasSpecial = true;
                }
            }
            //checks password
            bool hasLower;
            bool hasUpper;
            if ()
            if (login.Length >= 3 && login.Length <= 12 && hasSpecial == false)
            {
                if (contain == false)
                {
                    logins.Add(login);
                }
            }
            else
            {
                Console.WriteLine("Blad");
            }
            
            return logins;
        }
        public static string loginMode(string login)
        {

            return "yes";
        }
        static void Main(string[] args)
        {
            List<string> passwords = new List<string>();
            List<string> logins = new List<string>();
            int numOfTasks;
            Console.WriteLine("Podaj tryb i ilosc polecen");
            string input = Console.ReadLine();
            int mode = checkMode(input);
            switch (mode)
            {
                case 0:
                    Console.WriteLine("Blad polecenia");
                    break;
                case 1:
                    numOfTasks = Convert.ToInt32(input.Substring(6));
                    Console.WriteLine(numOfTasks);
                    break;
                case 2:
                    numOfTasks = Convert.ToInt32(input.Substring(9));
                    Console.WriteLine(numOfTasks);
                    break;
                default:
                    Console.WriteLine("Invalid mode");
                    break;
            }
            //Console.WriteLine(mode);
        }
    }
}
