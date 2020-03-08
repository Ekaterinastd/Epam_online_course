using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace M10.Generics_and_Collections
{
    public class BinarySearch
    {
        public static int BinarySearchGeneric<T>(ICollection<T> collection, T element) where T : IComparable
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                if (collection.ElementAt(i).CompareTo(collection.ElementAt(i + 1)) > 0)
                    throw new ArgumentException("Collection must be sorted");
            }
            var left = 0;
            var right = collection.Count - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (collection.ElementAt(middle).CompareTo(element) >= 0)
                    right = middle;
                else left = middle + 1;
            }
            if (collection.ElementAt(right).CompareTo(element) == 0)
                return right;

            return -1;
        }
    }

    public class WordsFrequency
    {
        public static Dictionary<string, double> GetWordsFrequency(string text)
        {
            var words = text.ToLower().Split(new char[] { '.', '?', '!', ',', ':', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
                throw new ArgumentException("String is empty");

            var frequency = new Dictionary<string, double>();

            foreach (var word in words)
            {
                if (!frequency.ContainsKey(word))
                    frequency.Add(word, 1.0 / words.Length);
                else frequency[word] += 1.0 / words.Length;
            }
            return frequency;
        }
    }

    public class ReversePolishNotation
    {
        public static int GetReversePolishNotation(string str)
        {
            var operations = new Dictionary<string, Func<int, int, int>>();
            operations.Add("+", (y, x) => x + y);
            operations.Add("-", (y, x) => x - y);
            operations.Add("*", (y, x) => x * y);
            operations.Add("/", (y, x) => x / y);

            var stack = new Stack<int>();

            var list = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (list.Length == 0)
                return 0;
            var res = 0;
            foreach (var e in list)
            {
                if (int.TryParse(e.ToString(), out res))
                    stack.Push(res);
                else if (operations.ContainsKey(e))
                    stack.Push(operations[e](stack.Pop(), stack.Pop()));
                else throw new ArgumentException("String must contain spaces");
            }
            return stack.Pop();
        }
    }

    public class FibonacciNumbers
    {
        public static IEnumerable<int> GetFibonacciNumbers()
        {
            var n0 = 0;
            var n1 = 1;
            yield return n0;
            yield return n1;
            var res = 0;
            while (true)
            {
                res = n0 + n1;
                yield return res;
                n0 = n1;
                n1 = res;
            }
        }
    }

    public class Queue<T> : IEnumerable<T>
    {
        public class QueueItem<T>
        {
            public T Value { get; set; }
            public QueueItem<T> Next { get; set; }
        }

        public QueueItem<T> Head { get; private set; }
        QueueItem<T> tail;
        public bool IsEmpty { get { return Head == null; } }
        private int _count;
        public int Count { get => _count; private set => _count = value; }

        /// <summary>
        /// Добавление элемента в очередь
        /// </summary>
        /// <param name="value">элемент</param>
        public void Enqueue(T value)
        {
            if (IsEmpty)
                tail = Head = new QueueItem<T> { Value = value, Next = null };
            else
            {
                var item = new QueueItem<T> { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
            Count++;
        }

        /// <summary>
        /// Удаление элемента из очереди
        /// </summary>
        /// <returns>очередь без удалённого элемента</returns>
        public T Dequeue()
        {
            if (Head == null) throw new InvalidOperationException();
            var result = Head.Value;
            Head = Head.Next;
            if (Head == null)
                tail = null;
            Count--;
            return result;
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

    public class Set<T> : IEnumerable<T>
    {
        public List<T> _Set = new List<T>();

        /// <summary>
        /// Добавление элемента в множество
        /// </summary>
        /// <param name="value">элемент</param>
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            else if(_Set.Count==0)
                _Set.Add(value);
            else if (!_Set.Contains(value))
                _Set.Add(value);
            else throw new InvalidOperationException("This element is already in the set");
        }

        /// <summary>
        /// Удаление элемента из множества
        /// </summary>
        /// <param name="value">элемент</param>
        public void Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (_Set.Contains(value))
                _Set.Remove(value);
            else throw new InvalidOperationException("The set doesn't contains this element");
        }

        /// <summary>
        /// Объединение множеств
        /// </summary>
        /// <param name="A">Первое множество</param>
        /// <param name="B">Второе множество</param>
        /// <returns>Новое множество</returns>
        public Set<T> Union(Set<T> A, Set<T> B)
        {
            foreach (var element in B)
                if (!A.Contains(element))
                    A.Add(element);
            return A;
        }

        /// <summary>
        /// Разность множеств
        /// </summary>
        /// <param name="A">Первое множество</param>
        /// <param name="B">Второе множество</param>
        /// <returns>Новое множество</returns>
        public Set<T> Difference(Set<T> A, Set<T> B)
        {
            var result = new Set<T>();
            foreach (var element in A)
                if (!B.Contains(element))
                    result.Add(element);
            foreach (var element in B)
                if (!A.Contains(element))
                    result.Add(element);
            return result;
        }

        /// <summary>
        /// Пересечение множеств
        /// </summary>
        /// <param name="A">Первое множество</param>
        /// <param name="B">Второе множество</param>
        /// <returns>Новое множество</returns>
        public Set<T> Intersection(Set<T> A, Set<T> B)
        {
            var result = new Set<T>();
            foreach (var element in A)
                if (B.Contains(element))
                    result.Add(element);
            return result;
        }

        /// <summary>
        /// Проверка на подмножество (наличие всех элементов В в множестве А)
        /// </summary>
        /// <param name="A">главное множество</param>
        /// <param name="B">проверяемое подмножество</param>
        /// <returns></returns>
        public bool Subset(Set<T> A, Set<T> B)
        {
            foreach (var element in B)
                if (!A.Contains(element))
                    return false;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in _Set)
                yield return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
        
}
