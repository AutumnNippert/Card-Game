import java.util.ArrayList;
import java.util.NoSuchElementException;

/***
 * Decks have 15 card slots
 */
public class Deck {

    public static ArrayList<Card> UNDEAD = new ArrayList<>( ) {
        {
            add( new Card(Card.CardType.OGRE) );
            add( new Card(Card.CardType.OGRE) );
            add( new Card(Card.CardType.OGRE) );
            add( new Card(Card.CardType.ZOMBIE) );
            add( new Card(Card.CardType.ZOMBIE) );
            add( new Card(Card.CardType.ZOMBIE) );
            add( new Card(Card.CardType.ZOMBIE) );
            add( new Card(Card.CardType.ZOMBIE) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKELETON) );
            add( new Card(Card.CardType.SKULLKING) );
            add( new Card(Card.CardType.SKULLKING) );
        }
    };

    public static ArrayList<Card> HUMAN = new ArrayList<>( ) {
        {
            add( new Card(Card.CardType.TANK) );
            add( new Card(Card.CardType.TANK) );
            add( new Card(Card.CardType.TANK) );
            add( new Card(Card.CardType.KNIGHT) );
            add( new Card(Card.CardType.KNIGHT) );
            add( new Card(Card.CardType.KNIGHT) );
            add( new Card(Card.CardType.KNIGHT) );
            add( new Card(Card.CardType.KNIGHT) );
            add( new Card(Card.CardType.GUNNER) );
            add( new Card(Card.CardType.GUNNER) );
            add( new Card(Card.CardType.GUNNER) );
            add( new Card(Card.CardType.GUNNER) );
            add( new Card(Card.CardType.WIZARD) );
            add( new Card(Card.CardType.WIZARD) );
            add( new Card(Card.CardType.WIZARD) );
        }
    };

    public static ArrayList<Card> WEAPONS = new ArrayList<>( ) {
        {
            add( new Card(Card.CardType.SWORD) );
        }
    };


    public static Card getCard( String str ) throws NoSuchElementException {
        for ( Card c : cards ) {
            if ( c.getType().getName( ).equals( str ) ) {
                return c;
            }
        }
        throw new NoSuchElementException( "No Card found with Name: " + str );
    }

    private static ArrayList< Card > cards = new ArrayList<>() {
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
    };

    Deck( ArrayList< Card > cards ) {
        this.cards = cards;
    }

    public ArrayList< Card > getCards( ) {
        return cards;
    }
}
