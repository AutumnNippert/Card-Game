using System;
using System.Collections.Generic;
using System.Threading;

public class Utility
{
    public static class Colors
    {
        //COLORS
        public static string RESET = "\u001B[0m";
        public static string BLACK = "\u001B[30m";
        public static string RED = "\u001B[31m";
        public static string GREEN = "\u001B[32m";
        public static string YELLOW = "\u001B[33m";
        public static string BLUE = "\u001B[34m";
        public static string PURPLE = "\u001B[35m";
        public static string CYAN = "\u001B[36m";
        public static string WHITE = "\u001B[37m";

        //BACKGROUND COLORS
        public static string BLACK_BACKGROUND = "\u001B[40m";
        public static string RED_BACKGROUND = "\u001B[41m";
        public static string GREEN_BACKGROUND = "\u001B[42m";
        public static string YELLOW_BACKGROUND = "\u001B[43m";
        public static string BLUE_BACKGROUND = "\u001B[44m";
        public static string PURPLE_BACKGROUND = "\u001B[45m";
        public static string CYAN_BACKGROUND = "\u001B[46m";
        public static string WHITE_BACKGROUND = "\u001B[47m";
    }

    public static class MessagePrompts
    {
        public static void invalidPosition()
        {
            Console.WriteLine("Invalid position selected");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public static void notEnoughMana()
        {
            Console.WriteLine("Not enough mana to accomplish that action");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public static void valueNotInRange()
        {
            Console.WriteLine("Value not in range");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public static void invalidSelection()
        {
            Console.WriteLine("Invalid selection");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public static void gameOver()
        {
            Console.WriteLine(@"
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

    public static class ConsoleFunctions
    {
        public static void cls()
        {
            Console.Clear();
        }

        public static void wait(int milliseconds)
        {
            try
            {
                Thread.Sleep(milliseconds);
            }
            catch (Exception e)
            {
                Console.WriteLine("wait failed");
            }
        }

        public static void waitForInput()
        {
            Console.Write("Awaiting Input...");
            Console.ReadLine();

        }
    }

    public static class Debug
    {
        public static void printDebug(bool isDebug, string str)
        {
            if (isDebug)
            {
                Console.WriteLine(str);
            }
        }

        public static void wait(bool isDebug, int milliseconds)
        {
            if (isDebug)
            {
                try
                {
                    Thread.Sleep(milliseconds);
                }
                catch (Exception e)
                {
                    Console.WriteLine("debug wait failed");
                }
            }
        }
    }

    public static class ArrayHelper
    {
        public static bool contains(List<Card> cards, Card c)
        {
            //I hate this but doing cards.contains(c); doesn't work
            foreach (Card card in cards)
            {
                if (c.name == card.name)
                {
                    return true;
                }
            }
            return false;
        }

        public static void remove(List<Card> cards, Card c)
        {
            //I also hate this but doing cards.remove(c); doesn't work
            foreach (Card card in cards)
            {
                if (c.name == card.name)
                {
                    cards.Remove(card);
                    break;
                }
            }
        }

        public static int getIndex(List<Card> cards, Card c)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (c.name == cards[i].name)
                {
                    return i;
                }
            }
            return -1;
        }
    }

}

