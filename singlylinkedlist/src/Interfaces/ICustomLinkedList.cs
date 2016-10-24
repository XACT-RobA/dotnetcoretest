using System;

namespace SinglyLinkedList.Interfaces
{
    public interface ICustomLinkedList<T>
    {
        int Count { get; }

        CustomNode<T>[] ToArray();

        T[] GetDataArray();

        CustomNode<T> Get(int index);

        T GetData(int index);

        void Add(T data);

        void Append(T data);

        void Insert(T data, int index);

        void Remove(T data);

        void RemoveByUID(long uid);

        void RemoveAt(int index);
    }
}