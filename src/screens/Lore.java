package screens;

import logic.Card;
import logic.Deck;
import logic.NPC;
import utility.Menu;
import utility.Utility;

import java.util.ArrayList;

public class Lore {

    public static void init() {
        Dialogue loreMasterTalk = new Dialogue(NPC.NPCs.LoreMaster.npc, "LoreMaster.dialogue");
        loreMasterTalk.init();
        Utility.ConsoleFunctions.waitForInput();
        while (true) {
            Utility.ConsoleFunctions.cls();
            System.out.println(listCardNames());
            System.out.println();
            Menu cardSelectMenu = new Menu("logic.Card Select\nType the name of the card, or type x to go back", new ArrayList<>());
            cardSelectMenu.display();
            if (cardSelectMenu.value.equals("x")) {
                break;
            } else {
                Utility.ConsoleFunctions.cls();
                Card c = Deck.getCard(cardSelectMenu.value);
                System.out.println(getCardDetails(c));
                Utility.ConsoleFunctions.waitForInput();
            }
        }
    }

    public static String listCardNames() {
        String str = "Cards:\n";
        for (int i = 0; i < Deck.allCards.getCards().size(); i++) {
            if (i % 3 == 0 && i > 0) {
                str += "\n";
            }
            str += String.format("%-20s", Deck.allCards.getCards().get(i).getType().getName());
        }
        return str;
    }

    public static String getCardDetails(Card c) {
        return (String.format("""
                Name: %-20s
                Health: %-2d
                Attack Power: %-2d
                Mana Cost: %-2d
                                
                %s
                
                %s
                """, c.getType().getName(), c.getHp(), c.getAtk(), c.getMana(), c.toString(), c.getDesc()));
    }
}