using System;
using System.Collections.Generic;

public class Player {
    private List<Card> cards = new List<Card>();
    private int playerNumber;
    private int mana;
    private int health;
    private Card weapon = new Card();
    private Deck deck;

    public Player(int number, Deck deck, int health) {
        this.playerNumber = number;
        this.deck = deck;
        this.health = health;
    }

    public void giveCard(Card c) {
        cards.Add(c);
        Console.WriteLine("Giving card");
        Utility.ConsoleFunctions.wait(300);
    }

    public Card getRandomCard( ) {
        int cardIndex = getRandInt( 0, cards.Count - 1 );
        Console.WriteLine( cardIndex );
        return cards[cardIndex];
    }

    public void drawCardFromDeck( ) {
        if (deck.getCards().Count > 0) {
            int cardIndex = getRandInt(0, deck.getCards().Count - 1);
            Card c = deck.getCards()[cardIndex];
            giveCard(c);
            deck.getCards().Remove(c);
        }
    }

    public int getRandInt(int min, int max)
    {
        System.Random rand = new System.Random();
        return (int)rand.Next(min, max);
    }

    private List< Card > getCards( ) {
        return cards;
    }

    public void setCards( List< Card > cards ) {
        this.cards = cards;
    }

    public int getMana( ) {
        return mana;
    }

    public void setMana( int mana ) {
        this.mana = mana;
    }

    public void decreaseMana( int decrement ) {
        this.mana -= decrement;
    }

    public Card getWeapon( ) {
        return weapon;
    }

    public void setWeapon( Card weapon ) {
        this.weapon = weapon;
    }

    public String displayCards( ) {
        String[] strs = { "", "", "", "", "" };
        foreach (Card card in cards) {
            const int cardHeight = 5;
            for (int j = 0; j < cardHeight; j++) {
                strs[j] += (card.toString().Split("\n")[j] + "\t");
            }
        }

        String str = "";
        foreach (String s in strs) {
            str += s + "\n";
        }
        return str.Substring( 0, str.Length - 1 );
    }

    public String displayCardBacks( ) {
        String[] strs = { "", "", "", "", "" };
        for (int i = 0; i < cards.Count; i++ ) {
            const int cardHeight = 5;
            for (int j = 0; j < cardHeight; j++ ) {
                strs[ j ] += ( cards[i].back.Split( "\n" )[ j ] + "\t" );
            }
        }

        String str = "";
        foreach (String s in strs) {
            str += s + "\n";
        }
        return str.Substring( 0, str.Length - 1 );
    }

    public void playCard( Board board, Card c, Coordinate pos ) {
        //I hate this but doing cards.remove(c); doesn't work
        Utility.ArrayHelper.remove(cards, c);
        decreaseMana(c.mana);
        board.placeCard(c, pos);
        Console.WriteLine("Card: " + c.name + " played at position: " + (pos.x + 1));
        Utility.ConsoleFunctions.wait(1000);
    }

    public int getHealth( ) {
        return health;
    }

    public void setHealth( int health ) {
        this.health = health;
    }

    public void takeDamage( int damage ) {
        this.health -= damage;
    }

    //returning false when shouldn't be
    public bool hasCard( Card c ) {
        for (int i = 0; i < cards.Count - 1; i++) {
            if (cards[i].name == (c.name)) {
                return true;
            }
        }
        return false;
    }

    public bool isWeapon( Card c ) {
        return Deck.WEAPONS.getCards().Contains(c);
    }


    public String displayPlayer(bool isEnemy ) {
        return isEnemy ?
                "Opponent's Hand\t\tMana: " + Utility.Colors.CYAN + getMana( ) + Utility.Colors.RESET + "\t\tHealth: " + Utility.Colors.RED + getHealth( ) + Utility.Colors.RESET + "\n" +
                        displayCardBacks( ) + "\n" +
                        "Weapon:\n" +
                        weapon.toString( ) :
                "Weapon: \n" +
                        weapon.toString( ) +
                        "\nYour Hand\t\tMana: " + Utility.Colors.CYAN + getMana( ) + Utility.Colors.RESET + "\t\tHealth: " + Utility.Colors.RED + getHealth( ) + Utility.Colors.RESET + "\n" +
                        displayCards( );
    }
}
