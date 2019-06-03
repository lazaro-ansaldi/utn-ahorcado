using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Jugador
    {
        public string PalabraSecreta { get; private set; }
        public int LongitudPalabra => PalabraSecreta.Length;
        public string Nombre { get; set; }
        public int CantidadDeAciertos { get; private set; }
        public int CantidadDeErrores { get; private set; }
        private Dictionary<string, bool> LetrasArriesgadas { get; set; }

        public Jugador(string nombre, string palabra)
        {
            Nombre = nombre;
            PalabraSecreta = palabra.ToUpperInvariant();
            LetrasArriesgadas = new Dictionary<string, bool>();
        }

        public bool ContieneLetra(string letra)
        {
            //if (PalabrasArriesgadas.ContainsKey(letra))
            //{
            //    var resultadoLetra = PalabrasArriesgadas[letra];
            //    return resultadoLetra ? LetraArriesgada.PreviamenteAcertada : LetraArriesgada.PreviamenteFallida;
            //}

            var result = PalabraSecreta.Where(x => x.ToString() == letra.ToUpperInvariant());

            if (result.Count() == 0)
            {
                CantidadDeErrores++;
                LetrasArriesgadas.Add(letra, false);
                return false;
            }
            else
            {
                CantidadDeAciertos += result.Count();
                LetrasArriesgadas.Add(letra, true);
                return true;
            }
        }

        public bool ArriesgarPalabra(string palabra)
        {
            return palabra.ToUpperInvariant() == PalabraSecreta;
        }
    }
}
