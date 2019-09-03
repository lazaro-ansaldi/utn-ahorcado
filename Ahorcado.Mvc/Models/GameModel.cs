using System.ComponentModel.DataAnnotations;

namespace Ahorcado.Mvc.Models
{
    public class GameModel
    {
        [RegularExpression(@"[^A-Za-z]+")]
        public string LetterToTry { get; set; }
    }
}
