import java.util.ArrayList;

public class MainMenu {
    public static void init( ) {
        MusicPlayer musicPlayer = new MusicPlayer( );
        try {
            musicPlayer = new MusicPlayer( "Assets\\Music\\MainMenu.wav" );
            musicPlayer.loop( );
        } catch ( Exception e ) {
            System.out.println( "Failed to play music\n" + e.toString( ) );
            Utility.ConsoleFunctions.wait( 5000 );
        }
        Menu mainMenu = new Menu( "Main Menu", new ArrayList<>( ) {
            {
                add( "Start Game" );
                add( "Lore" );
                add( "Exit" );
            }
        } );

        while ( true ) {
            Utility.ConsoleFunctions.cls( );
            mainMenu.display( );
            try {
                int i = mainMenu.getIntValue( );
                if ( i == 1 ) {
                    //start game
                    try {
                        musicPlayer.close( );
                    } catch ( Exception e ) {
                        e.printStackTrace( );
                    }
                    Game.init( );
                } else if ( i == 2 ) {
                    //lore page
                } else if ( i == 3 ) {
                    //exit
                    System.exit( 0 );
                }
            } catch ( Exception e ) {
                System.out.println( "Im at the main menu again?" );
                e.printStackTrace( );
                Utility.ConsoleFunctions.waitForInput( );
            }

        }

    }
}
