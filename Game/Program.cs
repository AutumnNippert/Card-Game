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

            Character c = new Character();
            c.addQuest(new Quest("tomato sauce", new[] { "Tomato Sauce Hint" }));
            c.completeQuest("tomato sauce");
            DialogueInterpreter DI = new DialogueInterpreter(c);
            DI.loadFile(@"assets\dialogue\test.dlg");
            DI.init();
            Console.WriteLine("Talking again time");
            Utility.ConsoleFunctions.wait(1000);
            DI.init();
            Decks decks = new Decks();
            decks.initDecks();
            c.setDeck(decks.Human);
            MainMenu mm = new MainMenu(c);
            mm.init();

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