using System;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverDemo
{
    public class DriverHelper<T>
    {
        public IWebDriver PageDriver { get; set; }
        public string SearchTerm { get; set; }
        public ElementHelper Element { get; internal set; }

        public DriverHelper()
        {
            const string chromeDriverLocation = @"C:\Users\Madeline\Documents\training\chromedriver_win32";
            PageDriver = new ChromeDriver(chromeDriverLocation);
        }

        public void WaitImplicitly(int waitSeconds)
        {
            PageDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
        }

        public void FindMatchingElements(By idToFind, string elementName)
        {
            var elements = PageDriver.FindElements(idToFind);
            if (elements.Count == 0) throw new Exception("Not Found: " + elementName);

            ElementHelper helper = new ElementHelper(PageDriver, elements);
            Element = helper;
        }

        public void GoToUrl(string pageUrl)
        {
            PageDriver.Url = pageUrl;
        }

    }
}