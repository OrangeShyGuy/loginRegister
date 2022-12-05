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

        public static bool checkPasswordValid(string password)
        {
            //checks password validity if it adheres to the requirements - at least 1: uppercase, lowercase, number, symbol and length 5-15 char
            bool passwordValid = false;
            bool hasLowerPass = false;
            bool hasUpperPass = false;
            bool hasSpecialPass = false;
            bool hasNumberPass = false;
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
                if (asciiBytes[i] > 90 && asciiBytes[i] < 97)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytes[i] > 122 && asciiBytes[i] < 127)
                {
                    hasSpecialPass = true;
                }
                if (asciiBytes[i] > 47 && asciiBytes[i] < 58)
                {
                    hasNumberPass = true;

                }
            }
            if (password.Length >= 5 && password.Length <= 15 && hasLowerPass == true && hasUpperPass == true && hasSpecialPass == true && hasNumberPass == true)
            {
                passwordValid = true;
            }
            return passwordValid;
        }

        public static bool checkLoginValid(string login)
        {
            //checks if login adheres to requirements - no special chars and length 3-12 char
            bool hasSpecialLogin = false;
            bool loginValid = false;
            byte[] asciiBytesLogin = Encoding.ASCII.GetBytes(login);

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
                if (asciiBytesLogin[i] > 90 && asciiBytesLogin[i] < 97)
                {
                    hasSpecialLogin = true;
                }
                if (asciiBytesLogin[i] > 122 && asciiBytesLogin[i] < 127)
                {
                    hasSpecialLogin = true;
                }
            }
            if (login.Length >= 3 && login.Length <= 12 && hasSpecialLogin == false)
            {
                loginValid = true;
            }
            return loginValid;
        }

        public static Tuple<string,string> registerMode(string register, List<Tuple<string, string>> logins)
        {
            //register mode responsible for registering new users into database and checking if they are already in system
            int index = register.IndexOf(" ");
            string login = register.Substring(0, (index));
            string password = register.Substring(index);
            bool contain = false;
            bool loginValid = checkLoginValid(login);
            bool passwordValid = checkPasswordValid(password);
            //checks if login already registered
            foreach (Tuple<string, string> tuple in logins)
            {
                if (login == tuple.Item1)
                {
                    contain = true;
                    Console.WriteLine("Login zajety");
                }
            }

            //if login and password are valid and not in database create tuple with login + password
            if (loginValid == true && passwordValid == true && contain == false)
            {
                Console.WriteLine("Zarejestrowano");
                return Tuple.Create(login, password);
            }
            else
            {
                Console.WriteLine("Blad");
            }
            return Tuple.Create(" "," ");
        }

        public static int loginMode(string input, List<Tuple<string, string>> sets)
        {
            /*
             0 - user not found
             1 - wrong password
             2 - logged in
            */
            int i = 0;
            int index = input.IndexOf(" ");
            int setIndex = 0;
            string login = input.Substring(0, (index));
            string password = input.Substring(index);
            //checks if login exists in database
            foreach (var item in sets)
            {
                if (login == item.Item1)
                {
                    setIndex = i;
                    break;
                }
                i++;
            }
            if (password == sets[setIndex].Item2)
            {
                Console.WriteLine("Zalogowano");
                return 2;
            }
            else if ((i) == sets.Count)
            {
                Console.WriteLine("Konto nie istnieje");
                return 0;
            }
            else
            {
                Console.WriteLine("Zle haslo");
                return 1;
            }
        }

        static void Main(string[] args)
        {
            while (true == true)
            {
                /* modes
            0 - invalid
            1 - login
            2 - register
            */
                List<Tuple<string, string>> sets = new List<Tuple<string, string>>();
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
                        if (sets.Count == 0)
                        {
                            Console.WriteLine("Brak zapisanych zestawow");
                        }
                        else
                        {
                            for (int i = 0; i < numOfTasks; i++)
                            {
                                Console.WriteLine("Podaj login i haslo");
                                string dane = Console.ReadLine();
                                loginMode(dane, sets);
                            }
                        }
                        break;
                    case 2:
                        numOfTasks = Convert.ToInt32(input.Substring(9));
                        for (int i = 0; i < numOfTasks; i++)
                        {
                            Console.WriteLine("Podaj login i haslo");
                            string dane = Console.ReadLine();
                            registerMode(dane, sets);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid mode");
                        break;
                }
            }
            
            //Console.WriteLine(mode);
        }
    }
}
