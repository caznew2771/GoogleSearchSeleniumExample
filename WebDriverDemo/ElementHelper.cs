using System;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverDemo
{
    public class ElementHelper
    {
        public IWebElement LastFoundElement { get; set; }
        public ReadOnlyCollection<IWebElement> LastFoundCollectionOfElements { get; set; }

        public ElementHelper(IWebDriver pageDriver, ReadOnlyCollection<IWebElement> elements)
        {
            LastFoundCollectionOfElements = elements;
            LastFoundElement = LastFoundCollectionOfElements[0];
        }

        public void TypeIntoBox(string searchTerm)
        {
            if (LastFoundElement == null) throw new Exception("No <LastFoundElement> to TypeIntoBox");

            LastFoundElement.SendKeys(searchTerm);
        }

        public void Submit()
        {
            if (LastFoundElement == null) throw new Exception("No <LastFoundElement> to Submit");

            LastFoundElement.Submit();
        }

        public void SelectElementByContainsText(string linkTextToSelect)
        {
            if (LastFoundCollectionOfElements == null) throw new Exception("No <LastFoundCollectionOfElements> to Click");

            for (var i = 0; i < LastFoundCollectionOfElements.Count; i++)
            {
                string elementText = LastFoundCollectionOfElements[i].Text;
                if (elementText.Contains(linkTextToSelect))
                {
                    LastFoundElement = LastFoundCollectionOfElements[i];
                    return;
                }
            }
        }

        public void SelectElementByMatchedText(string linkTextToSelect)
        {
            if (LastFoundCollectionOfElements == null) throw new Exception("No <LastFoundCollectionOfElements> to Click");

            for (var i = 0; i < LastFoundCollectionOfElements.Count; i++)
            {
                string elementText = LastFoundCollectionOfElements[i].Text;
                if (elementText == linkTextToSelect)
                {
                    LastFoundElement = LastFoundCollectionOfElements[i];
                    return;
                }
            }
        }

        public void LocateSubElements(By idToFind, string elementName)
        {
            if (LastFoundElement == null) throw new Exception("No <LastFoundElement> to LocateSubElement");

            var elements = LastFoundElement.FindElements(idToFind);
            if (elements.Count == 0) throw new Exception("Not Found: " + elementName);

            LastFoundCollectionOfElements = elements;
            LastFoundElement = LastFoundCollectionOfElements[0];
        }

        public void Click()
        {
            if (LastFoundElement == null) throw new Exception("No <LastFoundElement> to Click");

            LastFoundElement.Click();
        }

    }
}
