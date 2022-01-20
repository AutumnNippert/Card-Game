using System;

public class IntroSequence {
    public static void init( ) {
        Utility.ConsoleFunctions.cls( );
        Console.WriteLine( @"
                                
                                
                                
                                
                                    Cardigan Games
                                
                                
                                
                " );
        Utility.ConsoleFunctions.wait( 4000 );
        Utility.ConsoleFunctions.cls( );
        Console.WriteLine( @"
                                
                                
                                
                                
                                    The Card Game
                                
                                
                                
                " );
        Utility.ConsoleFunctions.wait( 2000 );
        MainMenu.init( );
    }
}
