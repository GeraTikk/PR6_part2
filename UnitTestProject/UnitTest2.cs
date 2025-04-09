using Microsoft.VisualStudio.TestTools.UnitTesting;
using GermanKursach;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var authWindow = new MainWindow();
            Assert.IsTrue(authWindow.Auth("client1", "pass123"));

        }
    }
}
