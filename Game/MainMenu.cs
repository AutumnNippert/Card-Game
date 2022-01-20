
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MainMenu
{
    public static void init()
    {
        //MusicPlayer musicPlayer = new MusicPlayer( );
        //try {
        //    musicPlayer = new MusicPlayer( "Assets\\Music\\MainMenu.wav" );
        //    musicPlayer.loop( );
        //} catch ( Exception e ) {
        //    System.out.println( "Failed to play music\n" + e.toString( ) );
        //    Utility.ConsoleFunctions.wait( 5000 );
        //}
        Menu mainMenu = new Menu("Main Menu", new List<String> {

                 "Start Game" ,
                 "Lore" ,
                 "Exit"

        });

        while (true)
        {
            Utility.ConsoleFunctions.cls();
            mainMenu.display();
            try
            {
                int i = mainMenu.getIntValue();
                if (i == 1)
                {
                    Game.init();
                }
                else if (i == 2)
                {
                    //lore page
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
