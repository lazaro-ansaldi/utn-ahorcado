namespace Ahorcado
{
    public class ResultadoDePartida
    {
        public EstadoJuego Estado { get; }
        public Jugador Jugador { get; }

        public ResultadoDePartida(EstadoJuego resultado, Jugador jugador)
        {
            Estado = resultado;
            Jugador = jugador;
        }
    }

    public enum EstadoJuego
    {
        Victoria = 1,
        Derrota = 2
    }
}
