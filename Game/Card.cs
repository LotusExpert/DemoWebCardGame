using System;

namespace iStoneCardGameWeb.Game
{
    public class Card : IEquatable<Card> , IComparable<Card>
    {
        public int Value { get; set; }
        public String Face { get; set; }
        public String Suit { get; set; }
        private int CardValue;

        public Card(int value, String face, String suit) 
        {
            Value = value;
            Face = face;
            Suit = suit;
            CardValue = (int) (Suits)Enum.Parse(typeof(Suits), Suit) + Value;
        }

        //override the ToString method - used for returning CSS classes
        override public String ToString() 
        {
            Faces f = (Faces)Enum.Parse(typeof(Faces), Face);
            return Suit + " " + f.ToString();
        }

        //Override the GetHashCode method from Object
        public override int GetHashCode()
        {
            int seed = 13;
            return CardValue ^ seed;
        }
        //Override the Equals method from Object
        override public bool Equals(object obj)
        {
            if (obj == null) 
                return false;
            
            Card cardObj = obj as Card;
            
            if (cardObj == null) 
                return false;
            else 
                return Equals(cardObj);
        }

        //Implement custom Equals method for internal comparision of Card objects
        public bool Equals(Card otherCard)
        {
            if (otherCard == null) 
                return false;
            
            return (this.CardValue.Equals(otherCard.CardValue));
        }

        //Override CompareTo method from Object, for sorting Card objects
        public int CompareTo(Card compareCard)
        {
          // A null value means that this object is greater.
            if (compareCard == null)
                return 1;

            else
                return this.CardValue.CompareTo(compareCard.CardValue);
        }

    }
}
