using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace TestSearchInWikipedia
{
    public class TestsSearchForQA
    {
        
        private readonly IWebDriver driver;

        public TestsSearchForQA()
        {
            this.driver = new ChromeDriver();
        }


        [SetUp]
        public void SetUp()
        {            
            driver.Url = "https://wikipedia.org";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        

        [Test]
        public void openWikipediaAndSearchForQA()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Size = new System.Drawing.Size(1536, 774);
            driver.FindElement(By.Id("searchInput")).Click();
            driver.FindElement(By.Id("searchInput")).SendKeys("Quality assurance");
            driver.FindElement(By.CssSelector(".svg-search-icon")).Click();
            driver.FindElement(By.Id("firstHeading")).Click();
            Assert.That(driver.FindElement(By.Id("firstHeading")).Text, Is.EqualTo("Quality assurance"));
            driver.FindElement(By.CssSelector("ul:nth-child(56) > li:nth-child(1)")).Click();
            driver.FindElement(By.LinkText("Best practice")).Click();
            driver.FindElement(By.Id("firstHeading")).Click();
            Assert.That(driver.FindElement(By.Id("firstHeading")).Text, Is.EqualTo("Best practice"));
            driver.Close();
        }
        
    }

}