using System;
using System.Collections;
using System.Collections.Generic;
using SinglyLinkedList.Interfaces;

namespace SinglyLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>, ICustomLinkedList<T>
    {
        private CustomNode<T> head;

        private bool recount;

        private int count;

        public int Count
        {
            get
            {
                if (this.recount) this.Recount();
                return this.count;
            }
        }

        private bool AreEqual(T first, T second)
        {
            if (first == null) return second == null;

            return first.Equals(second);
        }

        private void Recount()
        {
            this.recount = false;

            var runningTotal = 0;
            var node = this.head;

            while (node != null)
            {
                if (this.head.Equals(node.Next))
                {
                    runningTotal++;
                    break;
                }

                node = node.Next;
                runningTotal++;
            }

            this.count = runningTotal;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while(node != null)
            {
                yield return node.Data;

                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new Exception("Outside bounds of list");
                }

                var node = this.head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node.Data;
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new Exception("Outside bounds of list");
                }

                var node = this.head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                node.Data = value;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            var node = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = node.Data;
                node = node.Next;
            }

            return array;
        }

        public CustomNode<T>[] GetNodeArray()
        {
            var array = new CustomNode<T>[this.Count];

            var node = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = node;
                node = node.Next;
            }

            return array;
        }

        public CustomNode<T> GetNode(int index)
        {
            if (index >= this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            var node = this.head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public T Get(int index)
        {
            return GetNode(index).Data;
        }

        public int Find(T data)
        {
            var node = this.head;
            var counter = 0;

            while(node != null)
            {
                if (AreEqual(data, node.Data)) return counter;

                node = node.Next;
                counter++;
            }

            return -1;
        }

        public int[] FindAll(T data)
        {
            var list = new List<int>();

            var node = this.head;
            var counter = 0;

            while(node != null)
            {
                if (AreEqual(data, node.Data)) list.Add(counter);

                node = node.Next;
                counter++;
            }

            return list.ToArray();
        }
        
        public void Add(T data)
        {
            this.recount = true;

            var node = new CustomNode<T>(data, this.head);

            this.head = node;
        }

        public void Append(T data)
        {
            this.recount = true;

            var newNode = new CustomNode<T>(data, null);

            if (this.head == null)
            {
                this.head = newNode;;
                return;
            }

            var node = this.head;

            while(node != null)
            {
                if (node.Next == null)
                {
                    node.Next = newNode;
                    return;
                }

                node = node.Next;
            }
        }

        public void Insert(T data, int index)
        {
            if (index > this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            if(index == 0)
            {
                 this.Add(data);
                 return;
            }

            this.recount = true;

            var node = this.head;

            for (int i = 0; i < index - 1; i++)
            {
                node = node.Next;
            }

            var newNode = new CustomNode<T>(data, node.Next);

            node.Next = newNode;
        }

        public void Remove(T data)
        {
            if (this.head == null) return;

            this.recount = true;

            if (this.head.Data.Equals(data)) this.head = this.head.Next;

            var node = this.head;

            while(node != null)
            {
                if (node.Next != null && AreEqual(node.Next.Data, data))
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        public void RemoveByUID(long uid)
        {
            if (this.head == null) return;

            this.recount = true;

            if (this.head.UID.Equals(uid))
            {
                this.head = this.head.Next;
                return;
            }

            var node = this.head;

            while(node != null)
            {
                var next = node.Next;

                if (next.UID.Equals(uid))
                {
                    node.Next = next.Next;
                    return;
                }

                node = next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            this.recount = true;

            if (index == 0)
            {
                this.head = this.head.Next;
                return;
            }

            var node = this.head;

            for (int i = 0; i < index; i++)
            {
                if (i + 1 == index)
                {
                    node.Next = node.Next.Next;
                    return;
                }

                node = node.Next;
            }
        }
    }
}