using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Quest
    {
        public string _name;
        public string[] _hints;
        public Quest(string name, string[] hints)
        {
            _name = name;
            _hints = hints;
        }

        public static Quest getQuestByName(string name, List<Quest> quests)
        {
            foreach (Quest q in quests)
            {
                if (q._name == name)
                {
                    return q;
                }
            }
            return new Quest(null, null);
        }
    }

}
