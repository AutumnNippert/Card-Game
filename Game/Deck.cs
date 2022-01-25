

/***
 * Decks have 15 card slots
 */
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Game
{
    public class Deck
    {
        public static Card getCard(string str, Decks decks)
        {
            foreach (Card c in JsonSerializer.Deserialize<Deck>(File.ReadAllText(@"assets\masterDeck.json")).getCards())
            {
                if (c.name == (str))
                {
                    return c;
                }
            }
            throw new Exception("No Card found with Name: " + str);
        }

        public List<Card> cards { get; set; }

        public Deck(List<Card> cards)
        {
            this.cards = cards;
        }

        public Deck()
        {
            this.cards = new List<Card>();
        }

        public void addCards(int[] IDs)
        {
            for (int i = 0; i < IDs.Length; i++)
            {
                cards.Add(getCardByID(IDs[i]));
            }
        }

        public List<Card> getCards()
        {
            return cards;
        }

        public static Card getCardByID(int ID)
        {
            List<Card> tempCards = JsonSerializer.Deserialize<Deck>(File.ReadAllText(@"assets\masterDeck.json")).getCards();
            foreach (Card c in tempCards)
            {
                if ((int)c.ID == ID)
                {
                    return c;
                }
            }
            return new Card();
        }
    }
}