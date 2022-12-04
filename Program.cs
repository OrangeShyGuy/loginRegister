using System;
using System.Collections.Generic;
using System.Text;

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
        public static List<Tuple<string>> registerMode(string register, List<Tuple<String, String>> logins)
        {
            int index = register.IndexOf(" ");
            string login = register.Substring(0, (index));
            string password = register.Substring(index);
            bool contain = false;
            bool hasSpecialLogin = false;
            bool hasLowerPass = false;
            bool hasUpperPass = false;
            bool hasSpecialPass = false;
            bool hasNumberPass = false;
            bool passwordValid = false;
            bool loginValid = false;
            byte[] asciiBytesLogin = Encoding.ASCII.GetBytes(login);

            //checks if login already registered
            foreach (Tuple<string, string> tuple in logins)
            {
                if (login == tuple.Item1)
                {
                    contain = true;
                    Console.WriteLine("Login zajety");
                }
            }
            //checks login
            for (int i = 0; i < asciiBytesLogin.Length; i++)
            {
                if (asciiBytesLogin[i] > 32 && asciiBytesLogin[i] < 48)
                {
                    hasSpecialLogin = true;
                }
                if (asciiBytesLogin[i] > 57 && asciiBytesLogin[i] < 65)
                {
                    hasSpecialLogin = true;
                }
                if (asciiBytesLogin[i] > 90  && asciiBytesLogin[i] < 97)
                {
                    hasSpecialLogin = true;
                }
                if (asciiBytesLogin[i] > 122 && asciiBytesLogin[i] < 127)
                {
                    hasSpecialLogin = true;
                }
            }
            //checks password
            byte[] asciiBytes = Encoding.ASCII.GetBytes(password);

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 96 && asciiBytes[i] < 123)
                {
                    hasLowerPass = true;
                }
                if (asciiBytes[i] > 64 && asciiBytes[i] < 91)
                {
                    hasUpperPass = true;
                }
                if (asciiBytes[i] > 32 && asciiBytes[i] < 48)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytes[i] > 57 && asciiBytes[i] < 65)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytesLogin[i] > 90 && asciiBytesLogin[i] < 97)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytesLogin[i] > 122 && asciiBytesLogin[i] < 127)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytesLogin[i] > 47 && asciiBytesLogin[i] < 58)
                {
                    hasNumberPass = true;

                }
            }
            //check password validity
            if (password.Length >=5 && password.Length <=15 && hasLowerPass == true && hasUpperPass == true && hasSpecialPass == true && hasNumberPass == true)
            {
                    passwordValid = true;
            }
            if (login.Length >= 3 && login.Length <= 12 && hasSpecialLogin == false)
            {
                    loginValid = true;
            }
            else
            {
                Console.WriteLine("Blad");
            }
            if (loginValid == true && passwordValid == true && contain == false)
            {
                    logins.Add(Tuple.Create(login, password));
            }
                else
                {
                    Console.WriteLine("Blad");
                }
            //return logins;
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
