using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM_Student_Registry.PageObjects;

namespace POM_Summator_last
{
    public class PropertiesAndMethodsTests
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_Two_Invailid_Numbers()
        {
            var page = new SumNumberPage(driver);
            page.OpenPage();
            string result = page.AddTwoNumbers("hi", "there");
            
            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }
        [Test]
        public void Test_Two_Numbers_And_Reset()
        {
            var page = new SumNumberPage(driver);
            page.OpenPage();

            string result = page.AddTwoNumbers("8", "5");
            bool isFormEmpty = page.IsFormEmpty();  
            Assert.That(isFormEmpty, Is.False); 
            
            page.PressResetButton();
            isFormEmpty = page.IsFormEmpty();
            Assert.That(isFormEmpty,Is.True);
        }
        [Test]
        public void Test_Two_Numbers()
        {
            var page = new SumNumberPage(driver);
            page.OpenPage();

            string result = page.AddTwoNumbers("8", "5");
            var expected_result = "Sum: 13"; 
            Assert.That(result, Is.EqualTo(expected_result));

        }
    }
}