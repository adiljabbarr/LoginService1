using System;
using System.ComponentModel;
using System.Linq;

namespace LoginService1
{
    internal class Program
    {

        static string[] nicknames = new string[10];
        static string[] passwords = new string[10];
        static int index = 0;
        static void Main(string[] args)
        {

            SeedData();
            ApplicationStartWindow();
        }
        static void SeedData()
        {
            nicknames[0] = "Adil";
            passwords[0] = "1234Adil";

            nicknames[1] = "Emil";
            passwords[1] = "1234Emil";

            nicknames[2] = "AtOgrusu";
            passwords[2] = "1234AtOgrusu";
        }
        static void ApplicationStartWindow()
        {

            Console.ResetColor();

            Console.Title = "Valorant";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Hos geldin brat");
            Console.ResetColor();


            Console.WriteLine("1. Daxil olmaq :");
            Console.WriteLine("2. Qeydiyyat");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SignIn();
            }
            else if (choice == "2")
            {
                SignUp();
            }
        }
        static void SignIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Daxil olmaq :");
            Console.ResetColor();
            Console.WriteLine("Adini yaz");
            string nickName = Console.ReadLine();

            Console.WriteLine("Sifreni yaz bura");
            string password = Console.ReadLine();
            while (FindUser(nickName, password) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Bu ad yoxdur adinizi yeniden yazin");
                Console.ResetColor();
                nickName = Console.ReadLine();
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Xos gedin qaqaaa");
            Console.ResetColor();
            Console.ReadKey();
        }
        private static bool FindPassword(string password)
        {
            foreach (var passWord in passwords)
            {
                if (passWord == password)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool FindUser(string nickName, string password)
        {
            int index = 0;
            foreach (var nickname in nicknames)
            {
                if (nickname == nickName)
                {
                    break;
                }
                index++;
            }
            for (int i = 0; i < passwords.Length; i++)
            {
                if (passwords[index] == password)
                {
                    return true;
                }
            }
            return false;
        }
        static void SignUp()
        {


            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Qeydiyyat");
            Console.ResetColor();


            Console.WriteLine("Adinizi yazin");
            string nickName = Console.ReadLine();

            while (CheckNickName(nickName) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Bu ad var yenisini girin zehmet olmasa ");
                Console.ResetColor();
                nickName = Console.ReadLine();

            }

            Console.WriteLine("Sifrenizi yazin");
            string password = Console.ReadLine();

            while (CheckPassword(password) == false)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sifre duzgun deyil. Sifrede en az 1 boyuk herf , 1 reqem , 1 simvol ve uzunlugu 12 olmalidir");
                Console.ResetColor();
                password = Console.ReadLine();

            }

            AddUser(nickName, password);
            SignIn();
        }
        private static void AddUser(string nickName, string password)
        {
            nicknames[index] = nickName;
            passwords[index] = password;
            index++;
        }
        static bool CheckNickName(string nickName)
        {
            bool notExist = true;

            for (int i = 0; i < nicknames.Length; i++)
            {
                if (nicknames[i] == nickName)
                {
                    notExist = false;
                    break;
                }
            }

            return notExist;
        }
        static bool CheckPassword(string password)
        {
            if (password.Length < 12) return false;

            bool hasDigit = false;
            bool hasSymbol = false;
            bool hasUpper = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i])) hasDigit = true;
                if (char.IsUpper(password[i])) hasUpper = true;
                if (char.IsSymbol(password[i])) hasSymbol = true;
            }

            if (hasDigit && hasSymbol && hasUpper) return true;

            return false;

        }
    }
}