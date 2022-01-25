using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game
{
    public class DialogueInterpreter
    {
        Character _character;
        string _filePath;
        string _fileContents;
        string[] contentsArray;
        int position;

        public DialogueInterpreter(Character c)
        {
            _character = c;
        }

        public void loadFile(string filePath)
        {
            try
            {
                _filePath = filePath;
                _fileContents = File.ReadAllText(_filePath);
            }
            catch (FileNotFoundException e)
            {
                Utility.Debug.printDebug(e.StackTrace);
            }
        }

        public void init()
        {
            //split the string
            contentsArray = _fileContents.Split("\r\n");
            for (;  position < contentsArray.Length; position++)
            {
                //check for code
                if (contentsArray[position].StartsWith("@"))
                {
                    Utility.ConsoleFunctions.cls();
                    if (contentsArray[position].StartsWith("@leave"))
                    {
                        position++;
                        break;
                    }
                    if (contentsArray[position].StartsWith("@goto="))
                    {
                        if (contentsArray[position].Contains("flag="))
                        {
                            int from = contentsArray[position].IndexOf(":flag=\"") + ":flag=\"".Length;
                            int to = contentsArray[position].LastIndexOf("\"") - from;
                            string flag = contentsArray[position].Substring(from, to);
                            // if player hasn't completed the quest, use the goto statement
                            if(!(_character.hasCompetedQuest(flag)))
                            {
                                int fromThis = contentsArray[position].IndexOf("@goto=\"") + "@goto\"".Length;
                                int toThis = contentsArray[position].LastIndexOf(":") - fromThis;
                                string name = contentsArray[position].Substring(fromThis, toThis);
                                position = getIndexOfName(name) + 1;
                            }
                        }
                        else
                        {
                            int from = contentsArray[position].IndexOf("@goto=\"") + "@goto\"".Length;
                            int to = contentsArray[position].LastIndexOf("\"") - from;
                            string name = contentsArray[position].Substring(from, to);
                            position = getIndexOfName(name) + 1;
                        }
                    }
                }
                //if it isn't a code line
                else
                {
                    Utility.ConsoleFunctions.writeDialogue(contentsArray[position], 5);
                    Utility.ConsoleFunctions.waitForInput("");
                }
            }
            Utility.ConsoleFunctions.cls();
        }
        int getIndexOfName(string name)
        {
            for (int i = 0; i < contentsArray.Length - 1; i++)
            {
                if (contentsArray[i].Contains("name=\"" + name + "\""))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}