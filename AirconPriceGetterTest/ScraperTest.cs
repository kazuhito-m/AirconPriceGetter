using NUnit.Framework;
using System.IO;
using System.Text;

namespace AirconPriceGetter
{
    [TestFixture]
    public class ScraperTest
    {
        [Test]
        public void HTMLをスクレイピングし必要なパーツを取得できる()
        {
            string html = LoadTextResource("sample01.html");
            Scraper sut = new Scraper();
            string actual = sut.Scrap(html);
            Assert.That(actual, Is.EqualTo("139000"));
        }

		private string LoadTextResource(string resourceName)
        {
            string testWorkPath = TestContext.CurrentContext.TestDirectory;
            string resourcePath = testWorkPath + "../../../TestResources/" + resourceName;
            StreamReader sr = new StreamReader(resourcePath, Encoding.GetEncoding("UTF-8"));
            string html = sr.ReadToEnd();
            sr.Close();
            return html;
        }

    }
}
