using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserTestUI.Core.Selenium.IDE
{
    public class SIDESuite
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public bool persistSession { get; set; }
        public bool parallel { get; set; }
        public int timeout { get; set; }
        public List<Guid> tests { get; set; }
    }
}
