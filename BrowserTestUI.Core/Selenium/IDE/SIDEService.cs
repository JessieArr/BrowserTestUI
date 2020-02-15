using Newtonsoft.Json;
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
    }
}
