using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Lore
{
    Decks decks;
    public Lore(Decks d)
    {
        decks = d;
    }

    public void init()
    {
        Dialogue loreMasterTalk = new Dialogue(new NPC(NPC.Type.Friendly, "organ man", 100), "LoreMaster.dialogue");
        loreMasterTalk.init();
        Utility.ConsoleFunctions.waitForInput();
        while (true)
        {
            Utility.ConsoleFunctions.cls();
            Console.WriteLine(listCardNames());
            Console.WriteLine();
            Menu cardSelectMenu = new Menu("logic.Card Select\nType the name of the card, or type x to go back", new List<string>());
            cardSelectMenu.display();
            if (cardSelectMenu.value == "x")
            {
                break;
            }
            else
            {
                Utility.ConsoleFunctions.cls();
                Card c = Deck.getCard(cardSelectMenu.value, decks);
                Console.WriteLine(getCardDetails(c));
                Utility.ConsoleFunctions.waitForInput();
            }
        }
    }

    public string listCardNames()
    {
        string str = "Cards:\n";
        for (int i = 0; i < JsonSerializer.Deserialize<Deck>(File.ReadAllText(@"assets\masterDeck.json")).getCards().Count; i++)
        {
            if (i % 3 == 0 && i > 0)
            {
                str += "\n";
            }
            str += string.Format("%-20s", JsonSerializer.Deserialize<Deck>(File.ReadAllText(@"assets\masterDeck.json")).getCards()[i].name);
        }
        return str;
    }

    public string getCardDetails(Card c)
    {
        return (string.Format(@"
                Name: % -20s
                Health: % -2d
                Attack Power: % -2d
                Mana Cost: % -2d

                % s

                % s
                ", c.name, c.hp, c.atk, c.mana, c.toString(), c.desc));
    }
}