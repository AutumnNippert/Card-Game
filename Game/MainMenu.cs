using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game
{
    public class MainMenu
    {
        Character character;
        public MainMenu(Character c)
        {
            character = c;
        }
        public void init()
        {
            //MusicPlayer musicPlayer = new MusicPlayer( );
            //try {
            //    musicPlayer = new MusicPlayer( "Assets\\Music\\MainMenu.wav" );
            //    musicPlayer.loop( );
            //} catch ( Exception e ) {
            //    System.out.println( "Failed to play music\n" + e.toString( ) );
            //    Utility.ConsoleFunctions.wait( 5000 );
            //}
            Menu mainMenu = new Menu("Main Menu", new List<string> {

                 "Start Game" ,
                 "Lore" ,
                 "Exit"

        });

            while (true)
            {
                Utility.ConsoleFunctions.cls();
                mainMenu.display();
                Decks decks = new Decks();
                decks.initDecks();
                try
                {
                    int i = mainMenu.getIntValue();
                    if (i == 1)
                    {
                        //initDecks


                        Board board = Utility.Game.createEmptyBoard();

                        Player opponent = new Player(1, character.deck, 20);
                        Player player = new Player(2, decks.Human, 20);

                        Match match = new Match(player, opponent, board, decks);

                        match.init();
                    }
                    else if (i == 2)
                    {
                        Lore lore = new Lore(decks);
                        lore.init();
                    }
                    else if (i == 3)
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Im at the main menu again?");
                    Debug.Write(e.StackTrace);
                    Utility.ConsoleFunctions.waitForInput();
                }

            }

        }
    }
}