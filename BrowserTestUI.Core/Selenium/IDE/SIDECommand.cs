using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserTestUI.Core.Selenium.IDE
{
    public class SIDECommand
    {
        public Guid id { get; set; }
        public string comment { get; set; }
        public string command { get; set; }
        public string target { get; set; }
        public List<List<string>> targets { get; set; }
        public string value { get; set; }
    }
}
