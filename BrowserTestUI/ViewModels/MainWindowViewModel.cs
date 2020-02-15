using Avalonia;
using Avalonia.Controls;
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
        public string Greeting => "Welcome to Avalonia!";

        public async Task OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Selenium IDE Tests", Extensions = { "side" } });

            var result = await dialog.ShowAsync(new Window());

            if(result.Any())
            {
                var filePath = result.First();
                var contents = File.ReadAllText(filePath);
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }    
}
