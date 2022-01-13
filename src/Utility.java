import java.util.Scanner;

public class Utility {
    public static class Colors {
        //COLORS
        public static final String RESET = "\u001B[0m";
        public static final String BLACK = "\u001B[30m";
        public static final String RED = "\u001B[31m";
        public static final String GREEN = "\u001B[32m";
        public static final String YELLOW = "\u001B[33m";
        public static final String BLUE = "\u001B[34m";
        public static final String PURPLE = "\u001B[35m";
        public static final String CYAN = "\u001B[36m";
        public static final String WHITE = "\u001B[37m";

        public static final String BLACK_BACKGROUND = "\u001B[40m";
        public static final String RED_BACKGROUND = "\u001B[41m";
        public static final String GREEN_BACKGROUND = "\u001B[42m";
        public static final String YELLOW_BACKGROUND = "\u001B[43m";
        public static final String BLUE_BACKGROUND = "\u001B[44m";
        public static final String PURPLE_BACKGROUND = "\u001B[45m";
        public static final String CYAN_BACKGROUND = "\u001B[46m";
        public static final String WHITE_BACKGROUND = "\u001B[47m";
    }

    public static class MessagePrompts {
        public static void invalidPosition( ) {
            Scanner scn = new Scanner( System.in );
            System.out.println( "Invalid position selected" );
            System.out.print( "Press 'Enter' to continue..." );
            scn.nextLine( );
        }

        public static void notEnoughMana( ) {
            Scanner scn = new Scanner( System.in );
            System.out.println( "Not enough mana to accomplish that action" );
            System.out.print( "Press 'Enter' to continue..." );
            scn.nextLine( );
        }

        public static void valueNotInRange( ) {
            Scanner scn = new Scanner( System.in );
            System.out.println( "Value not in range" );
            System.out.print( "Press 'Enter' to continue..." );
            scn.nextLine( );
        }

        public static void invalidSelection( ) {
            Scanner scn = new Scanner( System.in );
            System.out.println( "Invalid selection" );
            System.out.print( "Press 'Enter' to continue..." );
            scn.nextLine( );
        }
    }
}
