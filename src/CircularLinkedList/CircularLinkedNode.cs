using System;

namespace DotNetCoreTest.CircularLinkedList
{
    public class CircularLinkedNode<T>
    {
        public CircularLinkedNode(T data, CircularLinkedNode<T> next, CircularLinkedNode<T> prev)
        {
            this.Data = data;

            this.Next = next;

            this.Prev = prev;

            this.UID = DotNetCoreTest.Common.Identifier.GetUID();
        }

        public CircularLinkedNode<T> Next { get; set; }

        public CircularLinkedNode<T> Prev { get; set; }

        public T Data { get; set; }

        public long UID { get; set; }
    }
}
