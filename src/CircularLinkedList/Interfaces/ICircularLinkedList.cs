using System.Collections.Generic;
using DotNetCoreTest.DoublyLinkedList;

namespace DotNetCoreTest.CircularLinkedList.Interfaces
{
    public interface ICircularLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        bool HasNodes { get; }

        bool IsEmpty { get; }

        T[] ToArray();

        DoublyLinkedNode<T>[] GetNodeArray();
        
        T Next();
        
        T Prev();

        T Pop();

        void Add(T data);

        void Append(T data);

        void Remove(T data);

        void RemoveByUID(long uid);

        void Reverse();
    }
}
