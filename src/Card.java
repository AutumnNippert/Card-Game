public enum Card {

    KNIGHT(  "Knight", 2, 2 ),
    TANK("Tank", 1, 5),
    GUNNER("Gunner", 4, 1),
    OGRE("OGRE", 4, 4),
    WIZARD("Wizard", 3, 1),
    EMPTY("EMPTY", 0, 0);


    private String name;
    private int atk;
    private int hp;

    Card( String name, int atk, int hp ) {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
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
        if(getName().equals( "EMPTY" )){
            return String.format(
                    """
                    ┌────────────────┐
                    │                │
                    │      EMPTY     │
                    │                │
                    └────────────────┘
                    """);
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

