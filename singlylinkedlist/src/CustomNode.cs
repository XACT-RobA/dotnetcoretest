using System;

namespace SinglyLinkedList
{
    public class CustomNode<T>
    {
        public CustomNode(T data, CustomNode<T> next)
        {
            this.Data = data;

            this.Next = next;

            UID = CustomIdentifier.GetUID();
        }

        public CustomNode<T> Next { get; set; }

        public T Data { get; set; }

        public long UID { get; set; }
    }
}