﻿using System;
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
            Scraper scraper = new Scraper();

            List<string> ids = LoadTextFile(filePath);

            List<string> prices = ids.Where(id => id.Trim().Count() > 0)
                .Select(id => ToUrl(id))
                .Select(url => HtmlBy(url))
                .Select(html => scraper.Scrap(html))
                .ToList();

            WriteFile(outPath, prices);
        }

        public List<string> LoadTextFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8"));
            string text = sr.ReadToEnd();
            return text.Split('\n')
                .Select(id => id.Replace("\r", ""))
                .ToList();
        }

        public string ToUrl(string id)
        {
            string url = String.Format(URL_TEMPLATE, id);
            return url;
        }

        public string HtmlBy(string url)
        {
            Console.WriteLine(url);
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(url);
            string html = Encoding.GetEncoding("Shift_JIS")
                .GetString(data)
                .TrimEnd('\0');
            return html;
        }

        public void WriteFile(string outPath, List<string> prices)
        {
            StreamWriter sw = new StreamWriter(outPath, false, Encoding.UTF8);
            prices.ForEach(price => sw.WriteLine(price));
            sw.Close();
        }

    }
}
