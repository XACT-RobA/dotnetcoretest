using System;

namespace CircularLinkedList
{
    public class CustomNode<T>
    {
        public CustomNode(T data, CustomNode<T> next, CustomNode<T> prev)
        {
            this.Data = data;

            this.Next = next;

            this.Prev = prev;

            this.UID = CustomIdentifier.GetUID();
        }

        public CustomNode<T> Next { get; set; }

        public CustomNode<T> Prev { get; set; }

        public T Data { get; set; }

        public long UID { get; set; }
    }
}