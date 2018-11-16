using OpenQA.Selenium;

namespace WebDriverDemo
{
    public class Google
    {
        public DriverHelper<IWebDriver> GooglePageDriver { get; set; }
        public string PageUrl { get; set; }
        public string SearchTerm { get; set; }

        public Google(string searchTerm)
        {
            const string pageUrl = "http://www.google.com";
            PageUrl = pageUrl;
            SearchTerm = searchTerm;
            GooglePageDriver = new DriverHelper<IWebDriver>();

            GooglePageDriver.GoToUrl(PageUrl);

            const int implicitWaitTime = 10;
            GooglePageDriver.WaitImplicitly(implicitWaitTime);
        }

        public void ClickOnPrivacyReminder()
        {
            By privacyReminderLocator = By.Id("cnsd");
            GooglePageDriver.FindMatchingElements(privacyReminderLocator, "Privacy Reminder");
            GooglePageDriver.Element.Click();
        }

        public void SubmitSearchCondition(string searchTerm)
        {
            By searchBoxLocator = By.Name("q");
            string searchBoxText = "Search Box";

            GooglePageDriver.FindMatchingElements(searchBoxLocator, searchBoxText);
            GooglePageDriver.Element.TypeIntoBox(searchTerm);
            GooglePageDriver.Element.Submit();
        }

        public void LocateLink()
        {
            By googleLinksLocator = By.ClassName("q");
            string googleLinksText = "Google Links";

            GooglePageDriver.FindMatchingElements(googleLinksLocator, googleLinksText);

            string havingLinkText = "Images";

            GooglePageDriver.Element.SelectElementByMatchedText(havingLinkText);
            GooglePageDriver.Element.Click();
        }

        public void LocateAllImages()
        {
            By searchResultsLocator = By.Id("rg");
            string searchResultsText = "Search Results";

            GooglePageDriver.FindMatchingElements(searchResultsLocator, searchResultsText);
        }

        public void ClickFirstImage(string havingLinkText)
        {
            By imageLinkLocator = By.TagName("div");
            string imageLinkText = "Element with a TagName of <Div>";

            GooglePageDriver.Element.LocateSubElements(imageLinkLocator, imageLinkText);

            GooglePageDriver.Element.SelectElementByContainsText(havingLinkText);
            GooglePageDriver.Element.Click();
        }
    }
}
