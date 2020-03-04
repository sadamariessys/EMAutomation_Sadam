using OpenQA.Selenium;

namespace EMAutomation
{
    internal class BaseEditorialManagerPage
    {
        protected IWebDriver Driver { get; set; }
        public BaseEditorialManagerPage(IWebDriver driver)
        {
         Driver = driver;
        }

    }

}