using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Match {
    private static int mana = 0;

    //Make a bunch of parameters like AI  and musicFileName for the init function. This sould load the AI logic as the opponent attacking. Same with the player (most of this function should be in the player class then)
    //Example
    /*
    loopMusic("path" + musicFileName);
    createBoard();
    drawCards();
    while(playersAlive){
        playerTurn();
        opponentTurn();
    }
    gameEnd();
     */
    public static void init() {
        bool debug = true;
        MusicPlayer musicPlayer = new MusicPlayer();
        try {
            musicPlayer = new MusicPlayer("Assets\\Music\\Fight(old).wav");
            musicPlayer.loop();
        } catch (Exception e) {
            Console.WriteLine("Music not available: " + e.ToString());
            Utility.Debug.wait(debug, 2000);
        }


        Board board = new Board( 
            new[] { 
                new[]{new Card(), new Card(), new Card(), new Card()}, 
                new[]{new Card(), new Card(), new Card(), new Card()} 
            });

        Player opponent = new Player(1, Deck.UNDEAD, 20);
        Player player = new Player(2, Deck.HUMAN, 20);
        player.drawCardFromDeck();
        player.drawCardFromDeck();
        player.drawCardFromDeck();

        opponent.drawCardFromDeck();
        opponent.drawCardFromDeck();
        opponent.drawCardFromDeck();

        //Displaying
        while (isPlayerAlive(opponent) && isPlayerAlive(player)) {
            mana++;
            opponent.setMana(mana);
            player.setMana(mana);
            player.drawCardFromDeck();
            opponent.drawCardFromDeck();
            //Players Turn
            bool isPlayerTurn = true;
            while (isPlayerTurn) {
                bool isSelecting = true;
                while (isSelecting) {
                    draw(opponent, player, board);
                    Menu gameplayMenu = new Menu("Gameplay Menu", new List<String>() {
                            "Select Card",
                            "Attack",
                            "End Turn"
                    });
                    gameplayMenu.display();
                    try {
                        int input = gameplayMenu.getIntValue();
                        if (input == 1) {
                            Menu selectMenu = new Menu("Select Card", new List<String>() {
                                    //add(">>> ");
                            });
                            selectMenu.display();
                            try {
                                Card c = Deck.getCard(selectMenu.getStringValue());
                                if (isValidHold(player, c)) {

                                } else {
                                    Utility.Debug.printDebug( debug, "Player mana: " + player.getMana() + "\nCard Mana: " + c.mana + "\nPlayer has card: " +  player.hasCard(c));
                                    Utility.Debug.printDebug( debug, c.toString());
                                    Utility.MessagePrompts.notEnoughMana();
                                    break;
                                }
                                //If player has card, continue
                                if (player.hasCard(c)) {
//                                    Console.WriteLine( "Which position would you like to put that card? (1-4)" );
                                    Menu positionMenu = new Menu("Which position would you like to put that card?", new List<String>() {
                                            "",
                                            "",
                                            "",
                                            "",
                                            "Weapon Slot"
                                    });
                                    positionMenu.display();
                                    try {
                                        int pos = positionMenu.getIntValue() - 1;
                                        if(pos == 4) {

                                        }
                                        Coordinate coord = new Coordinate(pos, 1);
                                        if (isValidPlay(player, board, c, coord)) {
                                            player.playCard(board, c, coord);
                                            isSelecting = false;
                                        } else {
                                            Utility.MessagePrompts.invalidPosition();
                                        }

                                    } catch (Exception e)
                                    {
                                        Debug.Write(e.StackTrace);
                                    }
                                } else {
                                    Utility.MessagePrompts.invalidSelection();
                                }
                            } catch (Exception e) {
                                Utility.MessagePrompts.invalidSelection();
                            }
                        } else if (input == 2) {
                            //ATTACKING

                            if (isValidAttack(player)) {
                                Console.WriteLine("Select Card Position >>> ");
                                try {
                                    Coordinate pos = new Coordinate(Int32.Parse(Console.ReadLine()) - 1, 1);
                                    //Card selected = board.getCard( pos );
                                    if (isValidCardSelect(board, pos)) {
                                        Console.WriteLine("Select Card Position to Attack >>> ");
                                        try {
                                            Coordinate atkPos = new Coordinate(Int32.Parse(Console.ReadLine()) - 1, 0);
                                            attack(player, opponent, board, pos, atkPos);

//                                        if ( isValidAttack(opponent, board, pos, atkPos ) ) {
//                                        } else {
//                                            Console.WriteLine( "Invalid position to Attack" );
//                                            System.out.print( "Press 'Enter' to continue..." );
//                                            scn.nextLine( );
//                                            break;
//                                        }
                                        } catch (Exception e) {
//                                            Console.WriteLine( "Invalid position to Attack" );
//                                            System.out.print( "Press 'Enter' to continue..." );
//                                            scn.nextLine( );
                                            Utility.MessagePrompts.invalidPosition();
                                            break;
                                        }
                                    } else {
                                        Utility.MessagePrompts.invalidPosition();
                                        break;
                                    }
                                } catch (Exception e) {
                                    Utility.MessagePrompts.invalidPosition();
                                    break;
                                }
                            } else {
                                Utility.MessagePrompts.notEnoughMana();
                                break;
                            }
                        } else if (input == 3) {
                            isSelecting = false;
                            isPlayerTurn = false;
                        } else {
                            Utility.MessagePrompts.valueNotInRange();
                        }
                    } catch (Exception e) {
                        Utility.MessagePrompts.invalidSelection();
                    }
                }
            }
            //OPPONENT TURN
            int tries = 0;
            if ((opponent.getMana() > (mana / 2)) && !boardFull(true, board)) {
                while ((opponent.getMana() > (mana / 2)) && !boardFull(true, board) && tries < 10) {
                    //OPPONENT PLAYING CARD
                    Coordinate placement = new Coordinate(opponent.getRandInt(0, 3), 0);
                    Card c = opponent.getRandomCard();
                    if (isValidHold(opponent, c) && isValidPlay(opponent, board, c, placement)) {
                        opponent.playCard(board, c, placement);
                        draw(opponent, player, board);

                        Utility.Debug.printDebug(debug, "Played a card");
                        Utility.ConsoleFunctions.wait(1000);
                    } else {
                        Utility.Debug.printDebug(debug, "In the while loop");
                        tries++;
                    }
                }

            } else {
                Utility.Debug.printDebug(debug, "Didn't play a card");
                Utility.ConsoleFunctions.wait(1000);
            }
            if (tries >= 10) {
                Utility.Debug.printDebug(debug, "Didn't play a card");
                Utility.ConsoleFunctions.wait(1000);
            }

            while (opponent.getMana() > 0 && !boardEmpty(true, board)) {
                //OPPONENT ATTACKING
                Coordinate selectedCard = findRandomCardOnBoard(true, board);
                Coordinate coordinateAttacking = new Coordinate(opponent.getRandInt(0, 3), 1);
                if (isValidAttack(opponent)) {
                    attack(opponent, player, board, selectedCard, coordinateAttacking);
                    draw(opponent, player, board);
                    Utility.Debug.printDebug(debug, "Attacked");
                    Utility.ConsoleFunctions.wait(3000);
                }
                Utility.Debug.printDebug(debug, "Didn't attack");
                Utility.ConsoleFunctions.wait(3000);

            }


            //LOOP TO TOP
        }

        //Game Over
        draw(opponent, player, board);
        Utility.MessagePrompts.gameOver();
        musicPlayer.close();
        //play music according to scenario
        if (player.getHealth() <= 0) {
            Console.WriteLine("You Lost! :(");
        } else if (opponent.getHealth() <= 0) {
            Console.WriteLine("You Win!!!");
        } else {
            Console.WriteLine("You Tied (Somehow)!");
        }

    }

    //Create findRandomCardOnBoard() so that the AI doesn't attack me with an empty card
    public static Coordinate findRandomCardOnBoard(bool isEnemy /*y = 1 or 0*/, Board board) {
        //posCard is the position of the card with the most attack stat
        Coordinate posCard = isEnemy ? new Coordinate(0, 0) : new Coordinate(0, 1);
        for (int i = 0; i < board.getCards()[0].Length - 1; i++) {
            Coordinate newCoord;
            if (isEnemy) {
                //set y to 0
                newCoord = new Coordinate(i, 0);
            } else {
                //set y to 1
                newCoord = new Coordinate(i, 1);
            }
            if (board.cardExists(newCoord)) {
                if (board.getCard(posCard).atk < board.getCard(newCoord).atk){
                    posCard = newCoord;
                }
            }
        }
        return posCard;
    }

    public static bool boardFull(bool isEnemy, Board board) {
        if (isEnemy) {
            for (int i = 1; i < board.getCards()[0].Length; i++) {
                if (!board.cardExists(new Coordinate(i, 0))) {
                    return false;
                }
            }
        } else {
            for (int i = 1; i < board.getCards()[1].Length; i++) {
                if (!board.cardExists(new Coordinate(i, 1))) {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool boardEmpty(bool isEnemy, Board board) {
        if (isEnemy) {
            for (int i = 1; i < board.getCards()[0].Length; i++) {
                if (board.cardExists(new Coordinate(i, 0))) {
                    return false;
                }
            }
        } else {
            for (int i = 1; i < board.getCards()[1].Length; i++) {
                if (board.cardExists(new Coordinate(i, 1))) {
                    return false;
                }
            }
        }
        return true;
    }

    public static void draw(Player p1, Player p2, Board board) {
        Utility.ConsoleFunctions.cls();
        // Line for displaying the back of the cards instead of the front
        // Console.WriteLine( "Opponent's Hand\n" + p1.displayCardBacks( ) + "\n" );
        Console.WriteLine(p1.displayPlayer(true));
        Console.WriteLine(board.displayBoard());
        Console.WriteLine(p2.displayPlayer(false));
    }

    public static bool isValidPlay(Player p, Board board, Card c, Coordinate pos) {
        return pos.x >= 0
                && pos.x <= 3
                && !board.cardExists(pos);
    }

    public static void attack(Player p1, Player p2, Board board, Coordinate card1pos, Coordinate card2Pos) {
        //If the card exists, attack the card
        Card c1 = board.getCard(card1pos);
        if (board.cardExists(card2Pos)) {
            Card c2 = board.getCard(card2Pos);
            c2.hp = c2.hp - c1.atk;
            c1.hp = c1.hp - c2.atk;
            removeIfDead(board, card1pos, c1);//This doesn't work
            removeIfDead(board, card2Pos, c2);//This does work
        }
        //If the card doesn't exist, attack the player
        else {
            Card c2 = p2.getWeapon();
            if (c2.type == CardType.EMPTY) {
                p2.takeDamage(c1.atk);
            } else {
                c2.hp = c2.hp - 1;
                p2.takeDamage(c1.atk - 1);
                c1.hp = c1.hp - c2.atk;
            }
        }
        p1.decreaseMana(1);
    }

    private static void removeIfDead(Board board, Coordinate card1pos, Card c) {
        if (c.hp <= 0) {
            c.hp = Deck.allCards.getCards()[Utility.ArrayHelper.getIndex(Deck.allCards.getCards(), c)].hp; //this should set card back to inital hp
            board.removeCard(card1pos);
            Console.WriteLine("Card: " + c.name + " died");
            Utility.ConsoleFunctions.wait(2000);
        } else {
            Console.WriteLine("Card: " + c.name + " didn't die");
            Utility.ConsoleFunctions.wait(1000);
        }
    }

    public static bool isValidCardSelect(Board board, Coordinate selectedPos) {
        return board.cardExists(selectedPos);
    }

    //mana check
    public static bool isValidAttack(Player p) {
        return p.getMana() >= 1;
    }

    /***
     * Returns true if player is able to even pick up the card
     * @param p Player
     * @param c Card
     * @return
     */
    public static bool isValidHold(Player p, Card c) {
        return c.mana <= p.getMana()
                && p.hasCard(c);
    }

    public static bool isPlayerAlive(Player p) {
        return p.getHealth() > 0;
    }

    //Attack will be if the card selected to attack attacks an empty spot, the enemy will lose health
    //but if the selected card attacks another card, then that card attacked loses health
}