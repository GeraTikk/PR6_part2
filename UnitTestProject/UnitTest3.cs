using GermanKursach;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var authWindow = new MainWindow();
            Assert.IsTrue(authWindow.Auth("admin", "admin123"));
            Assert.IsTrue(authWindow.Auth("client1", "pass123"));
            Assert.IsTrue(authWindow.Auth("employee1", "emp123"));
            Assert.IsTrue(authWindow.Auth("employee2", "Emp456"));
            Assert.IsTrue(authWindow.Auth("driver3", "securePass5"));
            Assert.IsTrue(authWindow.Auth("user1", "securePass6"));
            Assert.IsTrue(authWindow.Auth("driver4", "securePass7"));
            Assert.IsTrue(authWindow.Auth("user2", "securePass8"));
            Assert.IsTrue(authWindow.Auth("driver5", "securePass9"));
            Assert.IsTrue(authWindow.Auth("user3", "securePass10"));
            Assert.IsTrue(authWindow.Auth("driver6", "securePass11"));
            Assert.IsTrue(authWindow.Auth("user4", "securePass12"));
            Assert.IsTrue(authWindow.Auth("sid", "sidsid11"));
        }
        [TestMethod]
        public void AuthTestFailure()
        {
            var authWindow = new MainWindow();
            Assert.IsFalse(authWindow.Auth("ttttt", "wrdw1234"));
            Assert.IsFalse(authWindow.Auth("client1", "admin123"));
            Assert.IsFalse(authWindow.Auth("", "pass123"));
            Assert.IsFalse(authWindow.Auth(" ", "pass123"));
            Assert.IsFalse(authWindow.Auth("client1", ""));
            Assert.IsFalse(authWindow.Auth("client1", " "));
            Assert.IsFalse(authWindow.Auth(" ", " "));
            Assert.IsFalse(authWindow.Auth("", ""));
            Assert.IsFalse(authWindow.Auth(" client1 ", "pass123"));
        }
    }
}
