using System;
using DotNetCoreTest.CircularLinkedList;

namespace DotNetCoreTest.StackAndQueue
{
    public class Stack<T> : IStack<T>
    {
        public Stack()
        {
            list = new CircularLinkedList<T>();
        }

        private ICircularLinkedList<T> list;

        public void Push(T data)
        {
            list.Add(data);
        }

        public T Pop()
        {
            return list.Pop();
        }

        public T Peek()
        {
            return list.Peek();
        }

        public bool IsEmpty
        {
            get
            {
                return list.IsEmpty;
            }
        }
    }
}