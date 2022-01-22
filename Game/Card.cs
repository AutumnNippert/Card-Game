using System;

public enum CardType
{
    KNIGHT, TANK, GUNNER, WIZARD, OGRE, ZOMBIE, SKELETON, SKULLKING, SWORD, EMPTY
}

public class Card {

    //KNIGHT("Knight", 2, 2, 2, "Knight"),
    //    TANK("Tank", 4, 2, 5, "Tank"),
    //    GUNNER("Gunner", 2, 4, 2, "Gunner"),
    //    WIZARD("Wizard", 1, 2, 1, "Wizard"),
    //    OGRE("Ogre", 4, 4, 4, "Ogre"),
    //    ZOMBIE("Zombie", 1, 2, 1, "Zombie"),
    //    SKELETON("Skeleton", 2, 3, 2, "Skeleton"),
    //    SKULLKING("Skull King", 5, 5, 5, "Skull King"),
    //    SWORD("Sword", 2, 2, 2, "Sword"),
    //    EMPTY("Empty", 0, 0, 0, "Literally nothing");

    public String back = @"
            ┌────────────────┐
            │                │
            │                │
            │                │
            └────────────────┘
            ";
    public String name { get; set; }
    public CardType type { get; set; }
    public int mana { get; set; }
    public int atk { get; set; }
    public int hp { get; set; }
    public String desc { get; set; }

    public Card(){
        this.name = "Empty";
        this.type = CardType.EMPTY;
        this.mana = 0;
        this.atk = 0;
        this.hp = 0;
    }

    public Card(string back, CardType type, int mana, int atk, int hp, string desc)
    {
        this.back = back ?? throw new ArgumentNullException(nameof(back));
        this.type = type;
        this.mana = mana;
        this.atk = atk;
        this.hp = hp;
        this.desc = desc ?? throw new ArgumentNullException(nameof(desc));
    }

    public Card( CardType type)
    {
        this.type = type;
    }

    public String toString( ) {
        if ( this.type == CardType.EMPTY ) {
            return @"
                    ┌────────────────┐
                    │                │
                    │      EMPTY     │
                    │                │
                    └────────────────┘
                    @";
        } else {
            return String.Format(
                    @"
                            ┌────────────────┐
                            │ %-13s%1s │
                            │                │
                            │ %-1s         %13s │
                            └────────────────┘
                            ",
                    this.name,
                    ( Utility.Colors.CYAN + this.mana + Utility.Colors.RESET ),
                    ( Utility.Colors.RED + this.atk + Utility.Colors.RESET ),
                    ( Utility.Colors.GREEN + this.hp + Utility.Colors.RESET ) );
        }
    }
}

