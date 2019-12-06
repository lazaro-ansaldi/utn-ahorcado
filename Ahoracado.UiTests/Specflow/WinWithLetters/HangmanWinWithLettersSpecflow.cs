using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Ahoracado.UiTests.Specflow.WinWithLetters
{
    [Binding]
    public sealed class HangmanWinWithLettersSpecflow : BaseTest
    {
        [BeforeScenario]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(@"C:\Projects\UTN\utn-ahorcado\Ahoracado.UiTests\bin\Debug");
        }

        [Given(@"I have entered Test as the wordToGuess")]
        public void GivenIHaveEnteredTestAsTheWordToGuess()
        {
            _driver.Navigate().GoToUrl("https://localhost:44310/Home/Index");
            StartGame("Test");
        }

        [When(@"I enter t as the first typedLetter")]
        public void WhenIEnterTheFirstLetter()
        {
            ProbarLetra("t");
        }

        [When(@"I enter e as the second typedLetter")]
        public void WhenIEnterTheSecondLetter()
        {
            ProbarLetra("e");
        }

        [When(@"I enter s as the third typedLetter")]
        public void WhenIEnterTheThirdLetter()
        {
            ProbarLetra("s");
        }

        [When(@"I enter t as the fourth typedLetter")]
        public void WhenIEnterTheFourthLetter()
        {
            ProbarLetra("t");
        }

        [Then(@"I should be told that I win")]
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
