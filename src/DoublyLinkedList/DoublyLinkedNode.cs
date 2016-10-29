using System;

namespace DotNetCoreTest.DoublyLinkedList
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode(T data, DoublyLinkedNode<T> next, DoublyLinkedNode<T> prev)
        {
            this.Data = data;

            this.Next = next;

            this.Prev = prev;

            this.UID = DotNetCoreTest.Common.Identifier.GetUID();
        }

        public DoublyLinkedNode<T> Next { get; set; }

        public DoublyLinkedNode<T> Prev { get; set; }

        public T Data { get; set; }

        public long UID { get; set; }
    }
}
