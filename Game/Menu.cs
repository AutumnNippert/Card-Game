using System;
using System.Collections.Generic;

namespace Game
{
    public class Menu
    {
        public string value;
        public string name;
        public List<string> options;

        public Menu(string name, List<string> options)
        {
            this.name = name;
            this.options = options;
        }

        public void display()
        {
            Console.WriteLine(name);
            for (int i = 1; i < options.Count + 1; i++)
            {
                Console.WriteLine("(" + i + ") " + options[i - 1]);
            }
            Console.Write(">>> ");
            value = Console.ReadLine();
        }

        public int getIntValue()
        {
            return int.Parse(value);
        }

        public string getStringValue()
        {
            return value;
        }
    }
}