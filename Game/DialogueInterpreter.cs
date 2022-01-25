using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game
{
    public class DialogueInterpreter
    {
        string _filePath;
        string _fileContents;
        string[] contentsArray;

        public DialogueInterpreter()
        {

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
            for (int i = 0; i < contentsArray.Length - 1; i++)
            {
                //check for code
                if (contentsArray[i].StartsWith("@"))
                {
                    if (contentsArray[i].StartsWith("@goto"))
                    {
                        int from = contentsArray[i].IndexOf("@goto=\"") + "@goto\"".Length;
                        int to = contentsArray[i].LastIndexOf("\"") - from;
                        string name = contentsArray[i].Substring(from, to);
                        i = getIndexOfName(name) + 1;
                    }
                }
                //if it isn't a code line
                else
                {
                    Utility.ConsoleFunctions.cls();
                    Utility.ConsoleFunctions.writeDialogue(contentsArray[i], 5);
                    Utility.ConsoleFunctions.waitForInput("Next...");
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