using Avalonia;
using Avalonia.Controls;
using BrowserTestUI.Core.Selenium;
using BrowserTestUI.Core.Selenium.IDE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTestUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private SeleniumService _SeleniumService;
        private SIDEService _SIDEService;

        public string Greeting => "Welcome to Avalonia!";
        public SIDEFile CurrentFile;

        public MainWindowViewModel()
        {
            _SeleniumService = new SeleniumService();
            _SIDEService = new SIDEService();
        }

        public async Task OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Selenium IDE Tests", Extensions = { "side" } });

            var result = await dialog.ShowAsync(new Window());

            if(result.Any())
            {
                var filePath = result.First();
                CurrentFile = _SIDEService.OpenSIDEFile(filePath);
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void RunTest()
        {
            if(CurrentFile == null)
            {
                _SeleniumService.RunFirefoxTest();
            }
            else
            {
                _SeleniumService.RunSIDETestSuite(CurrentFile);
            }
        }
    }    
}
