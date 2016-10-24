using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedList.Interfaces
{
    public interface ICustomLinkedList<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }

        int Count { get; }

        T[] ToArray();

        CustomNode<T>[] GetNodeArray();

        T Get(int index);

        CustomNode<T> GetNode(int index);

        void Add(T data);

        void Append(T data);

        void Insert(T data, int index);

        void Remove(T data);

        void RemoveByUID(long uid);

        void RemoveAt(int index);
    }
}