using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ahoracado.UiTests
{
    public abstract class BaseTest
    {
        protected ChromeDriver _driver;
        protected static string CurrentPlayer => "Tester";

        #region Page Controls
        protected IWebElement TxtNombreJugador => _driver.FindElementByName("PlayerName");
        protected IWebElement TxtSecretWord => _driver.FindElementByName("SecretWord");
        protected IWebElement BtnStart => _driver.FindElementById("btnStartGame");
        protected IWebElement TxtTryLetter => _driver.FindElementByName("LetterToTry");
        protected IWebElement BtnTryLetter => _driver.FindElementById("btnStartGame");
        protected IWebElement TxtLetrasAcertadas => _driver.FindElementById("LetrasAcertadas");
        protected IWebElement TxtMessageResult => _driver.FindElementById("MessageResult");
        #endregion

        protected void ProbarLetra(string letra)
        {
            TxtTryLetter.Clear();
            TxtTryLetter.SendKeys(letra);
            BtnTryLetter.Click();
        }

        protected void StartGame(string palabra)
        {
            TxtNombreJugador.SendKeys(CurrentPlayer);
            TxtSecretWord.SendKeys(palabra);
            BtnStart.Click();
        }
    }
}
