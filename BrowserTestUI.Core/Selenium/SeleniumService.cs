using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTestUI.Core.Selenium
{
    public class SeleniumService
    {
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
    }
}
