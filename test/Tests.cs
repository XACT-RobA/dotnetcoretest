using System;
using Xunit;
using DotNetCoreTest.SinglyLinkedList;

namespace Tests
{
    public class TestSinglyLinkedList
    {
        private static ISinglyLinkedList<string> ListEmpty
        {
            get { return new SinglyLinkedList<string>(); }
        }

        private static ISinglyLinkedList<string> ListOneElement
        {
            get
            {
                var list = new SinglyLinkedList<string>();
                list.Add("Rob");

                return list;
            }
        }

        [Fact]
        public void TestZeroCount()
        {
            Assert.Equal(ListEmpty.Count, 0);
        }

        [Fact]
        public void TestOneCount()
        {
            Assert.Equal(ListOneElement.Count, 1);
        }

        [Fact]
        public void TestIsEmpty()
        {
            Assert.True(ListEmpty.IsEmpty);
        }

        [Fact]
        public void TestNotIsEmpty()
        {
            Assert.False(ListOneElement.IsEmpty);
        }

        [Fact]
        public void TestHasNodes()
        {
            Assert.True(ListOneElement.HasNodes);
        }

        [Fact]
        public void TestNotHasNodes()
        {            
            Assert.False(ListEmpty.HasNodes);
        }
    }
}
