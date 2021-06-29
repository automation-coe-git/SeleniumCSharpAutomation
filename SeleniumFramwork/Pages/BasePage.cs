using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramwork.Pages
{

    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait driverWait;
        private TimeSpan timeOut = TimeSpan.FromSeconds(10);
        public BasePage(IWebDriver driver, TimeSpan Timeout)
        {
            this.driver = driver;
            driverWait = new WebDriverWait(driver, timeOut);
            this.timeOut = Timeout;
        }
        public void JSClick(IWebElement element)
        {
            if (element != null)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
        }
        public void JSClick(IWebElement element, bool value)
        {
            if (value == true)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
        }
        public string GetValueAsString(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public bool GetValueAsBool(IWebElement element)
        {
            if (element.GetAttribute("value") == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SelectDropdownByVisibleText(IWebElement element, string textToSelect)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(textToSelect);
        }
        public void SelectDropdownByIndex(IWebElement element, int indexToSelect)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(indexToSelect);
        }
        public void SelectDropdownByValue(IWebElement element, string valueToSelect)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(valueToSelect);
        }
        public string GetSelectedTextFromDropdown(IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            return select.SelectedOption.Text;
        }
        public void WaitForElementToBeVisible(By locator)
        {
            driverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitForElementToBeVisible(IWebElement element)
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void WaitForElementToBeClickable(By locator)
        {
            driverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitForElementToBeClickable(IWebElement element)
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void ScrolltoElement(IWebElement elememnt)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", elememnt);
        }
        public void ClickCheckbox(IWebElement element, bool value)
        {
            if (value == true)
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
        }
    }
}
