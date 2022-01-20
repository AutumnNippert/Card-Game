package logic;

import java.util.ArrayList;
import java.util.NoSuchElementException;

/***
 * Decks have 15 card slots
 */
public class Deck {

    public static Deck UNDEAD = new Deck(new ArrayList<>() {
        {
            add(new Card(Card.CardType.OGRE));
            add(new Card(Card.CardType.OGRE));
            add(new Card(Card.CardType.OGRE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKULLKING));
            add(new Card(Card.CardType.SKULLKING));
        }
    });

    public static Deck HUMAN = new Deck(new ArrayList<>() {
        {
            add(new Card(Card.CardType.TANK));
            add(new Card(Card.CardType.TANK));
            add(new Card(Card.CardType.TANK));
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.GUNNER));
            add(new Card(Card.CardType.GUNNER));
            add(new Card(Card.CardType.GUNNER));
            add(new Card(Card.CardType.GUNNER));
            add(new Card(Card.CardType.WIZARD));
            add(new Card(Card.CardType.WIZARD));
            add(new Card(Card.CardType.WIZARD));
        }
    });

    public static Deck WEAPONS = new Deck(new ArrayList<>() {
        {
            add(new Card(Card.CardType.SWORD));
        }
    });


    public static Card getCard( String str ) throws NoSuchElementException {
        for (Card c : allCards.getCards()) {
            if (c.getType().getName().equals(str)) {
                return c;
            }
        }
        throw new NoSuchElementException("No logic.Card found with Name: " + str);
    }

    public static final Deck allCards = new Deck(new ArrayList<>() {
        {
            add(new Card(Card.CardType.KNIGHT));
            add(new Card(Card.CardType.TANK));
            add(new Card(Card.CardType.GUNNER));
            add(new Card(Card.CardType.WIZARD));
            add(new Card(Card.CardType.OGRE));
            add(new Card(Card.CardType.ZOMBIE));
            add(new Card(Card.CardType.SKELETON));
            add(new Card(Card.CardType.SKULLKING));
            add(new Card(Card.CardType.SWORD));
        }
    });

    private ArrayList<Card> cards;

    Deck(ArrayList<Card> cards) {
        this.cards = cards;
    }

    public ArrayList<Card> getCards() {
        return cards;
    }
}
