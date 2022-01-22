using System;
using System.Collections.Generic;
using System.Text;

public enum NPCs
{
    LoreMaster
}
public class NPC
{
    public enum Type
    {
        Friendly,
        Hostile
    }

    Type type;
    string name;
    int hp;

    public NPC(Type type, string name, int hp)
    {
        this.type = type;
        this.name = name;
        this.hp = hp;
    }



}