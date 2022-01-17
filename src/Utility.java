import java.util.ArrayList;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

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

        //BACKGROUND COLORS
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

        public static void gameOver( ) {
            System.out.println( """
                      _____                         ____                 
                     / ____|                       / __ \\                
                    | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
                    | | |_ |/ _` | '_ ` _ \\ / _ \\ | |  | \\ \\ / / _ \\ '__|
                    | |__| | (_| | | | | | |  __/ | |__| |\\ V /  __/ |   
                     \\_____|\\__,_|_| |_| |_|\\___|  \\____/  \\_/ \\___|_|   
                                                """
            );
        }
    }

    public static class ConsoleFunctions {
        public static void cls() {
            System.out.print("\033[H\033[2J");
            System.out.flush();
        }

        public static void wait(int milliseconds) {
            try {
                TimeUnit.MILLISECONDS.sleep(milliseconds);
            } catch (Exception e) {
                System.out.println("wait failed");
            }
        }

        public static void waitForInput() {
            Scanner scn = new Scanner(System.in);
            System.out.print( "Press 'Enter' to continue..." );
            scn.nextLine();
        }
    }

    public static class Debug {
        public static void printDebug( boolean isDebug, String str ) {
            if ( isDebug ) {
                System.out.println( str );
            }
        }

        public static void wait(boolean isDebug, int milliseconds) {
            if (isDebug) {
                try {
                    TimeUnit.MILLISECONDS.sleep(milliseconds);
                } catch (Exception e) {
                    System.out.println("debug wait failed");
                }
            }
        }
    }

    public static class ArrayHelper {
        public static boolean contains(ArrayList<Card> cards, Card c) {
            //I hate this but doing cards.contains(c); doesn't work
            for (Card card : cards) {
                if (c.getType().getName().equals(card.getType().getName())) {
                    return true;
                }
            }
            return false;
        }

        public static void remove(ArrayList<Card> cards, Card c) {
            //I also hate this but doing cards.remove(c); doesn't work
            for (Card card : cards) {
                if (c.getType().getName().equals(card.getType().getName())) {
                    cards.remove(card);
                    break;
                }
            }
        }

        public static int getIndex(ArrayList<Card> cards, Card c) {
            for (int i = 0; i < cards.size() - 1; i++) {
                if (c.getType().getName().equals(cards.get(i).getType().getName())) {
                    return i;
                }
            }
            return -1;
        }
    }

}

