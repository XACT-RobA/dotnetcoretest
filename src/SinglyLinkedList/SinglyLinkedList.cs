using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetCoreTest.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>, ISinglyLinkedList<T>
    {
        private SinglyLinkedNode<T> head;

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

            while (node != null)
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

        public SinglyLinkedNode<T>[] GetNodeArray()
        {
            var array = new SinglyLinkedNode<T>[this.Count];

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

        public SinglyLinkedNode<T> GetNode(int index)
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

        public T PopHead()
        {
            if (IsEmpty) throw new Exception("List is empty");

            this.recount = true;

            var node = this.head;

            this.head = this.head.Next;

            return node.Data;
        }

        public T PopTail()
        {
            if (IsEmpty) throw new Exception("List is empty");

            this.recount = true;

            if (this.head.Next == null)
            {
                var headData = this.head.Data;
                this.head = null;
                return headData;
            }

            var node = this.head;

            while(node.Next.Next != null)
            {
                node = node.Next;
            }

            var data = node.Next.Data;
            node.Next = null;
            return data;
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

            var node = new SinglyLinkedNode<T>(data, this.head);

            this.head = node;
        }

        public void Append(T data)
        {
            this.recount = true;

            var newNode = new SinglyLinkedNode<T>(data, null);

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

            var newNode = new SinglyLinkedNode<T>(data, node.Next);

            node.Next = newNode;
        }

        public void Remove(T data)
        {
            if (this.IsEmpty) return;

            this.recount = true;
            
            while(this.head != null)
            {
                if (this.AreEqual(head.Data, data))
                {
                    this.head = this.head.Next;
                }
                else break;
            }

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
            if (this.IsEmpty) return;

            this.recount = true;

            var node = this.head;
            SinglyLinkedNode<T> prev = this.head;

            while(node != null)
            {
                if (node.UID.Equals(uid))
                {
                    if (node == this.head)
                    {
                        this.head = this.head.Next;
                        return;
                    }

                    prev.Next = node.Next;
                    return;
                }

                prev = node;
                node = node.Next;
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

        public void Reverse()
        {
            if (this.IsEmpty) return;

            SinglyLinkedNode<T> prev = null;
            var node = this.head;
            SinglyLinkedNode<T> next = null;

            while(node != null)
            {
                next = node.Next;
                node.Next = prev;
                prev = node;
                node = next;
            }

            this.head = prev;
        }
    }
}
