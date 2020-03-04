using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace EMAutomation
{
    internal class EditorialMainPage : BaseEditorialManagerPage
    {
        

        public EditorialMainPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {

            get
            {
                return Driver.Title.Contains("Editorial Manager");
            }
            internal set { }
        }

        public IWebElement UsernameFiled => Driver.FindElement(By.Id("username"));

        public IWebElement Password => Driver.FindElement(By.Id("passwordTextbox"));
        public IWebElement AuthorLoginButton => Driver.FindElement(By.Name("authorLogin"));

        public IWebElement ReviewerLoginButton => Driver.FindElement(By.Name("reviewerLogin"));

        public IWebElement EditorLoginButton => Driver.FindElement(By.Name("editorLogin"));

        public IWebElement PublisherLoginButon => Driver.FindElement(By.Name("publisherLogin"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://testweb.editorialmanager.com/shayladev170/default.aspx");
            Assert.IsTrue(IsVisible, "Editorial Manager Page Was Not Visible");
        }

        internal void LoginLink()
        {
            Driver.SwitchTo().ParentFrame().SwitchTo().Frame("menuPage");
            Thread.Sleep(3000);

            Driver.FindElement(By.XPath("//*[@title='Login']")).Click();

            Driver.SwitchTo().ParentFrame().SwitchTo().Frame("content");
            Thread.Sleep(3000);
        }

        internal UserAccountLogged FilloutAndUserLogin(TestUser user)
        {


            Driver.SwitchTo().ParentFrame().SwitchTo().Frame("menuPage");
            
            Driver.FindElement(By.XPath("//*[@title='Login']")).Click();

            Driver.SwitchTo().ParentFrame().SwitchTo().Frame("content");
            
            

            UsernameFiled.SendKeys(user.Username);

            Password.SendKeys(user.Password);

            SelectingUserRole(user);




            

            Thread.Sleep(3000);
            Driver.SwitchTo().Frame("menuPage");



            return new UserAccountLogged(Driver);



        }

        private void SelectingUserRole(TestUser user)
        {
            switch (user.UserType)
            {
                case UserRole.Author:
                    AuthorLoginButton.Click();
                    break;
                case UserRole.Reviewer:
                    ReviewerLoginButton.Click();
                    break;
                case UserRole.Editor:
                    EditorLoginButton.Click();
                    break;
                case UserRole.Publisher:
                    PublisherLoginButon.Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

    