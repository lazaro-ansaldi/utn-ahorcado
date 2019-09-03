using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Ahoracado.UiTests
{
    [TestClass]
    public class ChromeDriverTest : BaseTest
    {
        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [TestMethod]
        public void WinGame()
        {  
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            StartGame("hola");

            ProbarLetra("h");
            ProbarLetra("o");
            ProbarLetra("l");
            ProbarLetra("a");

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void WinGameSameLetters()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            StartGame("casa");

            ProbarLetra("c");
            ProbarLetra("s");
            ProbarLetra("a");

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void WinGameWithWord()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            StartGame("casa");

            ProbarLetra("c");
            ProbarLetra("l");
            ProbarLetra("casa");

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void LostGameWithWord()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            StartGame("casa");

            ProbarLetra("c");
            ProbarLetra("l");
            ProbarLetra("sarasa");

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha perdido la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void WinGameWithAccents()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");

            StartGame("canción");

            ProbarLetra("cAnCióN");

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }

        [TestMethod]
        public void LostGame()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");
            StartGame("lost");

            for (int i = 0; i < 7; i++)
            {
                ProbarLetra("a");
            }

            Assert.AreEqual($"El jugador: {CurrentPlayer} ha perdido la partida", TxtMessageResult.Text);
        }

        [TestCleanup]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
