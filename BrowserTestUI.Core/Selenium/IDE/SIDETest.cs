using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserTestUI.Core.Selenium.IDE
{
    public class SIDETest
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public List<SIDECommand> commands { get; set; }
    }
}
