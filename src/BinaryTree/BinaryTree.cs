using System;
using System.Collections.Generic;

namespace DotNetCoreTest.BinaryTree
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryTree(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public IBinaryTree<T> Left { get; set; }

        public IBinaryTree<T> Right { get; set; }

        public void AddLeft(T data)
        {
            Left = new BinaryTree<T>(data);
        }

        public void AddRight(T data)
        {   
            Right = new BinaryTree<T>(data);
        }

        public List<T> Recurse()
        {
            var list = new List<T>();

            return Recurse(list);
        }

        public List<T> Recurse(List<T> list)
        {
            if (Left != null) Left.Recurse(list);

            list.Add(Value);

            if (Right != null) Right.Recurse(list);

            return list;
        }
    }
}