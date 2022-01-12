import java.util.ArrayList;

/***
 * Decks have 15 card slots
 */
public enum Deck {

    UNDEAD( new ArrayList<>( ) {
        {
            add( Card.OGRE );
            add( Card.OGRE );
            add( Card.OGRE );
            add( Card.ZOMBIE );
            add( Card.ZOMBIE );
            add( Card.ZOMBIE );
            add( Card.ZOMBIE );
            add( Card.ZOMBIE );
            add( Card.SKELETON );
            add( Card.SKELETON );
            add( Card.SKELETON );
            add( Card.SKELETON );
            add( Card.SKELETON );
            add( Card.SKULLKING );
            add( Card.SKULLKING );
        }
    } ),

    HUMAN( new ArrayList<>( ) {
        {
            add( Card.TANK );
            add( Card.TANK );
            add( Card.TANK );
            add( Card.KNIGHT );
            add( Card.KNIGHT );
            add( Card.KNIGHT );
            add( Card.KNIGHT );
            add( Card.KNIGHT );
            add( Card.GUNNER );
            add( Card.GUNNER );
            add( Card.GUNNER );
            add( Card.GUNNER );
            add( Card.WIZARD );
            add( Card.WIZARD );
            add( Card.WIZARD );
        }
    } );


    private ArrayList< Card > cards;

    Deck( ArrayList< Card > cards ) {
        this.cards = cards;
    }

    public ArrayList< Card > getCards( ) {
        return cards;
    }
}
