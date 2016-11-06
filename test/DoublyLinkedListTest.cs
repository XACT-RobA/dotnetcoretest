using System;
using System.Collections.Generic;
using DotNetCoreTest.DoublyLinkedList;
using Xunit;

namespace DotNetCoreTest.Tests
{
    public class DoublyLinkedListTest
    {
        private static IDoublyLinkedList<string> ListEmpty
        {
            get 
            {
                var list = new DoublyLinkedList<string>();
                return list;
            }
        }

        private static IDoublyLinkedList<string> ListOneElement
        {
            get
            {
                var list = new DoublyLinkedList<string>();
                list.Add("Bob");
                return list;
            }
        }

        private static IDoublyLinkedList<string> ListTwoElements
        {
            get
            {
                var list = new DoublyLinkedList<string>();
                list.Add("Bob");
                list.Add("Alice");
                return list;
            }
        }

        private static IDoublyLinkedList<string> ListThreeElementsWithRepeat
        {
            get
            {
                var list = new DoublyLinkedList<string>();
                list.Add("Bob");
                list.Add("Alice");
                list.Add("Bob");
                return list;
            }
        }

        public static IEnumerable<object[]> CountTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0 },
                    new object[] { ListOneElement, 1 },
                    new object[] { ListTwoElements, 2 },
                    new object[] { ListThreeElementsWithRepeat, 3 },
                };
            }
        }

        public static IEnumerable<object[]> IsEmptyTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, true },
                    new object[] { ListOneElement, false },
                    new object[] { ListTwoElements, false },
                    new object[] { ListThreeElementsWithRepeat, false },
                };
            }
        }

        [Theory, MemberData(nameof(CountTestData))]
        public void TestCount(IDoublyLinkedList<string> list, int count)
        {
            Assert.Equal(list.Count, count);
        }

        [Theory, MemberData(nameof(IsEmptyTestData))]
        public void TestHasNodes(IDoublyLinkedList<string> list, bool isEmpty)
        {
            Assert.NotEqual(list.HasNodes, isEmpty);
        }

        [Theory, MemberData(nameof(IsEmptyTestData))]
        public void TestIsEmpty(IDoublyLinkedList<string> list, bool isEmpty)
        {
            Assert.Equal(list.IsEmpty, isEmpty);
        }
    }
}