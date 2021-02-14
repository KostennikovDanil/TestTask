using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimbirSoftTask;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        public string Pars()
        {
            string site = "https://theuselessweb.com/";
            string str = Parser.Pars(site);
            str = Parser.HtmlPars(str);
            return str;
        }
        [TestMethod]
        public void ParsTest()
        {
            string str = Pars();
            Assert.AreEqual(201, str.Length); 
        }
        [TestMethod]
        public void WordsTest()
        {
            string str = Pars();
            List<string> words = WorkingWithWords.MakeListOfWords(str);
            List<UnicWord> unicWords = WorkingWithWords.MakeListOfUnicWords(words);
            Assert.AreEqual(37, words.Count);
            Assert.AreEqual("the", words[0]);
            Assert.AreEqual(30, unicWords.Count);
            Assert.AreEqual("the", unicWords[0].Word);
            Assert.AreEqual(3, unicWords[0].AmountOfAppearence);
        }

    }
}
