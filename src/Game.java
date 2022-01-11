import java.util.Scanner;

public class Game {
    private int turn = 0;

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

        Player opponent = new Player( 1 );
        Player player = new Player( 2 );
        player.giveCard( Card.KNIGHT );
        player.giveCard( Card.GUNNER );
        player.giveCard( Card.WIZARD );
        player.giveCard( Card.TANK );

        opponent.giveCard( Card.OGRE );
        opponent.giveCard( Card.ZOMBIE );
        opponent.giveCard( Card.SKELETON );
        opponent.giveCard( Card.SKULLKING );

        //Displaying
        while ( isRunning ) {
            //Players Turn
            draw( opponent, player, board );
            System.out.println( "What is your course of action?" );
            System.out.print( "Select Card >>> " );
            try {
                Card c = Card.getCard( scn.nextLine( ) );
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


        scn.nextLine( );
    }

    public static void draw( Player p1, Player p2, Board board ) {
        cls( );
        System.out.println( "Opponent's Hand\n" + p1.displayCardBacks( ) + "\n" );
        System.out.println( board.displayBoard( ) );
        System.out.println( "Your Hand\n" + p2.displayCards( ) );
    }

    public static boolean isValidPlay( Player p, Board board, Card c, Coordinate pos ) {
        return pos.x >= 1
                && pos.x <= 4
                && !board.cardExists( pos )
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