using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetCoreTest.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>, IDoublyLinkedList<T>
    {
        private DoublyLinkedNode<T> head;

        private DoublyLinkedNode<T> tail;

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

        private void Recount()
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
                if (index >= this.Count || index < 0)
                {
                    throw new Exception("Outside bounds of list");
                }

                DoublyLinkedNode<T> node;

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
                if (index >= this.Count || index < 0)
                {
                    throw new Exception("Outside bounds of list");
                }

                DoublyLinkedNode<T> node;

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

        public DoublyLinkedNode<T>[] GetNodeArray()
        {
            var array = new DoublyLinkedNode<T>[this.Count];

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

        public DoublyLinkedNode<T> GetNode(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new Exception("Outside bounds of list");
            }

            DoublyLinkedNode<T> node;

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
            if (IsEmpty) throw new Exception("List is empty");

            this.recount = true;

            var node = this.head;

            this.head = this.head.Next;

            if (this.head != null)
            {
                this.head.Prev = null;
            }
            else
            {
                this.tail = null;
            }

            return node.Data;
        }

        public T PopTail()
        {
            if (IsEmpty) throw new Exception("List is empty");

            this.recount = true;

            var node = this.tail;

            this.tail = this.tail.Prev;

            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

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

            var node = new DoublyLinkedNode<T>(data, this.head, null);

            if (!IsEmpty) this.head.Prev = node;
            else this.tail = node;

            this.head = node;
        }

        public void Append(T data)
        {
            this.recount = true;

            var node = new DoublyLinkedNode<T>(data, null, this.tail);

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

            DoublyLinkedNode<T> node;

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

            var prev = node.Prev;
            var newNode = new DoublyLinkedNode<T>(data, node, prev);

            node.Prev = newNode;
            prev.Next = newNode;

            this.recount = true;
        }

        public void Remove(T data)
        {
            if (this.IsEmpty) return;

            this.recount = true;

            var node = this.head;

            while(node != null)
            {
                if (AreEqual(node.Data, data))
                {
                    if (node.Prev == null) this.PopHead();
                    else if (node.Next == null) this.PopTail();
                    else
                    {
                        node.Prev.Next = node.Next;
                        node.Next.Prev = node.Prev;
                    }
                }

                node = node.Next;
            }
        }

        public void RemoveByUID(long uid)
        {
            if (this.IsEmpty) return;

            this.recount = true;

            var node = this.head;

            while(node != null)
            {
                if (node.UID.Equals(uid))
                {
                    if (node.Prev == null) this.PopHead();
                    else if (node.Next == null) this.PopTail();
                    else
                    {
                        node.Prev.Next = node.Next;
                        node.Next.Prev = node.Prev;
                    }
                    return;
                }

                node = node.Next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new Exception("Outside bounds of list");
            }

            if (index == 0)
            {
                this.PopHead();
                return;
            }
            else if (index == this.Count-1)
            {
                this.PopTail();
                return;
            }

            DoublyLinkedNode<T> node;

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

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            this.recount = true;
        }

        public void Reverse()
        {
            if (IsEmpty) return;

            var node = this.head;

            while (node != null)
            {
                var next = node.Next;

                node.Next = node.Prev;
                node.Prev = next;

                node = next;
            }

            var temp = this.head;
            this.head = this.tail;
            this.tail = temp;
        }
    }
}
