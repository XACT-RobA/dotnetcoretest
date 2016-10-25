using System;
using CircularLinkedList.Interfaces;

namespace CircularLinkedList
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

            list.Add("Test");
            OutputList();

            Console.WriteLine(list.Pop());
            Console.WriteLine("");
            OutputList();

            list.Add("Test");
            list.Add("Test");
            OutputList();

            list.Remove("Test");
            OutputList();

            list.Reverse();
            OutputList();

            list.Reverse();
            OutputList();

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
