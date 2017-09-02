using System;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System.Linq;
using AngleSharp.Dom;

namespace AirconPriceGetter
{
    public class Scraper
    {
        public string Scrap(string html)
        {
            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = parser.Parse(html);
            IHtmlCollection<IElement> docByPriceClasses = doc.GetElementsByClassName("price");
            if (docByPriceClasses.Count() == 0) return "";

            String text = docByPriceClasses.First()
                .GetElementsByTagName("span")
                .First()
                .TextContent;

            return String.Join("",
                text.Where(c => char.IsNumber(c))
                    .Select(c => c.ToString())
            );
        }

    }
}
