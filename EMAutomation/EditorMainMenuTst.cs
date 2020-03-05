using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace EMAutomation
{
    [TestClass]
    public class EditorMainMenu
    {
        private IWebDriver Driver { get; set; }
        internal EditorialMainPage EditorialMPage { get; private set; }
        internal TestUser TheTestUser { get; set; }

        [TestMethod, Description(
             "Validate Editorial Manager Website opens and User with Editor  Role can enter Login Successfully " +
             "Using valid username and password ")]
        public void EditorialManagerEditorLoginTest()
        {
            TheTestUser.UserType = UserRole.Editor;
            // verifying Editorial Manager page  opens 
            
            EditorialMPage.GoTo();
            EditorialMPage.LoginLink();
            // verifying the users can login 
            var userLoginAccountPage = EditorialMPage.FilloutAndUserLogin(TheTestUser);
            Assert.IsTrue(userLoginAccountPage.IsVisible, "User Account -  Unable to login");
            
        }


        [TestMethod, Description(
             "Validate Editorial Manager Website opens and User with Author  Role can enter Login Successfully " +
             "Using valid username and password ")]
        public void EditorialManagerAuthorLoginTest()
        {

            TheTestUser.UserType = UserRole.Author;
            // verifying Editorial Manager page  opens 
         
            EditorialMPage.GoTo();
            EditorialMPage.LoginLink();
            // verifying the users can login 
            var userLoginAccountPage = EditorialMPage.FilloutAndUserLogin(TheTestUser);
            Assert.IsTrue(userLoginAccountPage.IsVisible, "User Account -  Unable to login");

        }


        [TestMethod, Description(
             "Validate Editorial Manager Website opens and User with  Reviewer  Role can enter Login Successfully " +
             "Using valid username and password ")]
        public void EditorialManagerReviewerLoginTest()
        {
            TheTestUser.UserType = UserRole.Reviewer;
            // verifying Editorial Manager page  opens 
            
            EditorialMPage.GoTo();
            EditorialMPage.LoginLink();
            // verifying the users can login 
            var userLoginAccountPage = EditorialMPage.FilloutAndUserLogin(TheTestUser);
            Assert.IsTrue(userLoginAccountPage.IsVisible, "User Account -  Unable to login");

        }

        [TestMethod, Description(
             "Validate Editorial Manager Website opens and User with Publisher Role can enter Login Successfully " +
             "Using valid username and password ")]
        public void EditorialManagerPublisherLoginTest()
        {
            TheTestUser.UserType = UserRole.Publisher;
            // verifying Editorial Manager page  opens 
            
            EditorialMPage.GoTo();
            EditorialMPage.LoginLink();
            // verifying the users can login 
            var userLoginAccountPage = EditorialMPage.FilloutAndUserLogin(TheTestUser);
            Assert.IsTrue(userLoginAccountPage.IsVisible, "User Account -  Unable to login");

        }


        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return  new ChromeDriver(outPutDirectory);
        }
        [TestInitialize]
        public void SetUpForEveryTestMethod()
        {
            Driver = GetChromeDriver();
            EditorialMPage = new EditorialMainPage(Driver);

            TheTestUser = new TestUser
            {
                Username = "mary",
                Password = "test"
            };




        }

        

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }


    }
}
