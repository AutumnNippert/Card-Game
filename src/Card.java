import java.util.NoSuchElementException;

public enum Card {

    //Humans
    KNIGHT( "Knight", 2, 2, 2, "A heroic knight" ),
    TANK( "Tank", 4, 1, 5, "A large soldier" ),
    GUNNER( "Gunner", 3, 4, 1, "A gunner" ),
    WIZARD( "Wizard", 2, 3, 1, "A wizard" ),

    //Undead
    OGRE( "Ogre", 4, 4, 4, "An ogre" ),
    ZOMBIE( "Zombie", 1, 1, 2, "An undead zombie" ),
    SKELETON( "Skeleton", 2, 2, 1, "An undead" ),
    SKULLKING( "Skull King", 5, 5, 5, "King of the undead" ),

    //Weapons
    SWORD( "Sword", 3, 2, 5, "Sword used by the knights of ara" ),

    //Empty
    EMPTY( "EMPTY", 0, 0, 0, "Empty" );


    public String back = String.format( """
            ┌────────────────┐
            │                │
            │                │
            │                │
            └────────────────┘
            """ );
    private String name;
    private int mana;
    private int atk;
    private int hp;
    private String desc;

    Card( String name, int mana, int atk, int hp, String desc ) {
        this.name = name;
        this.mana = mana;
        this.atk = atk;
        this.hp = hp;
        this.desc = desc;
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

    public int getMana( ) {
        return mana;
    }

    public void setMana( int mana ) {
        this.mana = mana;
    }

    public String getDesc( ) {
        return desc;
    }

    public void setDesc( String desc ) {
        this.desc = desc;
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
                            │ %-13s%1s │
                            │                │
                            │ %-1s%13s │
                            └────────────────┘
                            """,
                    getName( ),
                    ( Utility.Colors.CYAN + getMana( ) + Utility.Colors.RESET ),
                    ( Utility.Colors.RED + getAtk( ) + Utility.Colors.RESET ),
                    getHp( ) );
        }
    }
}

