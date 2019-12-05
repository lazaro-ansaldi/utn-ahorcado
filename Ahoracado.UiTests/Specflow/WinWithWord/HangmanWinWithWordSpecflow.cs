using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Ahoracado.UiTests.Specflow.WinWithWord
{
    [Binding]
    public class HangmanWinWithWordSpecflow : BaseTest
    {
        [BeforeScenario]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [Given(@"I have entered house as the wordToGuess")]
        public void GivenIHaveEnteredHouseAsTheWordToGuess()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");
            StartGame("house");
        }

        [When(@"I try the letter h")]
        public void WhenITryTheLetterH()
        {
            ProbarLetra("h");
        }

        [When(@"I try the word house")]
        public void WhenITryTheWordHouse()
        {
            ProbarLetra("house");
        }

        [Then(@"I should be told that I win the game with word")]
        public void ThenIShouldBeToldThatILost()
        {
            Assert.AreEqual($"El jugador: {CurrentPlayer} ha ganado la partida", TxtMessageResult.Text);
        }

        [AfterScenario]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
