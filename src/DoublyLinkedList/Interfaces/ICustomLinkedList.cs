using System.Collections.Generic;

namespace DotNetCoreTest.DoublyLinkedList.Interfaces
{
    public interface IDoublyLinkedList<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }

        int Count { get; }

        bool HasNodes { get; }

        bool IsEmpty { get; }

        T[] ToArray();

        DoublyLinkedNode<T>[] GetNodeArray();

        T Get(int index);

        DoublyLinkedNode<T> GetNode(int index);

        T PopHead();

        T PopTail();

        int Find(T data);

        int[] FindAll(T data);

        void Add(T data);

        void Append(T data);

        void Insert(T data, int index);

        void Remove(T data);

        void RemoveByUID(long uid);

        void RemoveAt(int index);

        void Reverse();
    }
}
