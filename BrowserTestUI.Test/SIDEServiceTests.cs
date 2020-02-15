using BrowserTestUI.Core.Selenium.IDE;
using System;
using System.IO;
using Xunit;

namespace BrowserTestUI.Test
{
    public class SIDEServiceTests
    {
        private SIDEService _SUT;

        public SIDEServiceTests()
        {
            _SUT = new SIDEService();
        }

        [Fact]
        public void Test1()
        {
            var side = _SUT.OpenSIDEFile("./SIDETestFiles/GoogleSearch.side");

            Assert.NotNull(side);
        }
    }
}
