using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;

namespace AirconPriceGetter
{
    public class Program
    {

        private const string URL_TEMPLATE = "http://kakaku.com/search_results/{0}/?sort=priceb";

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.ScrapingPlices(args[0], "./result.txt");
        }

        public void ScrapingPlices(string filePath, string outPath)
        {
            List<string> ids = LoadTextFile(filePath);

            ids.Select(i => ToUrl(i))
               .ToList()
               .ForEach(i => Console.WriteLine(i));
        }

        public List<string> LoadTextFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"));
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');
            return new List<string>(lines);
        }

        public string ToUrl(string id)
        {
            return String.Format(URL_TEMPLATE, id);
        }

        public  string HtmlBy(string url)
        {
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(url);
            string html = Encoding.UTF8.GetString(data).TrimEnd('\0');
            return html;
        }

    }
}
