import java.util.NoSuchElementException;

public enum Card {

    //Humans
    KNIGHT( "Knight", 2, 2 ),
    TANK( "Tank", 1, 5 ),
    GUNNER( "Gunner", 4, 1 ),
    WIZARD( "Wizard", 3, 1 ),

    //Undead
    OGRE( "OGRE", 4, 4 ),
    ZOMBIE( "ZOMBIE", 1, 2 ),
    SKELETON( "SKELETON", 2, 1 ),
    SKULLKING( "SKULL KING", 5, 5 ),

    //Empty
    EMPTY( "EMPTY", 0, 0 );


    private String name;
    private int atk;
    private int hp;

    public String back = String.format( """
            ┌────────────────┐
            │                │
            │                │
            │                │
            └────────────────┘
            """ );

    Card( String name, int atk, int hp ) {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
    }

    public static Card getCard( String str ) throws NoSuchElementException {
        for ( Card c : Card.values( ) ) {
            if ( c.getName( ).equals( str ) ) {
                return c;
            }
        }
        throw new NoSuchElementException( "No Card found with Name: " + str );
    }

    //Getters / Setters
    public String getName( ) {
        return name;
    }

    public void setName( String name ) {
        this.name = name;
    }

    public int getAtk( ) {
        return atk;
    }

    public void setAtk( int atk ) {
        this.atk = atk;
    }

    public int getHp( ) {
        return hp;
    }

    public void setHp( int hp ) {
        this.hp = hp;
    }

    @Override
    public String toString( ) {
        if ( this == Card.EMPTY ) {
            return String.format(
                    """
                            ┌────────────────┐
                            │                │
                            │      EMPTY     │
                            │                │
                            └────────────────┘
                            """ );
        } else {
            return String.format(
                    """
                            ┌────────────────┐
                            │NAME: %10s│
                            │ATK: %11d│
                            │HP: %12d│
                            └────────────────┘
                            """,
                    getName( ),
                    getAtk( ),
                    getHp( ) );
        }
    }
}

