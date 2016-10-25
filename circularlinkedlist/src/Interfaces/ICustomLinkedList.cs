using System.Collections.Generic;

namespace CircularLinkedList.Interfaces
{
    public interface ICustomLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        bool HasNodes { get; }

        bool IsEmpty { get; }

        T[] ToArray();

        CustomNode<T>[] GetNodeArray();

        T Pop();

        void Add(T data);

        void Remove(T data);

        void RemoveByUID(long uid);

        void Reverse();
    }
}