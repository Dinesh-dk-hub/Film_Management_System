using System;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Film_Management_System
{
    public static class Utility
    {
        private static CultureInfo culture = new CultureInfo("ms-MY");
        public static float GetValidDecimalInput(string input)
        {
            bool valid = false;
            string rawInput;
            float num = 0;

            // Get user's input input type is valid
            while (!valid)
            {
                rawInput = GetRawInput(input);
                valid = float.TryParse(rawInput, out num);
                if (!valid)
                    PrintMessage("Invalid input. Try again.", false);
            }

            return num;
        }

        public static int GetValidIntInput(string input)
        {
            bool valid = false;
            string rawInput;
            int num = 0;

            // Get user's input input type is valid
            while (!valid)
            {
                rawInput = GetRawInput(input);
                valid = Int32.TryParse(rawInput, out num);
                if (!valid)
                    PrintMessage("Invalid input. Try again.", false);
            }

            return num;
        }
        public static string validatephone(string msg)
        {
            bool flag = true;
            Regex rgx = new Regex(@"^[0-9]{10}$");
            while (flag)
            {
                if (!rgx.IsMatch(msg))
                {
                    Console.Write("Enter a valid customer phone number: ");
                    msg = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            return msg;
        }
        public static string EmailValidation(string msg)
        {
            bool flag = true;
            Regex rgx = new Regex(@"^[a-z0-9]+@[a-z]+\.[a-z]{2,3}$");
            while (flag)
            {
                if (!rgx.IsMatch(msg))
                {
                    Console.Write("Enter a valid customer email: ");
                    msg = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            return msg;
        }
        public static string GetValidRawInput(string message)
        {
            string rawInput = "";
            bool valid = false;
            while (!valid)
            {
                rawInput = GetRawInput(message);
                if (rawInput != "")
                {
                    valid = true;
                }
                //valid = Int32.TryParse(rawInput, out num);
                if (!valid)
                    PrintMessage("Invalid input. Try again.", false);
            }
            return rawInput;
        }

        public static string GetRawInput(string message)
        {
            Console.Write($"Enter {message}: ");
            return Console.ReadLine();
        }

        public static string GetHiddenConsoleInput()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }


        public static void printDotAnimation(int timer = 10)
        {
            for (var x = 0; x < timer; x++)
            {
                System.Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        public static string Formatnum(decimal amt)
        {
            return String.Format(culture, "{0:C2}", amt);
        }

        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
}
