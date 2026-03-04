using System.IO;
using System.Net.Http;

namespace Tools.General_Tools
{
    public class WebClient_Tool
    {

        private static readonly HttpClient client = new HttpClient();

        public static void DownloadFile(string urlSource, string fileNameAndPath)
        {
            using var stream = client.GetStreamAsync(urlSource).Result;
            using FileStream file = new FileStream(fileNameAndPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            stream.CopyTo(file);
        }
    }
}
