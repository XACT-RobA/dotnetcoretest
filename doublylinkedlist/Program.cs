using System;
using DoublyLinkedList.Interfaces;

namespace DoublyLinkedList
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

            list.Add("TestHead");
            list.Add("TestTail");
            list.Append("TestTail");
            list.Append("TestHead");
            OutputList();

            list.Remove("TestTail");
            list.RemoveAt(0);
            list.RemoveAt(list.Find("TestHead"));
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
