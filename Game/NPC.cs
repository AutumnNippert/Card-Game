﻿using System;
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

        Type type;
        String name;
        int hp;

        public NPC(Type type, String name, int hp)
        {
            this.type = type;
            this.name = name;
            this.hp = hp;
        }



    }

}