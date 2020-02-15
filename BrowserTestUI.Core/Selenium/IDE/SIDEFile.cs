using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserTestUI.Core.Selenium.IDE
{
    public class SIDEFile
    {
        public Guid id { get; set; }
        public string version { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public List<SIDETest> tests { get; set; }
        public List<SIDESuite> suites { get; set; }
        public List<string> urls { get; set; }
        public List<JObject> plugins { get; set; }
    }
}
