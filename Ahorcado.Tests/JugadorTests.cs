using Ahorcado.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.Tests
{
    [TestClass]
    public class JugadorTests
    {
        [TestMethod]
        public void CargarPalabra()
        {
            var testWord = "HOLA";
            var jugador = new Jugador("TEST1", testWord);

            Assert.AreEqual(testWord, jugador.PalabraSecreta);
        }

        [TestMethod]
        public void ValidarCantidad()
        {
            var testWord = "COMO";
            var jugador = new Jugador("TEST1", testWord);

            Assert.AreEqual(testWord.Length, jugador.LongitudPalabra);
        }

        [TestMethod]
        public void ContarErrorIntentoFallido()
        {
            var testWord = "ANDAS";
            var testLetra = "E";
            var jugador = new Jugador("TEST1", testWord);

            jugador.ContieneLetra(testLetra);

            Assert.IsTrue(jugador.CantidadDeErrores == 1);
        }

        [TestMethod]
        public void ContarErrorIntentoAcertado()
        {
            var testWord = "ANDAS";
            var testLetra = "A";
            var jugador = new Jugador("TEST1", testWord);

            jugador.ContieneLetra(testLetra);

            Assert.IsTrue(jugador.CantidadDeErrores == 0);
        }
    }
}
