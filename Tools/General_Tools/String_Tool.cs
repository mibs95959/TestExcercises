using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tools.General_Tools
{
    public class String_Tool
    {

        public static string GetStringBetween(string startValue, string endValue, string input)
        {
            return input.Split(startValue)[1].Split(endValue)[0];
        }

        /// <summary>
        /// TODO: Find a better method name.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static int GetTimesStringIsInGivenString(string input, string word)
        {
            return input.Split(word).Length - 1;
        }

        public static List<string> GetStringsBetween(string startValue, string endValue, string input)
        {
            List<string> result = new List<string>();
            string[] firstSplit = input.Split(startValue);
            for (int i = 1; i < firstSplit.Length; i++)
            {
                result.Add(firstSplit[i].Split(endValue)[0]);
            }
            return result;
        }

        public static int? GetFirstPosOfGivenString(string content, string input)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Equals(input)) return i;
            }
            Console.WriteLine("The char " + input + " was not found on the given string.");
            return null;
        }

        public static int? GetLastPositionOfGivenString(string content, string input)
        {
            for (int i = content.Length; i >= 0; i--)
            {
                if (content[i].Equals(input)) return i;
            }
            Console.WriteLine("The char " + input + " was not found on the given string.");
            return null;
        }


        // String Convertions:

        public static int? StringToInt(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Given input cannot be converted to Int, please verify the String being passed.");
                return null;
            }
        }

        public static double? StringToDoble(string input)
        {
            try
            {
                return Convert.ToDouble(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Given input cannot be converted to Double, please verify the String being passed.");
                return null;
            }
        }

        public static decimal? StringToDecimal(string input)
        {
            try
            {
                return Convert.ToDecimal(input.Replace("'", ","));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Given input cannot be converted to Decimal, please verify the String being passed.");
                return null;
            }
        }

        public static string SetToLowerWithoutSpaces(string input)
        {
            return input.ToLower().Replace(" ", string.Empty);
        }

        public static string MakeItFileNameFriendly(string input)
        {
            input = input.Replace("'", "");
            input = input.Replace("\"", "");
            input = input.Replace("/", "");
            input = input.Replace("=", "");
            input = input.Replace("#", "");
            input = input.Replace("&", "");
            input = input.Replace("?", "");
            input = input.Replace("$", "");
            input = input.Replace("+", "");
            input = input.Replace("!", "");
            input = input.Replace("*", "");
            input = input.Replace(" ", "");
            input = input.Replace(":", "");
            input = input.Replace("@", "");
            input = input.Replace("|", "");
            input = input.Replace("%", "");
            input = input.Replace(",", "");
            input = input.Replace(".", "");

            return input.ToLower().Replace(" ", string.Empty);
        }
    }
}
