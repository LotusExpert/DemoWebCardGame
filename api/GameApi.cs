using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iStoneCardGameWeb.Game;

namespace iStoneCardGameWeb.Controllers
{
    public class GameApi : Controller
    {
        // /api/shuffledeck - Accept the parameter deckindex, which is the position of the current deck inte list
        // use this parameter to get the instance of the deck we want to shuffle and run the ShuffleDeck() method on it.
        // The ShuffleDeck() method is implemented in the CardDeck class
        [Route("/api/shuffledeck")]
        [HttpGet]
        public JsonResult Shuffle(int deckindex) 
        {
            CardGame.Decks[deckindex].ShuffleDeck();
            return Json("{deck:shuffled}");
        }
        
        // /api/sortdeck - Accept the parameter deckindex,
        [Route("/api/sortdeck")] 
        [HttpGet]
        public JsonResult Sort(int deckindex)
        {
            CardGame.Decks[deckindex].Deck.Sort();
            return Json("{deck:sorted}");
        }

        // /api/removedeck - accepts the parameter deckindex
        // Removes the CardDeck stored in position <deckindex> in the list CardGame.Decks and returns to the Game action
        [Route("/api/removedeck")] 
        [HttpGet]
        public JsonResult RemoveDeck(int deckindex) 
        {
            CardGame.Decks.RemoveAt(deckindex);
            return Json("{deck:removed}");
        }

        // /api/adddeck - adds another Deck to the list of Decks held by the CardGame.Decks List
        [Route("/api/adddeck")]
        [HttpGet]
        public JsonResult AddDeck() 
        {   
            CardGame.AddDeck();           
            return Json("{deck:added}");
        }

        // /api/discard - discards the top card from the deck
        [Route("/api/discard")]
        [HttpGet]
        public JsonResult Discard(int deckindex)
        {
            CardGame.Decks[deckindex].Discard(0);
            return Json("{card:0 , deck:"+deckindex+"}");
        }

        [Route("/api/decks")]
        [HttpGet]
        public JsonResult GetDecks() {
            return Json(CardGame.Decks);
        }

        [Route("/api/onedeck/list")]
        [HttpGet]
        public JsonResult OneDeckList() 
        {
            return Json(CardGame.OneDeck);
        }

        [Route("/api/onedeck/shuffle")]
        [HttpGet]
        public JsonResult OneDeckShuffle() 
        {
            CardGame.OneDeck.ShuffleDeck();
            return Json("{shuffled:1}");
        }
        
        [Route("/api/onedeck/sort")]
        [HttpGet]
        public JsonResult OneDeckSort() 
        {
            CardGame.OneDeck.Deck.Sort();
            return Json("{sorted:1}");
        }
    }
}