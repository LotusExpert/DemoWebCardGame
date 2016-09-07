using System;
using System.Collections.Generic;
namespace iStoneCardGameWeb.Game
{
    /**
    * This class is only used to instansiate a static List of type CardDeck
    * So that we can keep track of all Decks in the game.
    */
    public static class CardGame 
    {
        public static List<CardDeck> Decks { get; set; } = new List<CardDeck>();
        public static CardDeck OneDeck { get; set; } = new CardDeck();

        public static void AddDeck() 
        {
            Decks.Add(new CardDeck());
        }
    }
}