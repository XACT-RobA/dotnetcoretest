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

            Console.WriteLine(list[list.Find("Mia")]);
        }

        private static void OutputList()
        {
            foreach(var value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("");
        }
    }
}
