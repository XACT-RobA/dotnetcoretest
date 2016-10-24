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
            list.Add("TestHead");
            list.Append("TestTail");
            OutputList();

            Console.WriteLine(list.PopHead());
            Console.WriteLine(list.PopTail());
            Console.WriteLine("");

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
