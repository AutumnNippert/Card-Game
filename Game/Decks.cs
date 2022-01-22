using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

[Serializable]
public class Decks
{
    public Deck Human { get; set; }
    public Deck Undead {get; set;}

    public Decks()
    {
    }

    public void initDecks()
    {
        Human = new Deck();
        Undead = new Deck();
        Human.addCards(new[] { 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5 });
        Undead.addCards(new[] { 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8 });
    }

}
