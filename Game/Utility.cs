using System;
using System.Collections.Generic;
using System.Threading;

public class Utility {
    public static class Colors {
        //COLORS
        public static  String RESET = "\u001B[0m";
        public static  String BLACK = "\u001B[30m";
        public static  String RED = "\u001B[31m";
        public static  String GREEN = "\u001B[32m";
        public static  String YELLOW = "\u001B[33m";
        public static  String BLUE = "\u001B[34m";
        public static  String PURPLE = "\u001B[35m";
        public static  String CYAN = "\u001B[36m";
        public static  String WHITE = "\u001B[37m";

        //BACKGROUND COLORS
        public static  String BLACK_BACKGROUND = "\u001B[40m";
        public static  String RED_BACKGROUND = "\u001B[41m";
        public static  String GREEN_BACKGROUND = "\u001B[42m";
        public static  String YELLOW_BACKGROUND = "\u001B[43m";
        public static  String BLUE_BACKGROUND = "\u001B[44m";
        public static  String PURPLE_BACKGROUND = "\u001B[45m";
        public static  String CYAN_BACKGROUND = "\u001B[46m";
        public static  String WHITE_BACKGROUND = "\u001B[47m";
    }

    public static class MessagePrompts {
        public static void invalidPosition( ) {
            Console.WriteLine( "Invalid position selected" );
            Console.Write( "Press 'Enter' to continue..." );
                            Console.ReadLine(); 
        }

        public static void notEnoughMana( ) {
            Console.WriteLine( "Not enough mana to accomplish that action" );
            Console.Write( "Press 'Enter' to continue..." );
                            Console.ReadLine(); 
        }

        public static void valueNotInRange( ) {
            Console.WriteLine( "Value not in range" );
            Console.Write( "Press 'Enter' to continue..." );
                            Console.ReadLine(); 
        }

        public static void invalidSelection( ) {
            Console.WriteLine( "Invalid selection" );
            Console.Write( "Press 'Enter' to continue..." );
                            Console.ReadLine(); 
        }

        public static void gameOver( ) {
            Console.WriteLine( @"
                      _____                         ____                 
                     / ____|                       / __ \                
                    | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
                    | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
                    | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
                     \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   
                                                "
            );
        }
    }

    public static class ConsoleFunctions {
        public static void cls() {
            Console.Write("\033[H\033[2J");
            Console.Clear();
                }

        public static void wait(int milliseconds) {
            try {
                Thread.Sleep(milliseconds);
            } catch (Exception e) {
                Console.WriteLine("wait failed");
            }
        }

        public static void waitForInput() {
                Console.Write("Awaiting Input...");
                Console.ReadLine();

        }
    }

    public static class Debug {
        public static void printDebug( bool isDebug, String str ) {
            if ( isDebug ) {
                Console.WriteLine( str );
            }
        }

        public static void wait(bool isDebug, int milliseconds) {
            if (isDebug) {
                try {
                    Thread.Sleep(milliseconds);
                } catch (Exception e) {
                    Console.WriteLine("debug wait failed");
                }
            }
        }
    }

    public static class ArrayHelper {
        public static bool contains(List<Card> cards, Card c) {
            //I hate this but doing cards.contains(c); doesn't work
            foreach (Card card in cards) {
                if (c.name == card.name) {
                    return true;
                }
            }
            return false;
        }

        public static void remove(List<Card> cards, Card c) {
            //I also hate this but doing cards.remove(c); doesn't work
            foreach (Card card in cards) {
                if (c.name == card.name) {
                    cards.Remove(card);
                    break;
                }
            }
        }

        public static int getIndex(List<Card> cards, Card c) {
            for (int i = 0; i < cards.Count - 1; i++) {
                if (c.name == cards[i].name) {
                    return i;
                }
            }
            return -1;
        }
    }

}

