using System;
using System.Collections;
using System.Collections.Generic;
using DoublyLinkedList.Interfaces;

namespace DoublyLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>, ICustomLinkedList<T>
    {
        private CustomNode<T> head;

        private CustomNode<T> tail;

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

        public bool HasNodes
        {
            get
            {
                return !IsEmpty;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return head == null;
            }
        }

        private bool AreEqual(T first, T second)
        {
            if (first == null) return second == null;

            return first.Equals(second);
        }

        public void Recount()
        {
            this.recount = false;

            var runningTotal = 0;
            var node = this.head;

            while(node != null)
            {
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

                CustomNode<T> node;

                if (index <= this.Count/2)
                {
                    node = this.head;

                    for (int i = 0; i < index; i++)
                    {
                        node = node.Next;
                    }
                }
                else
                {
                    node = this.tail;

                    for (int i = this.Count - 1; i > index; i--)
                    {
                        node = node.Prev;
                    }
                }

                return node.Data;
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new Exception("Outside bounds of list");
                }

                CustomNode<T> node;

                if (index <= this.Count/2)
                {
                    node = this.head;

                    for (int i = 0; i < index; i++)
                    {
                        node = node.Next;
                    }
                }
                else
                {
                    node = this.tail;

                    for (int i = this.Count - 1; i > index; i--)
                    {
                        node = node.Prev;
                    }
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

        public T Get(int index)
        {
            return GetNode(index).Data;
        }

        public CustomNode<T> GetNode(int index)
        {
            if (index >= this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            CustomNode<T> node;

            if (index <= this.Count/2)
            {
                node = this.head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
            }
            else
            {
                node = this.tail;

                for (int i = this.Count - 1; i > index; i--)
                {
                    node = node.Prev;
                }
            }

            return node;
        }

        public T PopHead()
        {
            if (IsEmpty) return default(T);

            this.recount = true;

            var node = this.head;

            this.head = this.head.Next;

            this.head.Prev = null;

            return node.Data;
        }

        public T PopTail()
        {
            if (IsEmpty) return default(T);

            this.recount = true;

            var node = this.tail;

            this.tail = this.tail.Prev;

            this.tail.Next = null;

            return node.Data;
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

            var node = new CustomNode<T>(data, this.head, null);

            if (!IsEmpty) this.head.Prev = node;
            else this.tail = node;

            this.head = node;
        }

        public void Append(T data)
        {
            this.recount = true;

            var node = new CustomNode<T>(data, null, this.tail);

            if (!IsEmpty) this.tail.Next = node;
            else this.head = node;

            this.tail = node;
        }

        public void Insert(T data, int index)
        {
            if (index > this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            if (index == 0)
            {
                this.Add(data);
                return;
            }
            if (index == this.Count)
            {
                this.Append(data);
                return;
            }

            this.recount = true;

            CustomNode<T> node;

            if (index <= this.Count - 1)
            {
                node = this.head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
            }
            else
            {
                node = this.tail;

                for (int i = this.Count - 1; i > index; i--)
                {
                    node = node.Prev;
                }
            }

            var prev = node.Prev;
            var newNode = new CustomNode<T>(data, node, prev);

            node.Prev = newNode;
            prev.Next = newNode;
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }

        public void RemoveByUID(long uid)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}