using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
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

        Quest[] quests;
        Type type;
        string name;
        int hp;

        public NPC(Type type, string name, int hp)
        {
            this.type = type;
            this.name = name;
            this.hp = hp;
        }

        //quests will just be bools and strings for hints that get set in some places

    }
}