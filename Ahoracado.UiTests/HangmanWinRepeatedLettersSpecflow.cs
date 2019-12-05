using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Ahoracado.UiTests
{
    [Binding]
    public class HangmanWinRepeatedLettersSpecflow : BaseTest
    {
        [BeforeScenario]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [Given(@"I have entered fees as the wordToGuess")]
        public void GivenIHaveEnteredTestAsTheWordToGuess()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");
            StartGame("fees");
        }

        [When(@"I try the letter f")]
        public void WhenIEnterFAsTheFirstLetter()
        {
            ProbarLetra("f");
        }

        [When(@"I try the letter e")]
        public void WhenIEnterEAsTheSecondLetter()
        {
            ProbarLetra("e");
        }

        [When(@"I try the letter s")]
        public void WhenIEnterSAsTheFirstLetter()
        {
            ProbarLetra("s");
        }

        [Then(@"I should be told that I win the game")]
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
