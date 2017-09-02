using NUnit.Framework;
using System.Collections.Generic;

namespace AirconPriceGetter
{
    [TestFixture]
    public class ProgramTest
    {

        [Test]
        [Ignore("スモークとして作ったものの、外部にHTTP通信するので一旦無効")]
        public void プログラム全体のスモーク()
        {
            string testWorkPath = TestContext.CurrentContext.TestDirectory;
            string[] param = new string[] { testWorkPath + "../../../TestResources/id.txt" };

            Program.Main(param);
        }

        [Test]
        public void 指定されたpathからテキストが読める()
        {
            string testWorkPath = TestContext.CurrentContext.TestDirectory;
            Program sut = new Program();

            List<string> actual = sut.LoadTextFile(testWorkPath + "../../../TestResources/id.txt");

            Assert.That(actual[0], Is.EqualTo("SRK56ST2"));
        }

        [Test]
        public void 指定した文字列をURLに変換出来る()
        {
            Program sut = new Program();

            string actual = sut.ToUrl("SRK56ST2");

            Assert.That(actual, Is.EqualTo("http://kakaku.com/search_results/SRK56ST2/?sort=priceb"));
        }

        [Test]
        public void 指定したURLからHTMLを取得することが出来る()
        {
            const string url = "https://google.com";
            Program sut = new Program();

            string actual = sut.HtmlBy(url);

            Assert.That(actual, Is.Not.Empty);
        }

    }
}
