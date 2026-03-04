using System;
using System.Text;

namespace Tools.General_Tools
{
    public class RandomInputGenerator_Tool
    {

        private static Random _random = new Random();

        private static string _allCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string _MixAbcCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string _UpperAbcCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _LowerAbcCharacters = "abcdefghijklmnopqrstuvwxyz";
        private static string _Numbers = "0123456789";
        private static string _NumbersWOZero = "123456789";

        private static string Randomize(string _characters, int _length)
        {
            StringBuilder result = new StringBuilder(_length);
            for (int i = 0; i < _length; i++)
            {
                result.Append(_characters[_random.Next(_characters.Length)]);
            }
            return result.ToString();
        }

        public static string RandomCharactersAndNumbers(int _length)
        {
            return Randomize(_allCharacters, _length);
        }

        public static string RandomAbcCharacters(int _length)
        {
            return Randomize(_MixAbcCharacters, _length);
        }

        public static string RandomAbcUpperCharacters(int _length)
        {
            return Randomize(_UpperAbcCharacters, _length);
        }

        public static string RandomAbcLowerCharacters(int _length)
        {
            return Randomize(_LowerAbcCharacters, _length);
        }

        public static string RandomNumbers(int _length)
        {
            return Randomize(_Numbers, _length);
        }

        public static string RandomDateDay(int _length)
        {
            return Randomize(_NumbersWOZero, _length);
        }

        public static char RandomCharacter()
        {
            char randomChar = (char)_random.Next('a', 'z');
            return randomChar;
        }

    }
}
