using System;

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
        public static string registerMode(string register)
        {
            int index = register.IndexOf(" ");

            return "yes";
        }
        public static string loginMode(string login)
        {

            return "yes";
        }
        static void Main(string[] args)
        {
            string[] passwords = { };
            string[] logins = { };
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
