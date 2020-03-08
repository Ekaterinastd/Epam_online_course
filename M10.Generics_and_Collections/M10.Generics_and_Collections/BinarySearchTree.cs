using System;
using System.Collections;
using System.Collections.Generic;

namespace M10.Generics_and_Collections
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> Head;

        public BinarySearchTree(Func<T, T, int> comparator = null)
        {
            if (comparator == null)
            {
                var interfaceFound = false;
                foreach (var iface in typeof(T).GetInterfaces())
                    if (iface == typeof(IComparable))
                        interfaceFound = true;
                if (!interfaceFound)
                    throw new ArgumentException();
                else
                    comparator = new Func<T, T, int>((t1, t2) => (t1 as IComparable).CompareTo(t2 as IComparable));
            }
            Comparator = comparator;
        }

        public int Count { get; private set; }
        public Func<T, T, int> Comparator { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal() as IEnumerator<T>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Префиксный (прямой) обход дерева
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PreOrderTraversal()
        {
            if (Head != null)
            {
                var stack = new Stack<Node<T>>();
                Node<T> current = Head;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    current = stack.Pop();
                    yield return current.Value;

                    if (current.Right != null)
                        stack.Push(current.Right);
                    if (current.Left != null)
                        stack.Push(current.Left);
                }
            }
        }

        /// <summary>
        /// Симметричный обход дерева
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrderTraversal()
        {
            if (Head != null)
            {
                var stack = new Stack<Node<T>>();
                Node<T> current = Head;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        ///  Постфиксный обход дерева
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrderTraversal()
        {
            var stack = new Stack<Node<T>>();
            Node<T> current = Head;
            if (current == null)
                yield break;
            do
            {
                while (current != null)
                {
                    if (current.Right != null)
                        stack.Push(current.Right);
                    stack.Push(current);
                    current = current.Left;
                }
                current = stack.Pop();
                if (current.Right != null && !stack.IsEmpty && stack.Peek() == current.Right)//идём в правое поддерево корня
                {
                    stack.Pop();//снимаем со стека правого ребёнка текущего узла
                    stack.Push(current);
                    current = current.Right;
                }
                else
                {
                    yield return current.Value;
                    current = null;
                }
            } while (!stack.IsEmpty);
        }

        /// <summary>
        /// Добавление нового узла с заданным значением в дерево
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        public void Add(T value)
        {
            if (Head == null)
                Head = new Node<T>(value);
            else AddTo(Head, value);
            Count++;
        }

        /// <summary>
        /// Удаление всех узлов дерева
        /// </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Проверка, содержит ли дерево узел с заданным значением
        /// </summary>
        /// <param name="value">Значение узла</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return FindNode(value, out Node<T> parent) != null;
        }

        /// <summary>
        /// Удаление элемента с заданным значением из дерева
        /// </summary>
        /// <param name="value">Удаляемое значение</param>
        public void Remove(T value)
        {
            Node<T> current;
            current = FindNode(value, out Node<T> parent);
            if (current == null)
                throw new KeyNotFoundException("Value doesn't exist in the tree");

            Count--;
            if (current.Right == null)//Если нет детей справа, левый ребенок встает на место удаляемого.
            {
                if (parent == null)
                    Head = current.Left;
                else
                {
                    var result = Comparator(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else if (result > 0)
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)//Если у правого ребенка нет детей слева, то он занимает место удаляемого узла.
            {
                if (parent == null)
                    Head = current.Right;
                else
                {
                    var leftChaild = current.Left;
                    var result = Comparator(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else if (result > 0)
                        parent.Right = current.Right;
                    Add(leftChaild.Value);
                }
            }
            else //Если у правого ребенка есть дети слева, крайний левый ребенок из правого поддерева заменяет удаляемый узел.
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                    Head = leftmost;
                else
                {
                    int result = Comparator(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = leftmost;
                    else if (result < 0)
                        parent.Right = leftmost;
                }
            }
        }

        /// <summary>
        /// Поиск узла с заданным значением
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="parent">Родитель искомого узла</param>
        /// <returns>Узел</returns>
        private Node<T> FindNode(T value, out Node<T> parent)
        {
            Node<T> current = Head;
            parent = null;
            while (current != null)
            {
                if (Comparator(value, current.Value) < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (Comparator(value, current.Value) > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                    break;
            }
            if (current!= null && current.Value.Equals(value))
                return current;
            return null;
        }

        /// <summary>
        /// Поиск места для вставки нового узла
        /// </summary>
        /// <param name="node">Текущий узел</param>
        /// <param name="value">Значение для вставки</param>
        private void AddTo(Node<T> node, T value)
        {
            if (Comparator(value, node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node<T>(value);
                else AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node<T>(value);
                else AddTo(node.Right, value);
            }
        }
    }

    /// <summary>
    /// Узел дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
