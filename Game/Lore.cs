using System;
using System.Collections.Generic;

public class Lore
{

    public static void init()
    {
        Dialogue loreMasterTalk = new Dialogue(NPC.NPCs.LoreMaster.npc, "LoreMaster.dialogue");
        loreMasterTalk.init();
        Utility.ConsoleFunctions.waitForInput();
        while (true)
        {
            Utility.ConsoleFunctions.cls();
            Console.WriteLine(listCardNames());
            Console.WriteLine();
            Menu cardSelectMenu = new Menu("logic.Card Select\nType the name of the card, or type x to go back", new List<String>());
            cardSelectMenu.display();
            if (cardSelectMenu.value == "x")
            {
                break;
            }
            else
            {
                Utility.ConsoleFunctions.cls();
                Card c = Deck.getCard(cardSelectMenu.value);
                Console.WriteLine(getCardDetails(c));
                Utility.ConsoleFunctions.waitForInput();
            }
        }
    }

    public static String listCardNames()
    {
        String str = "Cards:\n";
        for (int i = 0; i < Deck.allCards.getCards().Count; i++)
        {
            if (i % 3 == 0 && i > 0)
            {
                str += "\n";
            }
            str += String.Format("%-20s", Deck.allCards.getCards()[i].name);
        }
        return str;
    }

    public static String getCardDetails(Card c)
    {
        return (String.Format(@"
                Name: % -20s
                Health: % -2d
                Attack Power: % -2d
                Mana Cost: % -2d

                % s

                % s
                ", c.name, c.hp, c.atk, c.mana, c.toString(), c.desc));
    }
}