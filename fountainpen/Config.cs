using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainPen
{
    public class Config
    {
        public string host;
        public int port;
        public string path;
        public List<string> keywords = new List<string>();

        public Config(string IniPath)
        {
            IniFile ini = new IniFile(IniPath);
            host = ini.IniReadValue("server", "host");
            port = Int32.Parse(ini.IniReadValue("server", "port"));
            path = ini.IniReadValue("server", "path");

            string kwblob = ini.IniReadValue("filter", "keywords");
            string[] words = kwblob.Split(';');
            foreach(var word in words)
            { keywords.Add(word); }
        }
    }
}
