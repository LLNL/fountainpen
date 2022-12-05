using System;
using System.Text;
using System.IO;
using System.Net;

namespace FountainPen
{
    class FountainPen
    {
        public static void postContent(Config settings, string content)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://" + settings.host + ":" + settings.port + settings.path);
            request.Method = "POST";
            request.UserAgent = "Notepad++ fountainpen Plugin/1.0";

            byte[] byteArray = Encoding.UTF8.GetBytes(content);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            
            // Get the stream containing content returned by the server.
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
            }
            response.Close();
        }

        public static bool matchWords(Config settings, string content)
        {
            foreach(var word in settings.keywords)
            {
                if (content.Contains(word)) return true;
            }
            return false;
        }
    }
}
