using BrowserTestUI.Core;
using BrowserTestUI.Core.Selenium;
using BrowserTestUI.Core.Selenium.IDE;
using System;
using System.IO;
using System.Linq;

namespace BrowserTestUI.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Browser Test UI command line interface!");
            if(args.Count() < 1)
            {
                Console.WriteLine("Please provide the path to an SIDE file to execute.");
            }
            else
            {
                var filePath = args.First();
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"The file {filePath} could not be found or is not accessible.");
                }
                else
                {
                    var seleniumService = new SeleniumService();
                    var sideService = new SIDEService();

                    Console.WriteLine($"Opening {filePath}...");
                    var sideFile = sideService.OpenSIDEFile(filePath);
                    Console.WriteLine($"File {filePath} opened.");

                    Console.WriteLine($"Preparing to run Selenium test suite: {sideFile.name}");
                    var testTask = seleniumService.RunSIDETestSuite(sideFile, BrowserEnum.Firefox);
                    testTask.Wait();
                    Console.WriteLine($"Test suite: {sideFile.name} run successfully.");
                }
            }
        }
    }
}
