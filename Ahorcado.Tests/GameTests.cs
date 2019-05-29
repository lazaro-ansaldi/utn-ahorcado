using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.Tests
{
    [TestClass]
    public class GameTests
    {
        // 1- cargar palabra y que se haya pasado la correcta 
        // 2- ya paso cant cargar palabra y validar cant caracteres pasados
        // 3- carga de letra con contador que indique si tuvo error
        // 4- jugar contar errores y mostrar mensaje gano o perdio

        [TestMethod]
        public void CargarPalabra()
        {
            var testWord = "HOLA";

            var gameManager = new GameManager(testWord);

            Assert.AreEqual(testWord, gameManager.SecretWord);
        }

        [TestMethod]
        public void ValidarCantidad()
        {
            var testWord = "COMO";

            var gameManager = new GameManager(testWord);

            Assert.AreEqual(testWord.Length, gameManager.SecretCant);
        }

        [TestMethod]
        public void ValidarError()
        {
            var testWord = "ANDAS";
            var testLetra = "A";

            var gameManager = new GameManager(testWord);

            var validarLetra = gameManager.ContieneLetra(testLetra);

            Assert.IsTrue(validarLetra);
        }

        [TestMethod]
        public void ContarError()
        {
            var testWord = "ANDAS";
            var testLetra = "E";

            var gameManager = new GameManager(testWord);

            gameManager.ContieneLetra(testLetra);

            Assert.IsTrue(gameManager.CantidadErrores > 0);
        }

        [TestMethod]
        public void ProbarVictoria()
        {
            var testWord = "ANDAS";
            var gameManager = new GameManager(testWord);

            foreach (var letra in testWord)
            {
                var validarLetra = gameManager.ContieneLetra(letra.ToString());
            }

            Assert.IsTrue(gameManager.CantidadErrores == 0);
        }

        [TestMethod]
        public void ProbarDerrota()
        {
            var testWord = "ANDAS";
            var palabraJugada = "COMOESTAS123";

            var gameManager = new GameManager(testWord);

            foreach (var letra in palabraJugada)
            {
                var validarLetra = gameManager.ContieneLetra(letra.ToString());
            }

            Assert.IsTrue(gameManager.CantidadErrores > 6);
        }
    }
}