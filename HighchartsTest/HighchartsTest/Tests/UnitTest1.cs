using HighchartsTest.Confing;
using HighchartsTest.PageElement;
using NUnit.Framework;

namespace HighchartsTest
{
    [TestFixture]
    internal class Test:Helper
    {
        
        [Test]
        public void Test1()
        {
            BLL.OpenMainPage();
            BLL.HoverElementsAndGetData();
        }
    }
}