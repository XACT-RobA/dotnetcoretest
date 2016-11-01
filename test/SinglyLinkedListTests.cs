using System;
using Xunit;
using DotNetCoreTest.SinglyLinkedList;
using System.Collections.Generic;
using Xunit.Extensions;

namespace DotNetCoreTest.Tests
{
    public class TestSinglyLinkedList
    {

        private static ISinglyLinkedList<string> ListEmpty
        {
            get 
            {
                var listEmpty = new SinglyLinkedList<string>();
                return listEmpty;
            }
        }

        private static ISinglyLinkedList<string> ListOneElement
        {
            get
            {
                var listOneElement = new SinglyLinkedList<string>();
                listOneElement.Add("Rob");
                return listOneElement;
            }
        }

        private static ISinglyLinkedList<string> ListTwoElements
        {
            get
            {
                var listTwoElements = new SinglyLinkedList<string>();
                listTwoElements.Add("Rob");
                listTwoElements.Add("Alice");
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
                    new object[] { ListTwoElements, 2 },
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
                    new object[] { ListTwoElements, true },
                };
            }
        }

        public static IEnumerable<object[]> ArrayIndexTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0, null, true },
                    new object[] { ListOneElement, 0, "Rob", false },
                    new object[] { ListOneElement, 1, null, true },
                    new object[] { ListTwoElements, 0, "Alice", false},
                    new object[] { ListTwoElements, 1, "Rob", false},
                    new object[] { ListTwoElements, 2, null, true},
                };
            }
        }

        public static IEnumerable<object[]> ArrayTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0, new string[] {} },
                    new object[] { ListOneElement, 1, new string[] {"Rob"} },
                    new object[] { ListTwoElements, 2, new string[] {"Alice", "Rob"} },
                };
            }
        }

        public static IEnumerable<object[]> PopTestData
        {
            get
            {
                return ArrayTestData;
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

        [Theory, MemberData(nameof(ArrayIndexTestData))]
        public void TestArrayIndex(ISinglyLinkedList<string> list, int index, string value, bool throws)
        {
            if (throws)
            {
                Exception ex = Assert.Throws<Exception>(() => list[index]);
                Assert.Equal(ex.Message, "Outside bounds of list");
            }
            else
            {
                Assert.Equal(value, list[index]);
            }
        }

        [Theory, MemberData(nameof(ArrayTestData))]
        public void TestToArray(ISinglyLinkedList<string> list, int length, string[] arr)
        {
            var value = list.ToArray();

            Assert.Equal(length, value.Length);

            for (int i = 0; i < length; i++)
            {
                Assert.Equal(arr[i], value[i]);
            }
        }

        [Theory, MemberData(nameof(ArrayTestData))]
        public void TestGetNodeArray(ISinglyLinkedList<string> list, int length, string[] arr)
        {
            var value = list.GetNodeArray();

            Assert.Equal(length, value.Length);

            for (int i = 0; i < length; i++)
            {
                Assert.Equal(arr[i], value[i].Data);
            }
        }

        [Theory, MemberData(nameof(ArrayIndexTestData))]
        public void TestGet(ISinglyLinkedList<string> list, int index, string value, bool throws)
        {
            if (throws)
            {
                Exception ex = Assert.Throws<Exception>(() => list.Get(index));
                Assert.Equal(ex.Message, "Outside bounds of list");
            }
            else
            {
                Assert.Equal(value, list.Get(index));
            }
        }

        [Theory, MemberData(nameof(ArrayIndexTestData))]
        public void TestGetNode(ISinglyLinkedList<string> list, int index, string value, bool throws)
        {
            if (throws)
            {
                Exception ex = Assert.Throws<Exception>(() => list.GetNode(index));
                Assert.Equal(ex.Message, "Outside bounds of list");
            }
            else
            {
                Assert.Equal(value, list.GetNode(index).Data);
            }
        }

        [Theory, MemberData(nameof(PopTestData))]
        public void TestPopHead(ISinglyLinkedList<string> list, int count, string[] values)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(list.PopHead(), values[i]);
            }

            Exception ex = Assert.Throws<Exception>(() => list.PopHead());
            Assert.Equal(ex.Message, "List is empty");
        }

        [Theory, MemberData(nameof(PopTestData))]
        public void TestPopTail(ISinglyLinkedList<string> list, int count, string[] values)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(list.PopTail(), values[count - (i + 1)]);
            }

            Exception ex = Assert.Throws<Exception>(() => list.PopTail());
            Assert.Equal(ex.Message, "List is empty");
        }
    }
}
