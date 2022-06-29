using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace SeleniumWaitsAndPOM
{

    public class Tests_Waits
    {
        public WebDriver driver;
        public WebDriverWait wait;

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_Wait_Thread_Sleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            var element = driver.FindElement(By.PartialLinkText("This is"));
            element.Click();

            Thread.Sleep(15000);
            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element);



        }
        [Test]
        public void Test_Implicid_Wait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();



            var text_element = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsNotEmpty(text_element);



        }
        [Test]
        public void Test_Explicid_Wait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var elementTowait = this.wait.Until(d =>
            {
                return d.FindElement(By.PartialLinkText("This is")).Text;
            });

            Assert.IsNotEmpty(elementTowait);



        }
        [Test]
        public void Test_Expected_Conditions_Wait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Url = "http://www.uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var elementTowait = this.wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("This is")));

            Assert.IsNotEmpty(elementTowait.Text);



        }
    }
}

