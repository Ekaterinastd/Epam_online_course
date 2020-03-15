using System;
using System.Collections;
using System.Collections.Generic;

namespace M11.LINQ
{
    public class Stack<T> : IEnumerable<T>
    {
        public class StackItem<T>
        {
            public T Value { get; set; }
            public StackItem<T> Next { get; set; }
        }

        public StackItem<T> Head { get; private set; }
        StackItem<T> tail;
        private int _count;
        public int Count { get => _count; private set => _count = value; }
        public bool IsEmpty { get { return Head == null; } }

        /// <summary>
        /// Добавление элемента в стек
        /// </summary>
        /// <param name="value">элемент</param>
        public void Push(T value)
        {
            if (IsEmpty)
                tail = Head = new StackItem<T> { Value = value, Next = null };
            else
            {
                var item = new StackItem<T> { Value = value, Next = Head };
                Head = item;
            }
            Count++;
        }

        /// <summary>
        /// Удаление элемента из стека
        /// </summary>
        /// <returns>очередь без удалённого элемента</returns>
        public T Pop()
        {
            if (Head == null) throw new InvalidOperationException("Stack is empty");
            var result = Head.Value;
            Head = Head.Next;
            Count--;
            if (Head == null)
                tail = null;
            return result;
        }

        public T Peek()
        {
            return Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
