using BrowserTestUI.Core.Selenium.IDE;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTestUI.Core.Selenium
{
    public class SeleniumService
    {
        private SIDEService _SIDEService;

        public SeleniumService()
        {
            _SIDEService = new SIDEService();
        }

        public void RunFirefoxTest()
        {
            Task.Factory.StartNew(() =>
            {
                var service = FirefoxDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                var driver = new FirefoxDriver(service);
                driver.Url = "https://google.com";
                driver.Close();
                driver.Quit();
            });            
        }

        public void RunSIDETestSuite(SIDEFile file)
        {
            Task.Factory.StartNew(() =>
            {
                var service = FirefoxDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                var driver = new FirefoxDriver(service);
                driver.Url = file.url;

                foreach(var test in file.tests)
                {
                    foreach(var command in test.commands)
                    {
                        if(command.command == "setWindowSize")
                        {
                            var split = command.target.Split('x');
                            var width = Int32.Parse(split[0]);
                            var height = Int32.Parse(split[1]);
                            var window = driver.Manage().Window;
                            window.Size = new System.Drawing.Size(width, height);
                        }
                        if(command.command == "click")
                        {
                            IWebElement element = _SIDEService.TryFindElementForCommand(driver, command);
                            if(element != null)
                            {
                                element.Click();
                            }
                        }
                        if(command.command == "type")
                        {
                            IWebElement element = _SIDEService.TryFindElementForCommand(driver, command);
                            if (element != null)
                            {
                                element.SendKeys(command.value);
                            }
                        }
                    }
                }

                driver.Close();
                driver.Quit();
            });
        }
    }
}
