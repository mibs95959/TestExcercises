using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tools.General_Tools.FileReaders
{
    public class XmlReader_Tool
    {

        private static XmlDocument xDoc;

        public static void LoadXml(string path)
        {
            xDoc = new XmlDocument();
            xDoc.Load(path);
        }

        public static string ReadGivenPropertyByName(string propertyName)
        {
            return xDoc.SelectSingleNode("//Variable[@name='" + propertyName + "']").InnerText;
        }

        public static string ReadGivenPropertyByName(XmlNode node, string propertyName)
        {
            return node.SelectSingleNode("//Variable[@name='" + propertyName + "']").InnerText;
        }

        /// <summary>
        /// Note: As type be <User> for example, as input will be just "User".
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static XmlNodeList GetNodesByObjectType(string type)
        {
            return xDoc.SelectNodes("//" + type);
        }

        public static List<string> ReadGivenPropertiesByName(string propertiesName)
        {
            List<string> result = new List<string>();
            XmlNodeList elementList = xDoc.SelectNodes("//Variable[@name='" + propertiesName + "']");
            foreach (XmlNode x in elementList)
            {
                result.Add(x.InnerText);
            }
            return result;
        }

    }
}
