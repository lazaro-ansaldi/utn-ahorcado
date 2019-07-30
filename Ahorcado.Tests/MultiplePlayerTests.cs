using Ahorcado.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.Tests
{
    [TestClass]
    public class MultiplePlayerTests
    {
        [TestMethod]
        public void ProbarVictoriaJugador2()
        {
            var nombreJugador1 = "TEST1";
            var testWord1 = "PERDIO";
            var jugador1 = new Jugador(nombreJugador1, testWord1);

            var nombreJugador2 = "TEST2";
            var testWord2 = "GANO";
            var jugador2 = new Jugador(nombreJugador2, testWord2);

            var letrasAJugar = new string[] { "1", "G", "2", "A", "3", "N", "4", "O" };
            var gameManager = new GameManager(jugador1, jugador2);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Victoria);
            Assert.IsTrue(gameManager.Resultado.Jugador.Nombre == nombreJugador2);
        }

        [TestMethod]
        public void ProbarDerrotaJugador2()
        {
            var nombreJugador1 = "TEST1";
            var testWord1 = "SCRUM";
            var jugador1 = new Jugador(nombreJugador1, testWord1);

            var nombreJugador2 = "TEST2";
            var testWord2 = "VASAPERDER";
            var jugador2 = new Jugador(nombreJugador2, testWord2);

            var letrasAJugar = new string[] { "S", "1", "A", "2", "C", "3", "E", "4", "R", "5", "U", "6", "N", "7" };
            var gameManager = new GameManager(jugador1, jugador2);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Derrota);
            Assert.IsTrue(gameManager.Resultado.Jugador.Nombre == nombreJugador2);
        }

        [TestMethod]
        public void ProbarVictoriaJugador1()
        {
            var nombreJugador1 = "TEST1";
            var testWord1 = "GATO";
            var jugador1 = new Jugador(nombreJugador1, testWord1);

            var nombreJugador2 = "TEST2";
            var testWord2 = "NOIMPORTA";
            var jugador2 = new Jugador(nombreJugador2, testWord2);

            var letrasAJugar = new string[] { "G", "1", "A", "2", "T", "3", "O" };
            var gameManager = new GameManager(jugador1, jugador2);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Victoria);
            Assert.IsTrue(gameManager.Resultado.Jugador.Nombre == nombreJugador1);
        }

        [TestMethod]
        public void ProbarDerrotaJugador1()
        {
            var nombreJugador1 = "TEST1";
            var testWord1 = "LOSER";
            var jugador1 = new Jugador(nombreJugador1, testWord1);

            var nombreJugador2 = "TEST2";
            var testWord2 = "MANZANA";
            var jugador2 = new Jugador(nombreJugador2, testWord2);

            var letrasAJugar = new string[] { "1", "M", "2", "Z", "3", "A", "4", "R", "5", "P", "6", "L", "7" };
            var gameManager = new GameManager(jugador1, jugador2);

            foreach (var letra in letrasAJugar)
            {
                gameManager.ProbarLetra(letra);
            }

            // Definicion de derrota
            Assert.IsTrue(gameManager.Finalizo);
            Assert.IsTrue(gameManager.Resultado.Estado == EstadoJuego.Derrota);
            Assert.IsTrue(gameManager.Resultado.Jugador.Nombre == nombreJugador1);
        }
    }
}
