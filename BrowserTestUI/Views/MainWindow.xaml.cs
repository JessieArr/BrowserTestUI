using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BrowserTestUI.Core.Selenium;

namespace BrowserTestUI.Views
{
    public class MainWindow : Window
    {
        private SeleniumService _SeleniumService;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _SeleniumService = new SeleniumService();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            _SeleniumService.RunFirefoxTest();
        }
    }
}
