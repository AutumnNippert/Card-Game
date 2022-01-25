using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Character
    {
        public List<Quest> quests = new List<Quest>();
        public List<Quest> questsComplete = new List<Quest>();
        public Deck deck;
        public Character()
        {

        }
        public void addQuest(Quest q)
        {
            quests.Add(q);
        }
        public void completeQuest(Quest q)
        {
            quests.Remove(q);
            questsComplete.Add(q);
        }
        public void completeQuest(string name)
        {
            Quest q = Quest.getQuestByName(name, quests);
            quests.Remove(q);
            questsComplete.Add(q);
        }
        public bool hasCompetedQuest(string name)
        {
            foreach(Quest q in questsComplete)
            {
                if(q._name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void setDeck(Deck d)
        {
            deck = d;
        }
    }
}
