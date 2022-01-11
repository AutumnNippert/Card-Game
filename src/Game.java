import java.util.Scanner;

public class Game {
    private int turn = 0;

    public static void initGame( ) {
        boolean isRunning = true;
        Scanner scn = new Scanner( System.in );
        cls( );
        System.out.println( "Card game time pog" );


        Board board = new Board(
                new Card[][]
                        {
                                { Card.KNIGHT, Card.WIZARD, Card.TANK, Card.OGRE },
                                { Card.EMPTY, Card.EMPTY, Card.EMPTY, Card.EMPTY }
                        }
        );
        System.out.println( board.displayBoard());



        Player player = new Player( );
        player.giveCard( Card.KNIGHT );
        player.giveCard( Card.WIZARD );
        player.giveCard( Card.TANK );
        System.out.println( player.displayCards( ) );

        scn.nextLine();
    }


    public static void cls( ) {
        System.out.print( "\033[H\033[2J" );
        System.out.flush( );
    }

    public static String displayBoard( Board board ) {
        String str = "";

        return str;
    }
}