using System;

namespace Game
{
    public class IntroSequence
    {
        public IntroSequence() { }
        public void init()
        {
            Utility.ConsoleFunctions.cls();
            Console.WriteLine(@"
                                
                                
                                
                                
                                    Cardigan Games
                                
                                
                                
                ");
            Utility.ConsoleFunctions.wait(4000);
            Utility.ConsoleFunctions.cls();
            Console.WriteLine(@"
                                
                                
                                
                                
                                    The Card Game
                                
                                
                                
                ");
            Utility.ConsoleFunctions.wait(2000);
        }
    }
}