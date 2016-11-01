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
                var list = new SinglyLinkedList<string>();
                return list;
            }
        }

        private static ISinglyLinkedList<string> ListOneElement
        {
            get
            {
                var list = new SinglyLinkedList<string>();
                list.Add("Bob");
                return list;
            }
        }

        private static ISinglyLinkedList<string> ListTwoElements
        {
            get
            {
                var list = new SinglyLinkedList<string>();
                list.Add("Bob");
                list.Add("Alice");
                return list;
            }
        }

        private static ISinglyLinkedList<string> ListThreeElementsWithRepeat
        {
            get
            {
                var list = new SinglyLinkedList<string>();
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

        public static IEnumerable<object[]> ArrayIndexTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0, null, true },
                    new object[] { ListOneElement, 0, "Bob", false },
                    new object[] { ListOneElement, 1, null, true },
                    new object[] { ListTwoElements, 0, "Alice", false},
                    new object[] { ListTwoElements, 1, "Bob", false},
                    new object[] { ListTwoElements, 2, null, true},
                    new object[] { ListThreeElementsWithRepeat, 0, "Bob", false },
                    new object[] { ListThreeElementsWithRepeat, 1, "Alice", false },
                    new object[] { ListThreeElementsWithRepeat, 2, "Bob", false },
                    new object[] { ListThreeElementsWithRepeat, 3, null, true },
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
                    new object[] { ListOneElement, 1, new string[] {"Bob"} },
                    new object[] { ListTwoElements, 2, new string[] {"Alice", "Bob"} },
                    new object[] { ListThreeElementsWithRepeat, 3, new string[] {"Bob", "Alice", "Bob"} },
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

        public static IEnumerable<object[]> FindTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, -1, "Bob" },
                    new object[] { ListOneElement, 0, "Bob" },
                    new object[] { ListOneElement, -1, "Alice" },
                    new object[] { ListTwoElements, 0, "Alice" },
                    new object[] { ListTwoElements, 1, "Bob" },
                    new object[] { ListTwoElements, -1, "Eve" },
                    new object[] { ListThreeElementsWithRepeat, 0, "Bob" },
                    new object[] { ListThreeElementsWithRepeat, 1, "Alice" },
                    new object[] { ListThreeElementsWithRepeat, -1, "Eve" },
                };
            }
        }

        public static IEnumerable<object[]> FindAllTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, new int[0], "Bob" },
                    new object[] { ListOneElement, new int[] {0}, "Bob" },
                    new object[] { ListOneElement, new int[0], "Alice" },
                    new object[] { ListTwoElements, new int[] {0}, "Alice" },
                    new object[] { ListTwoElements, new int[] {1}, "Bob" },
                    new object[] { ListTwoElements, new int[0], "Eve" },
                    new object[] { ListThreeElementsWithRepeat, new int[] {0, 2}, "Bob" },
                    new object[] { ListThreeElementsWithRepeat, new int[] {1}, "Alice" },
                    new object[] { ListThreeElementsWithRepeat, new int[0], "Eve" },
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

        [Theory, MemberData(nameof(IsEmptyTestData))]
        public void TestHasNodes(ISinglyLinkedList<string> list, bool isEmpty)
        {
            Assert.Equal(list.HasNodes, !isEmpty);
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

        [Theory, MemberData(nameof(FindTestData))]
        public void TestFind(ISinglyLinkedList<string> list, int index, string value)
        {
            Assert.Equal(index, list.Find(value));
        }

        [Theory, MemberData(nameof(FindAllTestData))]
        public void TestFindAll(ISinglyLinkedList<string> list, int[] indexes, string value)
        {
            var arr = list.FindAll(value);

            Assert.Equal(arr.Length, indexes.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.Equal(indexes[i], arr[i]);
            }
        }
    }
}
