using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Student_Registry.PageObjects
{

    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        const string PageUrl = "https://sum-numbers.nakov.repl.co/";

        public IWebElement field1 =>
            driver.FindElement(By.CssSelector("input[name='number1']"));

        public IWebElement field2 =>
            driver.FindElement(By.CssSelector("input[name='number2']"));

        public IWebElement calcbutton =>
            driver.FindElement(By.CssSelector("input#calcButton"));

        public IWebElement resetbutton =>
            driver.FindElement(By.CssSelector("input#resetButton"));

        public IWebElement result_fild =>
            driver.FindElement(By.CssSelector("#result"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
        public string AddTwoNumbers(string num1, string num2)
        {
            field1.SendKeys(num1);
            field2.SendKeys(num2);
            calcbutton.Click();
            string result = result_fild.Text;
            return result;
        }
        public void PressResetButton()
        {
            resetbutton.Click();
        }
        public bool IsFormEmpty()
        {
            return field1.Text + field2.Text + result_fild.Text == "";
        }


    }
}
