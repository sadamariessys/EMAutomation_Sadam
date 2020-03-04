using System;
using OpenQA.Selenium;

namespace EMAutomation
{
    internal class UserAccountLogged : BaseEditorialManagerPage
    {
        

        public UserAccountLogged(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                try
                {
                    return UserLogged.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement UserLogged => Driver.FindElement(By.XPath("//*[@title='Logout']"));
    }
}