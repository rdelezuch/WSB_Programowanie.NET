using Microsoft.VisualStudio.TestTools.UnitTesting;
using PESELWalidator;
using System;

namespace UnitTestSystemBankowy
{
    [TestClass]
    public class PeselWalidatorTest
    {
        PeselWalidator walidator;
        PeselWalidator walidatorDwa;
        [TestInitialize]
        public void PrzygotujWalidator()
        {
            walidator = new PeselWalidator("96050305615");
            walidatorDwa = new PeselWalidator("02270803624");
        }
        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowyNumer()
        {
            bool wynik = walidator.SprawdzPesel("96050305615");
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaKrotkiNumer()
        {
            bool wynik = walidator.SprawdzPesel("96050305");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaDlugiNumer()
        {
            bool wynik = walidator.SprawdzPesel("96050305234232");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaNieprawidlowyNumer()
        {
            bool wynik = walidator.SprawdzPesel("9605av05615");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowaPlec()
        {
            string wynik = walidator.Plec();
            Assert.AreEqual("Mężczyzna", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowaDataUrodzin()
        {
            string wynik = walidator.DataUrodzenia();
            Assert.AreEqual("03.05.1996", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowoSumeKontrolna()
        {
            int wynik = walidator.SumaKontrolna();
            Assert.AreEqual(5, wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowaPlecDwaTysiace()
        {
            string wynik = walidatorDwa.Plec();
            Assert.AreEqual("Kobieta", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowaDataUrodzinDwaTysiace()
        {
            string wynik = walidatorDwa.DataUrodzenia();
            Assert.AreEqual("08.07.2002", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaPrawidlowoSumeKontrolnaDwaTysiace()
        {
            int wynik = walidatorDwa.SumaKontrolna();
            Assert.AreEqual(4, wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaNiePrawidlowaPlec()
        {
            string wynik = walidator.Plec();
            Assert.AreNotEqual("Kobieta", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaNiePrawidlowaDataUrodzin()
        {
            string wynik = walidator.DataUrodzenia();
            Assert.AreNotEqual("03.06.1996", wynik);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaNiePrawidlowoSumeKontrolna()
        {
            int wynik = walidator.SumaKontrolna();
            Assert.AreNotEqual(6, wynik);
        }
    }
}
