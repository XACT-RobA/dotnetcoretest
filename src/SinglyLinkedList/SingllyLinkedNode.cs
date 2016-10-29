using System;

namespace DotNetCoreTest.SinglyLinkedList
{
    public class SinglyLinkedNode<T>
    {
        public SinglyLinkedNode(T data, SinglyLinkedNode<T> next)
        {
            this.Data = data;

            this.Next = next;

            this.UID = DotNetCoreTest.Common.Identifier.GetUID();
        }

        public SinglyLinkedNode<T> Next { get; set; }

        public T Data { get; set; }

        public long UID { get; set; }
    }
}
