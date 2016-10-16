using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryReferences
{
    class Program
    {
        private static List<FactoryItem> objects;

        static void Main(string[] args)
        {
            FactoryItem player = null;
            Create("Bob", ref player);
            FactoryItem girl = null;
            Create("Claire", ref girl);
            FactoryItem referer = player;
            DisplayPlayerInfo(player);
            DisplayPlayerInfo(girl);
            Destroy(ref player);
            DisplayPlayerInfo(player);
            DisplayPlayerInfo(referer);
            Console.ReadLine();
        }

        static void DisplayPlayerInfo(FactoryItem item)
        {
            bool isValid = !item.Equals(null);
            Console.WriteLine("Player Ref? " + isValid);
            if (isValid)
            {
                Console.WriteLine("Player alive? " + item.alive);
                Console.WriteLine("Player name: " + item.name);
                Console.WriteLine("Player ID: " + item.ID);
            }
        }

        static void Destroy(ref FactoryItem item)
        {
            if(objects != null)
            {
                int index = objects.IndexOf(item);
                objects[index] = null;
                objects.RemoveAt(index);
                Console.WriteLine(objects.Count);
                item.Destroy();               
                //item = null;
            }
        }

        static void Create(string name, ref FactoryItem pointer)
        {
            if(objects != null)
            {
                objects.Add(new FactoryItem(name, objects.Count));
            }
            else
            {
                objects = new List<FactoryItem>();
                objects.Add(new FactoryItem(name, objects.Count));
            }
            pointer = objects[objects.Count - 1];
        }
    }
}
