using System;
using Xunit;
using DotNetCoreTest.SinglyLinkedList;
using System.Collections.Generic;
using Xunit.Extensions;

namespace DotNetCoreTest.Tests
{
    public class TestSinglyLinkedList
    {
        private static ISinglyLinkedList<string> listEmpty;

        private static ISinglyLinkedList<string> listOneElement;

        private static ISinglyLinkedList<string> listTwoElements;

        private static ISinglyLinkedList<string> ListEmpty
        {
            get 
            {
                if (listEmpty == null) listEmpty = new SinglyLinkedList<string>();
                return listEmpty;
            }
        }

        private static ISinglyLinkedList<string> ListOneElement
        {
            get
            {
                if (listOneElement == null)
                {
                    listOneElement = new SinglyLinkedList<string>();
                    listOneElement.Add("Rob");
                }
                return listOneElement;
            }
        }

        private static ISinglyLinkedList<string> ListTwoElements
        {
            get
            {
                if (listTwoElements == null)
                {
                    listTwoElements = new SinglyLinkedList<string>();
                    listTwoElements.Add("Rob");
                    listTwoElements.Add("Alice");
                }
                return listTwoElements;
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
                    new object[] { ListTwoElements, 2 }
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
                    new object[] { ListTwoElements, false }
                };
            }
        }

        public static IEnumerable<object[]> HasNodesTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, false },
                    new object[] { ListOneElement, true },
                    new object[] { ListTwoElements, true }
                };
            }
        }

        [Theory, MemberData(nameof(CountTestData))]
        public void TestCount(ISinglyLinkedList<string> list, int count)
        {
            Assert.Equal(list.Count, count);
        }

        [Theory, MemberData(nameof(IsEmptyTestData))]
        public void TestIsEmpty(ISinglyLinkedList<string> list, bool isEmpty)
        {
            Assert.Equal(list.IsEmpty, isEmpty);
        }

        [Theory, MemberData(nameof(HasNodesTestData))]
        public void TestHasNodes(ISinglyLinkedList<string> list, bool hasNodes)
        {
            Assert.Equal(list.HasNodes, hasNodes);
        }
    }
}
