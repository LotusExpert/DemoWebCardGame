using System;
using System.Collections.Generic;
namespace iStoneCardGameWeb.Game
{
  public class CardDeck
    {
        public static int NUM_OF_CARDS = 52;
        public List<Card> Deck  { get; set; } = new List<Card>(NUM_OF_CARDS);
        public List<Card> Discarded { get; set; } = new List<Card>();

        //Constructor - Create a Deck (List<CardDeck>) of Cards sorted in order
        public CardDeck() 
        {
            int i = 0;

            foreach (Suits s in Enum.GetValues(typeof(Suits))) //Loop through the enum values
            {
                foreach(Faces f in Enum.GetValues(typeof(Faces)))
                {
                    Deck.Insert(i, new Card((int)f, f.ToString(), s.ToString())); //Create new Card objects in List
                    i = i + 1; //i++;
                }
            }
            Deck.Sort();
        }

   
        public void ShuffleDeck() 
        {
            Card TempCard;
            Random rnd = new Random();
            int len = Deck.Count;
            int pos;

            for (int i = 0; i < 5000; i++) //Using pseudo randomness, I iterate a lot of times to get some sorting
            {
                
                pos = rnd.Next(len);

                TempCard = Deck[pos];//Take a Card from a random position in deck
                Deck[pos] = Deck[len-1]; //Replace random position with last card
                Deck[len-1] = TempCard; //Put selected card in last position
            }

        }

        public void Discard(int CardIndex) {
            Card DiscardCard = Deck[CardIndex];
            Deck.RemoveAt(CardIndex);
            Discarded.Add(DiscardCard);
        }

        //List all cards to console - testing class in console application
        public void ListCards() 
        {
            foreach (Card c in Deck)
            {
                System.Console.WriteLine(c.ToString());
            }
            System.Console.WriteLine(Deck.Count);
        }

    }  
}
