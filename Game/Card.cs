using System;
using System.Text.Json;
using System.IO;

namespace Game
{
    public enum CardType
    {
        EMPTY, KNIGHT, HUNTER, WIZARD, TANK, PEASANT, PLAGUEBEING, DRUNKARD, SODODFATLAS, SHATTEREDSWORD, STRAIGHTSWORD
    }
    [Serializable]
    public class Card
    {

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

        public string back =
    @"┌────────────────┐
│                │
│                │
│                │
└────────────────┘";
        public string name { get; set; }
        public CardType ID { get; set; }
        public int mana { get; set; }
        public int atk { get; set; }
        public int hp { get; set; }
        public string desc { get; set; }

        public Card()
        {
            this.name = "Empty";
            this.ID = CardType.EMPTY;
            this.mana = 0;
            this.atk = 0;
            this.hp = 0;
        }

        public Card(string name, CardType ID, int mana, int atk, int hp, string desc)
        {
            this.name = name;
            this.ID = ID;
            this.mana = mana;
            this.atk = atk;
            this.hp = hp;
            this.desc = desc ?? throw new ArgumentNullException(nameof(desc));
        }

        public Card(CardType type)
        {
            this.ID = type;
        }

        //public static void serializeCards()
        //{
        //    string jsonCard = JsonSerializer.Serialize(new Card("Knight", CardType.KNIGHT, 2, 2, 2, "Knight"));
        //    string directory = "assets";
        //    Directory.CreateDirectory(directory);

        //    File.WriteAllText(directory + "/cardDeck.json", jsonCard);
        //}

        public string toString()
        {
            if (this.ID == CardType.EMPTY)
            {
                return
    @"┌────────────────┐
│                │
│      EMPTY     │
│                │
└────────────────┘";
            }
            else
            {
                return string.Format(
    @"┌────────────────┐
│ {0,-13}{1,1} │
│                │
│ {2,-13}         {3,1} │
└────────────────┘",
                        this.name,
                        (Utility.Colors.CYAN + this.mana + Utility.Colors.RESET),
                        (Utility.Colors.RED + this.atk + Utility.Colors.RESET),
                        (Utility.Colors.GREEN + this.hp + Utility.Colors.RESET));
            }
        }
    }

}