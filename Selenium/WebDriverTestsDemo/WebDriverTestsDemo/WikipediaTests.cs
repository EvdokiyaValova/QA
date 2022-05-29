using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

// Create new Chrome insance
var driver = new ChromeDriver();

// Navigate to Wikipedia
driver.Url = "https://wikipedia.org";

Console.WriteLine("CURRENT TITLE: " + driver.Title);

//locate Search field by ID
var searchField = driver.FindElement(By.Id("searchInput"));

//Click on element
searchField.Click();

//fill QA and press ENTER keyboard  button
searchField.SendKeys("QA" + Keys.Enter);

Console.WriteLine("TITLE AFTER SEARCH: " + driver.Title);

//Close browser
driver.Quit();
