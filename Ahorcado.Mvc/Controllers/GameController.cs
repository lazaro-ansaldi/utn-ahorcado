using Ahorcado.Core;
using Ahorcado.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ahorcado.Mvc.Controllers
{
    public class GameController : Controller
    {
        private GameManager GetManager() => MemoryStorageHelper.GetAs<GameManager>($"{HttpContext.Session.Id}_{Constants.GameManagerKey}");

        public IActionResult Index()
        {
            var manager = GetManager();
            ViewBag.Finalizo = manager.Finalizo;
            ViewBag.LetrasAcertadas = manager.LetrasAcertadas;

            return View("~/Views/Game.cshtml");
        }

        [HttpPost]
        public IActionResult TryLetter(GameModel model)
        {
            var manager = GetManager();

            if (model.LetterToTry.Length == 1)
            {
                manager.ProbarLetra(model.LetterToTry);
            }
            else
            {
                manager.ArriesgarPalabra(model.LetterToTry);
            }

            ViewBag.Finalizo = manager.Finalizo;
            ViewBag.LetrasAcertadas = manager.LetrasAcertadas;

            if (manager.Finalizo)
            {
                ViewBag.Message = manager.Resultado.Estado == EstadoJuego.Victoria ? $"El jugador: {manager.Resultado.Jugador.Nombre} ha ganado la partida" 
                    : $"El jugador: {manager.Resultado.Jugador.Nombre} ha perdido la partida";
            }

            MemoryStorageHelper.AddOrReplace($"{HttpContext.Session.Id}_{Constants.GameManagerKey}", manager);
            return View("~/Views/Game.cshtml");
        }
    }
}