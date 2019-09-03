using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado.Core
{
    [Serializable]
    public class Jugador
    {
        public string PalabraSecreta { get; }
        public string Nombre { get; }
        public int LongitudPalabra => PalabraSecreta.Length;
        public int CantidadDeAciertos { get; private set; }
        public int CantidadDeErrores { get; private set; }
        private Dictionary<string, bool> LetrasArriesgadas { get; set; }

        public Jugador(string nombre, string palabra)
        {
            Nombre = nombre;
            PalabraSecreta = GetSanitizedString(palabra);
            LetrasArriesgadas = new Dictionary<string, bool>();
        }

        public bool ContieneLetra(string letra)
        {
            // Validar si la palabra ya fue arriesgada o no

            //if (PalabrasArriesgadas.ContainsKey(letra))
            //{
            //    var resultadoLetra = PalabrasArriesgadas[letra];
            //    return resultadoLetra ? LetraArriesgada.PreviamenteAcertada : LetraArriesgada.PreviamenteFallida;
            //}

            var result = PalabraSecreta.Where(x => x.ToString() == GetSanitizedString(letra));

            if (result.Count() == 0)
            {
                CantidadDeErrores++;
                //LetrasArriesgadas.Add(letra, false);
                return false;
            }
            else
            {
                CantidadDeAciertos += result.Count();
                //LetrasArriesgadas.Add(letra, true);
                return true;
            }
        }

        // Refactor: el input es un char
        public bool ArriesgarPalabra(string palabra)
        {
            return GetSanitizedString(palabra) == PalabraSecreta;
        }

        private string GetSanitizedString(string input)
        {
            return input.RemoveDiacritics()
                .ToUpperInvariant();
        }
    }
}
