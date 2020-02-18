using BrowserTestUI.Core.Selenium.IDE;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

        public void RunSimpleTest(BrowserEnum browser)
        {
            Task.Factory.StartNew(() =>
            {
                RemoteWebDriver driver = null;
                try
                {
                    driver = GetBrowserDriverToRunInBackground(browser);
                    driver.Url = "https://google.com";
                }
                finally
                {
                    // No matter what, we always try to shut down the driver when we're done.
                    if(driver != null)
                    {
                        driver.Close();
                        driver.Quit();
                    }
                }
            });
        }

        public Task RunSIDETestSuite(SIDEFile file, BrowserEnum browser)
        {
            return Task.Factory.StartNew(() =>
            {
                RemoteWebDriver driver = null;
                try
                {
                    driver = GetBrowserDriverToRunInBackground(browser);
                    driver.Url = file.url;

                    foreach (var test in file.tests)
                    {
                        foreach (var command in test.commands)
                        {
                            if (command.command == "setWindowSize")
                            {
                                var split = command.target.Split('x');
                                var width = Int32.Parse(split[0]);
                                var height = Int32.Parse(split[1]);
                                var window = driver.Manage().Window;
                                window.Size = new System.Drawing.Size(width, height);
                            }
                            if (command.command == "click")
                            {
                                IWebElement element = _SIDEService.TryFindElementForCommand(driver, command);
                                if (element != null)
                                {
                                    element.Click();
                                }
                            }
                            if (command.command == "type")
                            {
                                IWebElement element = _SIDEService.TryFindElementForCommand(driver, command);
                                if (element != null)
                                {
                                    element.SendKeys(command.value);
                                }
                            }
                            Thread.Sleep(100);
                        }
                    }
                }
                finally
                {
                    // No matter what, we always try to shut down the driver when we're done.
                    if (driver != null)
                    {
                        driver.Close();
                        driver.Quit();
                    }
                }
            });
        }

        private RemoteWebDriver GetBrowserDriverToRunInBackground(BrowserEnum browser)
        {
            switch (browser)
            {
                case BrowserEnum.Firefox:
                    var firefoxService = FirefoxDriverService.CreateDefaultService();
                    firefoxService.HideCommandPromptWindow = true;
                    var firefoxDriver = new FirefoxDriver(firefoxService);
                    return firefoxDriver;
                case BrowserEnum.Chrome:
                    var chromeService = ChromeDriverService.CreateDefaultService();
                    chromeService.HideCommandPromptWindow = true;
                    var chromeDriver = new ChromeDriver(chromeService);
                    return chromeDriver;
                case BrowserEnum.InternetExplorer:
                    var internetExplorerService = InternetExplorerDriverService.CreateDefaultService();
                    internetExplorerService.HideCommandPromptWindow = true;
                    var internetExplorerDriver = new InternetExplorerDriver(internetExplorerService);
                    return internetExplorerDriver;
                case BrowserEnum.Edge:
                    var edgeService = EdgeDriverService.CreateDefaultService();
                    edgeService.HideCommandPromptWindow = true;
                    var options = new EdgeOptions();
                    var edgeDriver = new EdgeDriver(edgeService, options);
                    return edgeDriver;
                case BrowserEnum.Safari:
                    var safariService = SafariDriverService.CreateDefaultService();
                    safariService.HideCommandPromptWindow = true;
                    var safariDriver = new SafariDriver(safariService);
                    return safariDriver;
                default:
                    throw new Exception("Browser not found for provided enum value.");
            }
        }
    }
}
