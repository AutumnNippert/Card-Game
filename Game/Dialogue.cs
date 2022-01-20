using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Dialogue
    {
        NPC npc;
        String fileName;
        int position;


        public Dialogue(NPC npc, String fileName)
        {
            this.npc = npc;
            this.fileName = fileName;
        }

        public void init()
        {

        }
    }
}
