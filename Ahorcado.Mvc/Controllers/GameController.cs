using Ahorcado.Core;
using Ahorcado.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ahorcado.Mvc.Controllers
{
    public class GameController : Controller
    {
        private GameManager Manager => MemoryStorageHelper.GetAs<GameManager>($"{HttpContext.Session.Id}_{Constants.GameManagerKey}");

        public IActionResult Index()
        {
            ViewBag.Finalizo = Manager.Finalizo;
            ViewBag.LetrasAcertadas = Manager.LetrasAcertadas;

            return View("~/Views/Game.cshtml");
        }

        [HttpPost]
        public IActionResult TryLetter(GameModel model)
        {
            var manager = Manager;

            manager.ProbarLetra(model.LetterToTry);

            ViewBag.Finalizo = Manager.Finalizo;
            ViewBag.LetrasAcertadas = Manager.LetrasAcertadas;

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