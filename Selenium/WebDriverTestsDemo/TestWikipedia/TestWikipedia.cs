using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWikipedia
{
    public class TestsWikipedia
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Create new Chrome insance
            driver = new ChromeDriver();

            // Navigate to Wikipedia
            driver.Url = "https://www.wikipedia.org/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_SearchForQAAndBestsPractice() 
        {
            
            driver.FindElement(By.Id("searchInput")).Click();
            driver.FindElement(By.Id("searchInput")).SendKeys("Quality assurance");
            driver.FindElement(By.CssSelector(".svg-search-icon")).Click();
            driver.FindElement(By.LinkText("Best practice")).Click();
            driver.FindElement(By.Id("firstHeading")).Click();
            
        }
    }
}