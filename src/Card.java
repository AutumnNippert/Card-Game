import java.util.ArrayList;
import java.util.NoSuchElementException;



public class Card {

    public enum CardType {

        KNIGHT("Knight", 2, 2, 2, "Knight"),
        TANK("Tank", 4, 2, 5, "Tank"),
        GUNNER("Gunner", 2, 4, 2, "Gunner"),
        WIZARD("Wizard", 1, 2, 1, "Wizard"),
        OGRE("Ogre", 4, 4, 4, "Ogre"),
        ZOMBIE("Zombie", 1, 2, 1, "Zombie"),
        SKELETON("Skeleton", 2, 3, 2, "Skeleton"),
        SKULLKING("Skull King", 5, 5, 5, "Skull King"),
        SWORD("Sword", 2, 2, 2, "Sword"),
        EMPTY("Empty", 0, 0, 0, "Literally nothing");


        private final String name;
        private final int mana;
        private final int atk;
        private final int hp;
        private final String desc;

        private CardType(String name, int mana, int atk, int hp, String desc) {
            this.name = name;
            this.mana = mana;
            this.atk = atk;
            this.hp = hp;
            this.desc = desc;
        }

        public String getName() {
            return name;
        }
    }

    public String back = String.format( """
            ┌────────────────┐
            │                │
            │                │
            │                │
            └────────────────┘
            """ );
    private CardType type;
    private int mana;
    private int atk;
    private int hp;
    private String desc;

    Card( CardType type ) {
        this.type = type;
        this.mana = this.type.mana;
        this.atk = this.type.atk;
        this.hp = this.type.hp;
    }

    Card(){
        this.type = CardType.EMPTY;
        this.mana = this.type.mana;
        this.atk = this.type.atk;
        this.hp = this.type.hp;
    }



    //Getters / Setters
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

    public String getDesc( ) {
        return this.type.desc;
    }

    public CardType getType() {
        return type;
    }

    @Override
    public String toString( ) {
        if ( this.type == CardType.EMPTY ) {
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
                            │ %-1s         %13s │
                            └────────────────┘
                            """,
                    this.type.name,
                    ( Utility.Colors.CYAN + getMana( ) + Utility.Colors.RESET ),
                    ( Utility.Colors.RED + getAtk( ) + Utility.Colors.RESET ),
                    ( Utility.Colors.GREEN + getHp( ) + Utility.Colors.RESET ) );
        }
    }
}

