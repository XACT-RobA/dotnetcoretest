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

        public static IEnumerable<object[]> AddTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 1, "Eve" },
                    new object[] { ListOneElement, 2, "Eve" },
                    new object[] { ListTwoElements, 3, "Eve" },
                    new object[] { ListThreeElementsWithRepeat, 4, "Eve" },
                };
            }
        }

        public static IEnumerable<object[]> InsertTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 1, 0, "Bob", false },
                    new object[] { ListEmpty, 0, 1, "Bob", true },
                    new object[] { ListOneElement, 2, 0, "Alice", false },
                    new object[] { ListOneElement, 2, 1, "Alice", false },
                    new object[] { ListOneElement, 1, 2, "Alice", true },
                    new object[] { ListTwoElements, 3, 0, "Eve", false },
                    new object[] { ListTwoElements, 3, 1, "Eve", false },
                    new object[] { ListTwoElements, 3, 2, "Eve", false },
                    new object[] { ListTwoElements, 2, 3, "Eve", true },
                    new object[] { ListThreeElementsWithRepeat, 4, 0, "Eve", false },
                    new object[] { ListThreeElementsWithRepeat, 4, 1, "Eve", false },
                    new object[] { ListThreeElementsWithRepeat, 4, 2, "Eve", false },
                    new object[] { ListThreeElementsWithRepeat, 4, 3, "Eve", false },
                    new object[] { ListThreeElementsWithRepeat, 3, 4, "Eve", true },
                };
            }
        }

        public static IEnumerable<object[]> RemoveTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0, "Bob" },
                    new object[] { ListOneElement, 0, "Bob" },
                    new object[] { ListOneElement, 1, "Alice" },
                    new object[] { ListTwoElements, 1, "Bob" },
                    new object[] { ListTwoElements, 1, "Alice" },
                    new object[] { ListTwoElements, 2, "Eve" },
                    new object[] { ListThreeElementsWithRepeat, 1, "Bob" },
                    new object[] { ListThreeElementsWithRepeat, 2, "Alice" },
                    new object[] { ListThreeElementsWithRepeat, 3, "Eve" },
                };
            }
        }

        public static IEnumerable<object[]> RemoveByUIDTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListOneElement, 0, "Bob" },
                    new object[] { ListTwoElements, 1, "Bob" },
                    new object[] { ListTwoElements, 1, "Alice" },
                    new object[] { ListThreeElementsWithRepeat, 2, "Bob" },
                    new object[] { ListThreeElementsWithRepeat, 2, "Alice" },
                };
            }
        }

        public static IEnumerable<object[]> RemoveAtTestData
        {
            get
            {
                return new []
                {
                    new object[] { ListEmpty, 0, 0, true },
                    new object[] { ListOneElement, 0, 0, false },
                    new object[] { ListOneElement, 1, 0, true },
                    new object[] { ListTwoElements, 0, 1, false },
                    new object[] { ListTwoElements, 1, 1, false },
                    new object[] { ListTwoElements, 2, 0, true },
                    new object[] { ListThreeElementsWithRepeat, 0, 2, false },
                    new object[] { ListThreeElementsWithRepeat, 1, 2, false },
                    new object[] { ListThreeElementsWithRepeat, 2, 2, false },
                    new object[] { ListThreeElementsWithRepeat, 3, 0, true },
                };
            }
        }

        public static IEnumerable<object[]> ReverseTestData
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

        [Theory, MemberData(nameof(ArrayIndexTestData))]
        public void TestArrayIndex(IDoublyLinkedList<string> list, int index, string value, bool throws)
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
        public void TestToArray(IDoublyLinkedList<string> list, int length, string[] arr)
        {
            var value = list.ToArray();

            Assert.Equal(length, value.Length);

            for (int i = 0; i < length; i++)
            {
                Assert.Equal(arr[i], value[i]);
            }
        }

        [Theory, MemberData(nameof(ArrayTestData))]
        public void TestGetNodeArray(IDoublyLinkedList<string> list, int length, string[] arr)
        {
            var value = list.GetNodeArray();

            Assert.Equal(length, value.Length);

            for (int i = 0; i < length; i++)
            {
                Assert.Equal(arr[i], value[i].Data);
            }
        }

        [Theory, MemberData(nameof(ArrayIndexTestData))]
        public void TestGet(IDoublyLinkedList<string> list, int index, string value, bool throws)
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
        public void TestGetNode(IDoublyLinkedList<string> list, int index, string value, bool throws)
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
        public void TestPopHead(IDoublyLinkedList<string> list, int count, string[] values)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(list.PopHead(), values[i]);
            }

            Exception ex = Assert.Throws<Exception>(() => list.PopHead());
            Assert.Equal(ex.Message, "List is empty");
        }

        [Theory, MemberData(nameof(PopTestData))]
        public void TestPopTail(IDoublyLinkedList<string> list, int count, string[] values)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(list.PopTail(), values[count - (i + 1)]);
            }

            Exception ex = Assert.Throws<Exception>(() => list.PopTail());
            Assert.Equal(ex.Message, "List is empty");
        }

        [Theory, MemberData(nameof(FindTestData))]
        public void TestFind(IDoublyLinkedList<string> list, int index, string value)
        {
            Assert.Equal(index, list.Find(value));
        }

        [Theory, MemberData(nameof(FindAllTestData))]
        public void TestFindAll(IDoublyLinkedList<string> list, int[] indexes, string value)
        {
            var arr = list.FindAll(value);

            Assert.Equal(arr.Length, indexes.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.Equal(indexes[i], arr[i]);
            }
        }

        [Theory, MemberData(nameof(AddTestData))]
        public void TestAdd(IDoublyLinkedList<string> list, int newLength, string value)
        {
            list.Add(value);

            Assert.Equal(newLength, list.Count);

            Assert.Equal(value, list[0]);

            Assert.Equal(value, list.PopHead());
        }

        [Theory, MemberData(nameof(AddTestData))]
        public void TestAppend(IDoublyLinkedList<string> list, int newLength, string value)
        {
            list.Append(value);

            Assert.Equal(newLength, list.Count);

            Assert.Equal(value, list[newLength-1]);

            Assert.Equal(value, list.PopTail());
        }

        [Theory, MemberData(nameof(InsertTestData))]
        public void TestInsert(IDoublyLinkedList<string> list, int newLength, int position, string value, bool throws)
        {
            if (throws)
            {
                Exception ex = Assert.Throws<Exception>(() => list.Insert(value, position));
                Assert.Equal(ex.Message, "Outside bounds of list");

                Assert.Equal(newLength, list.Count);
            }
            else
            {
                list.Insert(value, position);

                Assert.Equal(newLength, list.Count);

                Assert.Equal(value, list[position]);
            }
        }

        [Theory, MemberData(nameof(RemoveTestData))]
        public void TestRemove(IDoublyLinkedList<string> list, int newLength, string value)
        {
            list.Remove(value);

            Assert.Equal(newLength, list.Count);

            foreach (var item in list)
            {
                Assert.NotEqual(item, value);
            }
        }

        [Theory, MemberData(nameof(RemoveByUIDTestData))]
        public void TestRemoveByUID(IDoublyLinkedList<string> list, int newLength, string value)
        {
            var uid = list.GetNode(list.Find(value)).UID;

            list.RemoveByUID(uid);

            Assert.Equal(newLength, list.Count);

            list.RemoveByUID(uid);

            Assert.Equal(newLength, list.Count);
        }

        [Theory, MemberData(nameof(RemoveAtTestData))]
        public void TestRemoveAt(IDoublyLinkedList<string> list, int index, int newLength, bool throws)
        {
            if (throws)
            {
                Exception ex = Assert.Throws<Exception>(() => list.RemoveAt(index));
                Assert.Equal(ex.Message, "Outside bounds of list");
            }
            else
            {
                list.RemoveAt(index);

                Assert.Equal(newLength, list.Count);
            }
        }

        [Theory, MemberData(nameof(ReverseTestData))]
        public void TestReverse(IDoublyLinkedList<string> list, int length)
        {
            Assert.Equal(length, list.Count);

            var preNodeArray = list.GetNodeArray();

            list.Reverse();

            var postNodeArray = list.GetNodeArray();

            Assert.Equal(preNodeArray.Length, postNodeArray.Length);

            for (int i = 0; i < length; i++)
            {
                Assert.Equal(preNodeArray[i].UID, postNodeArray[length-(i+1)].UID);
            }
        }
    }
}