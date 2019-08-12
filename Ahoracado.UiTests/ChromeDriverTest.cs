using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ahoracado.UiTests
{
    [TestClass]
    public class ChromeDriverTest
    {
        private ChromeDriver _driver;
        private static string CurrentPlayer => "Tester";

        #region Page Controls
        private IWebElement TxtNombreJugador => _driver.FindElementByName("PlayerName");
        private IWebElement TxtSecretWord => _driver.FindElementByName("SecretWord");
        private IWebElement BtnStart => _driver.FindElementById("btnStartGame");
        private IWebElement TxtTryLetter => _driver.FindElementByName("LetterToTry");
        private IWebElement BtnTryLetter => _driver.FindElementById("btnStartGame");
        private IWebElement TxtLetrasAcertadas => _driver.FindElementById("LetrasAcertadas");
        private IWebElement TxtMessageResult => _driver.FindElementById("MessageResult");
        #endregion

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [TestMethod]
        public void WinGame()
        {
            
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            // Start Page
            TxtNombreJugador.SendKeys(CurrentPlayer);
            TxtSecretWord.SendKeys("a");
            BtnStart.Click();

            TxtTryLetter.SendKeys("a");
            BtnTryLetter.Click();

            Assert.AreEqual("1", TxtLetrasAcertadas.Text);
            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }


        [TestMethod]
        public void LostGame()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            // Start Page
            TxtNombreJugador.SendKeys(CurrentPlayer);
            TxtSecretWord.SendKeys("Lost");
            BtnStart.Click();

            for (int i = 0; i < 7; i++)
            {
                TxtTryLetter.SendKeys("a");
                BtnTryLetter.Click();
            }

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha perdido la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            Assert.AreEqual("Game - Ahorcado.Mvc", _driver.Title);
        }

        [TestCleanup]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
