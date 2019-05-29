namespace Ahorcado
{
    public class GameManager
    {
        public string SecretWord { get; }
        public int SecretCant { get { return SecretWord.Length; } }
        public int CantidadErrores { get; set; }

        public GameManager(string secretWord)
        {
            SecretWord = secretWord;
            CantidadErrores = 0;
        }

        public bool ContieneLetra(string secretLetra)
        {
            var result = SecretWord.Contains(secretLetra);

            if (result == false)
            {
                CantidadErrores++;
            }

            return result;
        }
    }
}
