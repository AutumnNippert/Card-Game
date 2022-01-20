package screens;

import utility.Utility;

public class IntroSequence {
    public static void init( ) {
        Utility.ConsoleFunctions.cls( );
        System.out.println( """
                                
                                
                                
                                
                                    Cardigan Games
                                
                                
                                
                """ );
        Utility.ConsoleFunctions.wait( 4000 );
        Utility.ConsoleFunctions.cls( );
        System.out.println( """
                                
                                
                                
                                
                                    The Card Game
                                
                                
                                
                """ );
        Utility.ConsoleFunctions.wait( 2000 );
        MainMenu.init( );
    }
}
