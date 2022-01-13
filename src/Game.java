import jdk.jshell.execution.Util;

import java.util.Scanner;

public class Game {
    private static int turn = 0;
    private static int mana = 0;

    public static void initGame( ) {
        boolean isRunning = true;

        Scanner scn = new Scanner( System.in );


        Board board = new Board(
                new Card[][]
                        {
                                { Card.EMPTY, Card.EMPTY, Card.EMPTY, Card.EMPTY },
                                { Card.EMPTY, Card.EMPTY, Card.EMPTY, Card.EMPTY }
                        }
        );

        Player opponent = new Player( 1, Deck.UNDEAD, 20 );
        Player player = new Player( 2, Deck.HUMAN, 20 );
        player.drawCardFromDeck( );
        player.drawCardFromDeck( );
        player.drawCardFromDeck( );

        opponent.drawCardFromDeck( );
        opponent.drawCardFromDeck( );
        opponent.drawCardFromDeck( );

        //Displaying
        while ( isRunning ) {
            mana++;
            opponent.setMana( mana );
            player.setMana( mana );
            player.drawCardFromDeck( );
            opponent.drawCardFromDeck( );
            //Players Turn
            boolean isPlayerTurn = true;
            while ( isPlayerTurn ) {
                boolean isSelecting = true;
                while ( isSelecting ) {
                    draw( opponent, player, board );
                    System.out.println( "What is your course of action?" );
                    System.out.println( "(1) Select Card" );
                    System.out.println( "(2) Attack" );
                    System.out.println( "(3) End Turn" );
                    System.out.print( ">>> " );
                    try {
                        int input = scn.nextInt( );
                        scn.nextLine( );
                        if ( input == 1 ) {
                            System.out.print( "Select Card >>> " );
                            try {
                                Card c = Card.getCard( scn.nextLine( ) );
                                if ( isValidHold( player, c ) ) {

                                } else {
                                    Utility.MessagePrompts.notEnoughMana( );
                                    break;
                                }
                                //If player has card, continue
                                if ( player.hasCard( c ) ) {
                                    System.out.println( "Which position would you like to put that card? (1-4)" );
                                    System.out.print( ">>> " );
                                    try {
                                        int pos = scn.nextInt( );
                                        scn.nextLine( );
                                        Coordinate coord = new Coordinate( pos, 1 );
                                        if ( isValidPlay( player, board, c, coord ) ) {
                                            player.playCard( board, c, coord );
                                            player.decreaseMana( c.getMana( ) );
                                            isSelecting = false;
                                        } else {
                                            Utility.MessagePrompts.invalidPosition( );
                                        }

                                    } catch ( Exception e ) {
                                        e.printStackTrace( );
                                    }
                                } else {
                                    Utility.MessagePrompts.invalidSelection( );
                                }
                            } catch ( Exception e ) {
                                Utility.MessagePrompts.invalidSelection( );
                            }
                        } else if ( input == 2 ) {
                            //ATTACKING

                            if ( isValidAttack( player ) ) {
                                System.out.print( "Select Card Position >>> " );
                                try {
                                    Coordinate pos = new Coordinate( scn.nextInt( ), 1 );
                                    scn.nextLine( );
                                    Card selected = board.getCard( pos );
                                    if ( isValidCardSelect( board, pos ) ) {
                                        System.out.print( "Select Card Position to Attack >>> " );
                                        try {
                                            Coordinate atkPos = new Coordinate( scn.nextInt( ), 0 );
                                            scn.nextLine( );
                                            attack( opponent, board, pos, atkPos );

//                                        if ( isValidAttack(opponent, board, pos, atkPos ) ) {
//                                        } else {
//                                            System.out.println( "Invalid position to Attack" );
//                                            System.out.print( "Press 'Enter' to continue..." );
//                                            scn.nextLine( );
//                                            break;
//                                        }
                                        } catch ( Exception e ) {
//                                            System.out.println( "Invalid position to Attack" );
//                                            System.out.print( "Press 'Enter' to continue..." );
//                                            scn.nextLine( );
                                            Utility.MessagePrompts.invalidPosition( );
                                            break;
                                        }
                                    } else {
                                        Utility.MessagePrompts.invalidPosition( );
                                        break;
                                    }
                                } catch ( Exception e ) {
                                    Utility.MessagePrompts.invalidPosition( );
                                    break;
                                }
                            } else {
                                Utility.MessagePrompts.notEnoughMana( );
                                break;
                            }
                        } else if ( input == 3 ) {
                            isSelecting = false;
                            isPlayerTurn = false;
                        } else {
                            Utility.MessagePrompts.valueNotInRange( );
                        }
                    } catch ( Exception e ) {
                        Utility.MessagePrompts.invalidSelection( );
                    }
                }
            }
            //OPPONENT PLAYING CARD
            boolean isOpponentDone = false;
            while ( !isOpponentDone ) {
                Coordinate placement = new Coordinate( opponent.getRandInt( 5 ), 0 );
                Card c = opponent.getRandomCard( );
                if ( isValidHold( opponent, c ) && isValidPlay( opponent, board, c, placement ) && !board.cardExists( placement ) && isValidAttack( opponent ) ) {
                    opponent.playCard( board, opponent.getRandomCard( ), placement );
                    opponent.decreaseMana( 1 );
                    isOpponentDone = true;
                }
                if ( boardFull( true, board ) ) {
                    isOpponentDone = true;
                }
            }
        }


        scn.nextLine( );
    }

