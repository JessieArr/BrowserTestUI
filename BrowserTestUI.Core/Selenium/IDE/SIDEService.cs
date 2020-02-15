using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrowserTestUI.Core.Selenium.IDE
{
    public class SIDEService
    {
        public SIDEFile OpenSIDEFile(string path)
        {
            var fileText = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SIDEFile>(fileText);
        }

        public IWebElement TryFindElementForCommand(RemoteWebDriver driver, SIDECommand command)
        {
            IWebElement element = null;
            foreach (var target in command.targets)
            {
                var type = target[1];
                var argument = target[0];

                if (type == "name")
                {
                    var name = argument.Split("=")[1];
                    element = driver.FindElementByName(name);
                }
                if (type == "css:finder")
                {
                    var cssClass = argument.Split("=")[1];
                    element = driver.FindElementByCssSelector(cssClass);
                }
                if (type == "xpath:attributes")
                {
                    var xpath = argument.Split("=")[1];
                    element = driver.FindElementByXPath(xpath);
                }
                if (type == "xpath:idRelative")
                {
                    var xpath = argument.Split("=")[1];
                    element = driver.FindElementByXPath(xpath);
                }
                if (type == "xpath:position")
                {
                    var xpath = argument.Split("=")[1];
                    element = driver.FindElementByXPath(xpath);
                }
                if (element != null)
                {
                    return element;
                }
            }
            return null;
        }
    }
}
