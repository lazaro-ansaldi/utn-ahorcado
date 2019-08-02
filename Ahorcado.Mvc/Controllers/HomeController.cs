using Ahorcado.Core;
using Ahorcado.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Ahorcado.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Set("_InitializeSession", Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
            return View("~/Views/Start.cshtml");
        }

        [HttpPost]
        public IActionResult Start(StartModel model)
        {
            var player = new Jugador(model.PlayerName, model.SecretWord);
            var gameManager = new GameManager(player);

            MemoryStorageHelper.AddOrReplace($"{HttpContext.Session.Id}_{Constants.GameManagerKey}", gameManager);
            return RedirectToAction("Index", "Game");
        }
    }
}
