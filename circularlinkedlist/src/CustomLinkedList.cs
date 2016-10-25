using System;
using System.Collections;
using System.Collections.Generic;
using CircularLinkedList.Interfaces;

namespace CircularLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>, ICustomLinkedList<T>
    {
        private CustomNode<T> current;

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
                return current == null;
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

            var startUID = this.current.UID;
            bool hasLooped = false;

            while(!hasLooped)
            {
                runningTotal++;

                this.current = this.current.Next;
                hasLooped = startUID == this.current.UID;
            }

            this.count = runningTotal;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var startUID = this.current.UID;
            bool hasLooped = false;

            while(!hasLooped)
            {
                yield return this.current.Data;

                this.current = this.current.Next;
                hasLooped = startUID == this.current.UID;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.current.Data;
                this.current = this.current.Next;
            }

            return array;
        }

        public CustomNode<T>[] GetNodeArray()
        {
            var array = new CustomNode<T>[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.current;
                this.current = this.current.Next;
            }

            return array;
        }

        public T Pop()
        {
            if (IsEmpty) return default(T);

            this.recount = true;

            var data = this.current.Data;

            if (this.Count > 1)
            {
                this.current.Next.Prev = this.current.Prev;
                this.current.Prev.Next = this.current.Next;
            }

            this.current = this.current.Next;

            return data;
        }

        public void Add(T data)
        {
            this.recount = true;

            CustomNode<T> node;

            if (IsEmpty)
            {
                node = new CustomNode<T>(data, null, null);

                node.Next = node;
                node.Prev = node;
            }
            else
            {
                node = new CustomNode<T>(data, this.current, this.current.Prev);

                this.current.Prev.Next = node;
                this.current.Prev = node;
            }

            this.current = node;
        }

        public void Remove(T data)
        {
            if (this.IsEmpty) return;

            this.recount = true;

            var startUID = this.current.UID;
            bool startPopped = false;
            bool hasLooped = false;

            while(!hasLooped)
            {
                if (AreEqual(this.current.Data, data))
                {
                    startPopped = startUID == this.current.UID;

                    this.Pop();
                }

                hasLooped = startUID == this.current.UID;

                if (startPopped) startUID = this.current.UID;
            }
        }

        public void RemoveByUID(long uid)
        {
            if (this.IsEmpty) return;

            this.recount = true;

            var startUID = this.current.UID;
            bool hasLooped = false;

            while(!hasLooped)
            {
                if (this.current.UID.Equals(uid))
                {
                    Pop();
                    return;
                }

                this.current = this.current.Next;
                hasLooped = startUID == this.current.UID;
            }
        }

        public void Reverse()
        {
            if (IsEmpty) return;

            var startUID = this.current.UID;
            bool hasLooped = false;

            while (!hasLooped)
            {
                var next = this.current.Next;

                this.current.Next = this.current.Prev;
                this.current.Prev = next;

                this.current = next;
                hasLooped = startUID == this.current.UID;
            }
        }
    }
}