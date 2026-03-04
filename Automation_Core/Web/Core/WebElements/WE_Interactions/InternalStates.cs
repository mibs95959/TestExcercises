using System.Collections.Generic;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class InternalStates : SeleniumCore
    {

        private static Dictionary<string, string> _interactionStates = new Dictionary<string, string>();

        // Method to add or update a value in the dictionary
        public static void AddOrUpdateInteractionState(string key, string value)
        {
            if (_interactionStates.ContainsKey(key))
            {
                _interactionStates[key] = value;
            }
            else
            {
                _interactionStates.Add(key, value);
            }
        }

        // Method to get a value from the dictionary
        public static string GetInteractionState(string key)
        {
            if (_interactionStates.ContainsKey(key))
            {
                return _interactionStates[key];
            }
            return null;
        }

        // Method to remove a value from the dictionary
        public void RemoveInteractionState(string key)
        {
            if (_interactionStates.ContainsKey(key))
            {
                _interactionStates.Remove(key);
            }
        }

    }
}