    public static boolean boardFull( boolean isEnemy, Board board ) {
        if ( isEnemy ) {
            for ( int i = 1; i < board.getCards( )[ 0 ].length; i++ ) {
                if ( !board.cardExists( new Coordinate( i, 0 ) ) ) {
                    return false;
                }
            }
        } else {
            for ( int i = 1; i < board.getCards( )[ 1 ].length; i++ ) {
                if ( !board.cardExists( new Coordinate( i, 1 ) ) ) {
                    return false;
                }
            }
        }
        return true;
    }

    public static void draw( Player p1, Player p2, Board board ) {
        cls( );
        // Line for displaying the back of the cards instead of the front
        // System.out.println( "Opponent's Hand\n" + p1.displayCardBacks( ) + "\n" );
        System.out.println( p1.diplayPlayer( true ) );
        System.out.println( board.displayBoard( ) );
        System.out.println( p2.diplayPlayer( false ) );
    }

    public static boolean isValidPlay( Player p, Board board, Card c, Coordinate pos ) {
        return pos.x >= 1
                && pos.x <= 4
                && !board.cardExists( pos );
    }

    public static void attack( Player p2, Board board, Coordinate card1pos, Coordinate card2Pos ) {
        //If the card exists, attack the card
        if ( board.cardExists( card2Pos ) ) {
            Card c1 = board.getCard( card1pos );
            Card c2 = board.getCard( card2Pos );
            c2.setHp( c2.getHp( ) - c1.getAtk( ) );
            c1.setHp( c1.getHp( ) - c2.getAtk( ) );
            if ( c1.getHp( ) <= 0 ) {
                board.removeCard( card1pos );
            } else {
                c1.setHp( Card.getCard( c1.getName( ) ).getHp( ) );
            }
            if ( c2.getHp( ) <= 0 ) {
                board.removeCard( card2Pos );
            } else {
                c2.setHp( Card.getCard( c2.getName( ) ).getHp( ) );
            }
        }
        //If the card doesn't exist, attack the player
        else {
            Card c1 = board.getCard( card1pos );
            Card c2 = p2.getWeapon( );
            if ( c2 == Card.EMPTY ) {
                p2.takeDamage( c1.getAtk( ) );
            } else {
                c2.setHp( c2.getHp( ) - 1 );
                p2.takeDamage( c1.getAtk( ) - 1 );
                c1.setHp( c1.getHp( ) - c2.getAtk( ) );
            }
        }

    }

    public static boolean isValidCardSelect( Board board, Coordinate selectedPos ) {
        return board.cardExists( selectedPos );
    }

    //mana check
    public static boolean isValidAttack( Player p ) {
        return p.getMana( ) >= 1;
    }

    /***
     * Returns true if player is able to even pick up the card
     * @param p Player
     * @param c Card
     * @return
     */
    public static boolean isValidHold( Player p, Card c ) {
        return c.getMana( ) <= p.getMana( )
                && p.hasCard( c );
    }

    /***
     * Clears Screen of the console
     */
    public static void cls( ) {
        System.out.print( "\033[H\033[2J" );
        System.out.flush( );
    }

    //Attack will be if the card selected to attack attacks an empty spot, the enemy will lose health
    //but if the selected card attacks another card, then that card attacked loses health
}