using System;
using System.Collections.Generic;
using DotNetCoreTest.BinaryTree;
using DotNetCoreTest.CircularLinkedList;
using DotNetCoreTest.DoublyLinkedList;
using DotNetCoreTest.SinglyLinkedList;

namespace DotNetCoreTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestSinglyLinkedList();

            TestDoublyLinkedList();

            TestCircularLinkedList();

            TestBinaryTree();
        }

        private static void TestSinglyLinkedList()
        {
            Console.WriteLine("Testing singly linked list");
            Console.WriteLine("");

            ISinglyLinkedList<string> list = new SinglyLinkedList<string>();

            list.Add("Bob");
            list.Add("Alice");
            list.Add("Eve");
            list.Add("TestHead");
            list.Append("TestTail");
            OutputList(list);

            Console.WriteLine(list.PopHead());
            Console.WriteLine(list.PopTail());
            Console.WriteLine("");
            OutputList(list);
        }

        private static void TestDoublyLinkedList()
        {
            Console.WriteLine("Testing doubly linked list");
            Console.WriteLine("");

            IDoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.Add("Bob");
            list.Add("Alice");
            list.Add("Eve");
            OutputList(list);

            list.Add("TestHead");
            list.Add("TestTail");
            list.Append("TestTail");
            list.Append("TestHead");
            OutputList(list);

            list.Remove("TestTail");
            list.RemoveAt(0);
            list.RemoveAt(list.Find("TestHead"));
            OutputList(list);

            list.Reverse();
            OutputList(list);
        }

        private static void TestCircularLinkedList()
        {
            Console.WriteLine("Testing circular linked list");
            Console.WriteLine("");

            ICircularLinkedList<string> list = new CircularLinkedList<string>();

            list.Add("Bob");
            list.Add("Alice");
            list.Add("Eve");
            OutputList(list);

            list.Add("Test");
            OutputList(list);

            Console.WriteLine(list.Pop());
            Console.WriteLine("");
            OutputList(list);

            list.Add("Test");
            list.Add("Test");
            OutputList(list);

            list.Remove("Test");
            OutputList(list);

            list.Reverse();
            OutputList(list);

            list.Reverse();
            OutputList(list);
        }

        private static void TestBinaryTree()
        {
            IBinaryTree<string> tree = new BinaryTree<string>("Top");

            tree.AddLeft("Left");
            tree.AddRight("Right");

            tree.Left.AddLeft("Left left");
            tree.Left.AddRight("Left right");

            tree.Right.AddLeft("Right left");
            tree.Right.AddRight("Right right");

            var list = tree.Recurse();
            OutputList(list);
        }

        private static void OutputList<T>(IEnumerable<T> list)
        {
            foreach(var value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("");
        }
    }
}
