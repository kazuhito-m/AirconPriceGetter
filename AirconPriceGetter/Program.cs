using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AirconPriceGetter
{
    class Program
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

        protected internal List<string> LoadTextFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"));
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');
            return new List<string>(lines);
        }

        protected internal string ToUrl(string id)
        {
            return String.Format(URL_TEMPLATE, id);
        }

        internal string HtmlBy(string url)
        {
            throw new NotImplementedException();
        }

    }
}
