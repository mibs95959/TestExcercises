using System;
using System.Collections.Generic;

namespace Tools.General_Tools
{
    public class ScenarioContext_Tool
    {

        private static Dictionary<string, object> ScennarioContext = new Dictionary<string, object>();

        public static void StoreObject(string Key, object ToBeStored)
        {
            if (DoesKeyExist(Key))
            {
                ScennarioContext[Key] = ToBeStored;
            }
            else
            {
                ScennarioContext.Add(Key, ToBeStored);
            }
        }

        public static object GetObject(string key)
        {
            try
            {
                return ScennarioContext[key];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static string GetStringObject(string key)
        {
            try
            {
                return (string)GetObject(key);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static DateTime? GetDateTimeObject(string key)
        {
            try
            {
                return DateTime.Parse(GetObject(key).ToString());
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("That wasnt a date my dude...");
                Console.WriteLine(GetObject(key).ToString());
                return null;
            }
        }

        public static bool DoesKeyExist(string key)
        {
            return ScennarioContext.ContainsKey(key);
        }

    }
}
