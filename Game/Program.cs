using System;
using System.IO;
using System.Text.Json;

namespace Game
{
    class Program
    {
        public void helloWorld(string text)
        {
            Console.WriteLine(text);
        }

        Program()
        {
            //IntroSequence intro = new IntroSequence();
            //intro.init();
            //MainMenu mm = new MainMenu();
            //mm.init();

            DialogueInterpreter DI = new DialogueInterpreter();
            DI.loadFile(@"assets\dialogue\test.dlg");
            DI.init();

            //Console.Write(Enum.GetName(typeof(CardType),decks.Human.cards[0].type));
            //typeof(Program).GetMethod("helloWorld").Invoke(this,new object[] { "test" });.

        }
        static void Main(string[] args)
        {
            Utility.initConfig("config.json");
            new Program();
        }
    }
}