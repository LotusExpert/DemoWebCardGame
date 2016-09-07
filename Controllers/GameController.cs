using System.Linq;
using Microsoft.AspNetCore.Mvc;
using iStoneCardGameWeb.Game;

namespace iStoneCardGameWeb.Controllers
{
    public class GameController : Controller
    {
        // /Game - If there isn't any CardDeck in the game, add one
        // Pass the List of CardDecks held in CardGame.Decks to the view, the view is expecting a list of type CardDeck
        [HttpGet]
        public IActionResult Game()
        {
           if(!CardGame.Decks.Any()) {
               CardGame.AddDeck();
           }
            return View(CardGame.Decks);
        }

        [HttpGet]
        public IActionResult OneDeck()
        {
            return View();
        }
    }
}