using System;
using System.Collections.Generic;

namespace DotNetCoreTest.BinaryTree
{
    public interface IBinaryTree<T>
    {
        T Value { get; set; }

        IBinaryTree<T> Left { get; set; }

        IBinaryTree<T> Right { get; set; }

        void AddLeft(T data);

        void AddRight(T data);

        List<T> Recurse();

        List<T> Recurse(List<T> list);
    }
}