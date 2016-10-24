using System;
using SinglyLinkedList.Interfaces;

namespace SinglyLinkedList
{
    public class Program
    {
        private static ICustomLinkedList<string> list;

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Console.WriteLine("");

            list = new CustomLinkedList<string>();
            list.Add("Rob");
            list.Add("Alice");
            list.Add("Mia");
            list.Add("Penelope");
            OutputList();
        }

        private static void OutputList()
        {
            var array = list.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Data + " " + array[i].UID.ToString());
            }

            Console.WriteLine("");
        }
    }
}
