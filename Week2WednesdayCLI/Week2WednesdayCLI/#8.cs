using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Week2WednesdayCLI
{
    class number8
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            driver.Navigate().GoToUrl("https://www.google.com");
            var screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("screenshot.png");
            driver.Close();
            driver.Quit();
        }
    }
}