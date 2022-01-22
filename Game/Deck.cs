

/***
 * Decks have 15 card slots
 */
using System;
using System.Collections.Generic;

public class Deck {

    public static Deck UNDEAD = new Deck(new List<Card>
        {
            new Card(Card.CardType.OGRE),
            new Card(Card.CardType.OGRE),
            new Card(Card.CardType.OGRE),
            new Card(Card.CardType.ZOMBIE),
            new Card(Card.CardType.ZOMBIE),
            new Card(Card.CardType.ZOMBIE),
            new Card(Card.CardType.ZOMBIE),
            new Card(Card.CardType.ZOMBIE),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKELETON),
            new Card(Card.CardType.SKULLKING),
            new Card(Card.CardType.SKULLKING)
        }
    );

    public static Deck HUMAN = new Deck(new List<Card>() {
        {
            new Card(Card.CardType.TANK),
            new Card(Card.CardType.TANK),
            new Card(Card.CardType.TANK),
            new Card(Card.CardType.KNIGHT),
            new Card(Card.CardType.KNIGHT),
            new Card(Card.CardType.KNIGHT),
            new Card(Card.CardType.KNIGHT),
            new Card(Card.CardType.KNIGHT),
            new Card(Card.CardType.GUNNER),
            new Card(Card.CardType.GUNNER),
            new Card(Card.CardType.GUNNER),
            new Card(Card.CardType.GUNNER),
            new Card(Card.CardType.WIZARD),
            new Card(Card.CardType.WIZARD),
            new Card(Card.CardType.WIZARD)
        }
    });

    public static Deck WEAPONS = new Deck(new List<String>() {
        {
            new Card(Card.CardType.SWORD),
        }
    });


    public static Card getCard( String str ){
        foreach (Card c in allCards.getCards()) {
            if (c.name.equals(str)) {
                return c;
            }
        }
        throw new Exception("No Card found with Name: " + str);
    }

    public static Deck allCards = new Deck(new List<String>() {
        {
            new Card(CardType.KNIGHT),
            new Card(CardType.TANK),
            new Card(CardType.GUNNER),
            new Card(CardType.WIZARD),
            new Card(CardType.OGRE),
            new Card(CardType.ZOMBIE),
            new Card(CardType.SKELETON),
            new Card(CardType.SKULLKING),
            new Card(CardType.SWORD),
        }
    });

    private List<Card> cards;

    Deck(List<Card> cards) {
        this.cards = cards;
    }

    public List<Card> getCards() {
        return cards;
    }
}
