using Microsoft.VisualStudio.TestTools.UnitTesting;
using GermanKursach;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void RegTestSuccess()
        {
            var regWin = new Registration();
            Assert.IsTrue(regWin.Reg("Тикконен Герман Вячеславович", "geratikk@yandex.ru", "+79150996538", "T777KK777", "gera", "Superme1", "Superme1"));
        }
        [TestMethod]
        public void RegTestFailure()
        {
            var regWin = new Registration();
            Assert.IsFalse(regWin.Reg("", "", "", "", "", "", ""));
            Assert.IsFalse(regWin.Reg("", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg(" ", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Даня", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов ", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил ", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Vibornov Daniil Romanovich", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", " ", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+9150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "89150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238423", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", " ", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A234AA", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "HHH234777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "465KTT433", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "233", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A456HT4567", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "234AA234", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "HH244HH243", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "P543HH32", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", " ", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "ivanov@example.com", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "geratikkyandexru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "fdshbajk", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "уафвмс", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "vsdddddvsc@", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", " ", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "ggggggggggdddddddddaaaaaaaaaannnnnnnnnniiiiiiiiiiyyyyyyaaaa", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "dan", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "admin", "hey12345!", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "", ""));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", " ", "hey12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", " ", " "));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "averfs1", "averfs1"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "averfsdfghjkiuyt6543278971", "averfsdfghjkiuyt6543278971"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "asdfghjkl", "asdfghjkl"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", ""));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", " "));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey1235!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "he12345!"));
            Assert.IsFalse(regWin.Reg("Выборнов Даниил Романович", "daniya@yandex.ru", "+79150766238", "A934HH777", "daniya", "hey12345!", "hey12345!!"));
        }
    }
}
