using System.Collections.Generic;

namespace Ahorcado
{
    public class GameManager
    {
        public bool Finalizo { get; private set; }
        public ResultadoDePartida Resultado { get; private set; }
        public Jugador JugadorActual => Jugadores[TurnoActual];
        private Dictionary<int, Jugador> Jugadores { get; set; }
        private int TurnoActual { get; set; }

        private readonly bool _esMultijugador;

        public GameManager(Jugador jugador1, Jugador jugador2 = null)
        {
            _esMultijugador = jugador2 != null;

            Jugadores = new Dictionary<int, Jugador>();
            Jugadores.Add(1, jugador1);
            Jugadores.Add(2, jugador2);

            TurnoActual = 1; // Siempre arranca el 1 por defecto
        }

        public void ArriesgarPalabra(string palabra)
        {
            var acerto = JugadorActual.ArriesgarPalabra(palabra);

            Finalizo = true;
            if (acerto)
            {
                Resultado = new ResultadoDePartida(EstadoJuego.Victoria, JugadorActual);
            }
            else
            {
                Resultado = new ResultadoDePartida(EstadoJuego.Derrota, JugadorActual);
            }
        }

        public bool ProbarLetra(string letra)
        {
            var resultado = JugadorActual.ContieneLetra(letra);
            RefrescarEstadoDelJuego();
            CambiarTurno();

            return resultado;
        }

        private void RefrescarEstadoDelJuego()
        {
            var jugador = JugadorActual;
            if (jugador.CantidadDeErrores > 6)
            {
                Finalizo = true;
                Resultado = new ResultadoDePartida(EstadoJuego.Derrota, jugador);
            }

            if (jugador.CantidadDeAciertos == jugador.PalabraSecreta.Length)
            {
                Finalizo = true;
                Resultado = new ResultadoDePartida(EstadoJuego.Victoria, jugador);
            }       
        }

        private void CambiarTurno()
        {
            if (_esMultijugador)
            {
                TurnoActual = TurnoActual == 1 ? 2 : 1;
            }
        }
    }
}
