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

        Player opponent = new Player( 1, Deck.UNDEAD );
        Player player = new Player( 2, Deck.HUMAN );
        player.drawCardFromDeck( );
        player.drawCardFromDeck( );
        player.drawCardFromDeck( );

        opponent.drawCardFromDeck( );
        opponent.drawCardFromDeck( );
        opponent.drawCardFromDeck( );

        //Displaying
        while ( isRunning ) {
            mana++;
            player.drawCardFromDeck( );
            opponent.drawCardFromDeck( );
            //Players Turn
            boolean isSelecting = true;
            while ( isSelecting ) {
                draw( opponent, player, board );
                System.out.println( "What is your course of action?" );
                System.out.print( "Select Card >>> " );
                try {
                    Card c = Card.getCard( scn.nextLine( ) );
                    if ( isValidHold( player, c ) ) {

                    } else {
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
                                isSelecting = false;
                            } else {
                                System.out.println( "Invalid play" );
                                System.out.print( "Press 'Enter' to continue..." );
                                scn.nextLine( );
                            }

                        } catch ( Exception e ) {
                            e.printStackTrace( );
                        }
                    } else {
                        System.out.println( "Invalid Card Selection" );
                        System.out.print( "Press 'Enter' to continue..." );
                        scn.nextLine( );
                    }
                } catch ( Exception e ) {
                    System.out.println( e.toString( ) );
                    System.out.print( "Press 'Enter' to continue..." );
                    scn.nextLine( );
                }
            }
        }


        scn.nextLine( );
    }

    public static void draw( Player p1, Player p2, Board board ) {
        cls( );
        // Line for displaying the back of the cards instead of the front
        // System.out.println( "Opponent's Hand\n" + p1.displayCardBacks( ) + "\n" );
        System.out.println( "Opponent's Hand\n" + p1.displayCards( ) + "\n" );
        System.out.println( board.displayBoard( ) );
        System.out.println( "Your Hand\tMana: " + Utility.Colors.CYAN + mana + Utility.Colors.RESET + "\n" + p2.displayCards( ) );
    }

    public static boolean isValidPlay( Player p, Board board, Card c, Coordinate pos ) {
        return pos.x >= 1
                && pos.x <= 4
                && !board.cardExists( pos );
    }

    public static boolean isValidHold( Player p, Card c ) {
        return c.getMana( ) <= mana
                && p.hasCard( c );
    }

    public boolean isValidAttack( Board board, Coordinate pos1, Coordinate pos2 ) {
        return board.cardExists( pos1 ) && board.cardExists( pos2 );
    }

    public static void cls( ) {
        System.out.print( "\033[H\033[2J" );
        System.out.flush( );
    }
}