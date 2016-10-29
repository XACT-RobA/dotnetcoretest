using System.Collections.Generic;

namespace DotNetCoreTest.CircularLinkedList.Interfaces
{
    public interface ICircularLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        bool HasNodes { get; }

        bool IsEmpty { get; }

        T[] ToArray();

        CircularLinkedNode<T>[] GetNodeArray();
        
        T Next();
        
        T Prev();

        T Pop();

        void Add(T data);

        void Remove(T data);

        void RemoveByUID(long uid);

        void Reverse();
    }
}
