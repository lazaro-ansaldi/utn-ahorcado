using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Ahoracado.UiTests
{
    [Binding]
    public class HangmanSpecflow : BaseTest
    {
        [BeforeScenario]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [Given(@"I have entered Test as the wordToGuess")]
        public void GivenIHaveEnteredTestAsTheWordToGuess()
        {
            StartGame("Test");
        }

        [When(@"I enter X as the typedLetter seven times")]
        public void WhenIEnterXAsTheTypedLetterFiveTimes()
        {
            ProbarLetra("x");
            ProbarLetra("x");
            ProbarLetra("x");
            ProbarLetra("x");
            ProbarLetra("x");
            ProbarLetra("x");
            ProbarLetra("x");
        }

        [Then(@"I should be told that I lost")]
        public void ThenIShouldBeToldThatILost()
        {
            Assert.AreEqual($"El jugador: {CurrentPlayer} ha perdido la partida", TxtMessageResult.Text);
        }

        [AfterScenario]
        public void ChromeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
