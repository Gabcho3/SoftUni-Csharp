using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cardsData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            foreach(var cardData in cardsData)
            {
                string face = cardData.Split()[0];
                string suit = cardData.Split()[1];
                try
                {
                    cards.Add(new Card(face, suit));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach(var card in cards)
            {
                Console.Write(card.ToString() + " ");
            }
        }
    }

    internal class Card
    {
        //Valid Suits
        private string spades = "\u2660";
        private string hearts = "\u2665";
        private string diamonds = "\u2666";
        private string clubs = "\u2663";

        //Fields
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            set
            {
                List<string> validFaces = new List<string>() //string because of "10"
                {
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                    "J", "Q", "K", "A"
                };

                if(!validFaces.Contains(value.ToString()))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public string Suit
        {
            get { return suit; }
            set
            {
                if (value == "S")
                    suit = spades;

                else if (value == "H")
                    suit = hearts;

                else if (value == "D")
                    suit = diamonds;

                else if (value == "C")
                    suit = clubs;

                else
                    throw new ArgumentException("Invalid card!");
            }
        }

        public override string ToString()
            => $"[{Face}{Suit}]";
    }
}
