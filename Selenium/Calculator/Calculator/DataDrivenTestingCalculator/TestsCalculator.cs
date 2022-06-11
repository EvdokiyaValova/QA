using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class TestsCalculator
    {
        private ChromeDriver driver;
       
        [OneTimeSetUp]
        public void Setup()
        {            
            driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
        }

        [OneTimeTearDown]
        public void TearDoun() 
        {
            driver.Quit();
        }

        [Test]
        public void Test_Calculator()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculateButton = driver.FindElement(By.Id("calcButton"));
            var clearField = driver.FindElement(By.Id("resetButton"));
            var resultField = driver.FindElement(By.Id("result"));

            //Act
            field1.SendKeys("7");
            operation.SendKeys("+");
            field2.SendKeys("2");
            calculateButton.Click();
            var expected = "Result: 9";

            //Assert
            Assert.That(expected, Is.EqualTo(resultField.Text));

            clearField.Click();
        }

        [TestCase("3", "+", "6", "Result: 9")]
        [TestCase("-3", "+", "6", "Result: 3")]
        [TestCase("3", "+", "-6", "Result: -3")]
        [TestCase("0", "+", "6", "Result: 6")]
        [TestCase("3", "+", "0", "Result: 3")]
        [TestCase("3", "-", "6", "Result: -3")]
        [TestCase("7", "-", "6", "Result: 1")]
        [TestCase("3", "-", "-6", "Result: 9")]
        [TestCase("-3", "-", "-6", "Result: 3")]
        [TestCase("0", "-", "6", "Result: -6")]
        [TestCase("-3", "-", "0", "Result: -3")]
        [TestCase("-3", "*", "0", "Result: 0")]
        [TestCase("0", "*", "2", "Result: 0")]
        [TestCase("-3", "*", "-3", "Result: 9")]
        [TestCase("2", "*", "4", "Result: 8")]
        [TestCase("2", "*", "-3", "Result: -6")]
        [TestCase("-2", "*", "3", "Result: -6")]
        [TestCase("4", "/", "2", "Result: 2")]
        [TestCase("-4", "/", "2", "Result: -2")]
        [TestCase("4", "/", "-2", "Result: -2")]
        [TestCase("0", "/", "4", "Result: 0")]
        [TestCase("4", "/", "0", "Result: Infinity")]
        [TestCase("3", "/", "1.5", "Result: 2")]
        public void Test_CalculatorWebApp_ValidNumber(string num1, string op, string num2, string expectedResult)
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculateButton = driver.FindElement(By.Id("calcButton"));
            var clearField = driver.FindElement(By.Id("resetButton"));
            var resultField = driver.FindElement(By.Id("result"));

            //Act
            clearField.Click();
            field1.SendKeys(num1);
            operation.SendKeys(op);
            field2.SendKeys(num2);
            calculateButton.Click();
            var expected = expectedResult;

            //Assert
            Assert.That(expected, Is.EqualTo(resultField.Text));            
        }

        [TestCase("Text", "+", "1", "Result: invalid input")]
        [TestCase("Text", "+", "Text", "Result: invalid input")]
        [TestCase("2", "+", "Text", "Result: invalid input")]
        [TestCase("2", "-", "", "Result: invalid input")]
        [TestCase("", "-", "5", "Result: invalid input")]
        [TestCase("1", "!", "5", "Result: invalid operation")]
        [TestCase("1", "@", "5", "Result: invalid operation")]
        [TestCase(",", "+", ",", "Result: invalid input")]
        public void Test_CalculatorWebApp_InvalidNumber(string num1, string op, string num2, string expectedResult)
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculateButton = driver.FindElement(By.Id("calcButton"));
            var clearField = driver.FindElement(By.Id("resetButton"));
            var resultField = driver.FindElement(By.Id("result"));

            //Act
            clearField.Click();
            field1.SendKeys(num1);
            operation.SendKeys(op);
            field2.SendKeys(num2);
            calculateButton.Click();
            var expected = expectedResult;

            //Assert
            Assert.That(expected, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Calculator_Reset()
        {
            //Arrange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculateButton = driver.FindElement(By.Id("calcButton"));
            var clearField = driver.FindElement(By.Id("resetButton"));
            var resultField = driver.FindElement(By.Id("result"));

            var page = field1.Text + field2.Text + operation.Text + resultField.Text;

            //Act
            field1.SendKeys("7");
            operation.SendKeys("+");
            field2.SendKeys("2");
            calculateButton.Click();

            //Assert
            Assert.IsFalse(page == string.Empty);

            clearField.Click();

            Assert.IsTrue(page != string.Empty);
        }
    }
}