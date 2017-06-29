using System;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System.Linq;

namespace AirconPriceGetter
{
    public class Scraper
    {
        public string scrap(string html)
        {
            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = parser.Parse(html);
            String text = doc.QuerySelectorAll("#minPrice")
                .First()
                .GetElementsByTagName("span")
                .First()
                .TextContent;
            return text.Replace("\\", "");
        }
    }
}
