using System.Collections.Generic;

namespace Containers.DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        #region Fields
        public DoubleLinkedListNode<T> Head { get; private set; }
        public DoubleLinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; } = 0;
        private DoubleLinkedListNode<T> current;
        #endregion

        #region Constructors
        public DoubleLinkedList()
        {
            Head = Tail = current = null;
        }
        public DoubleLinkedList(IEnumerable<T> list)
        {
            foreach (var value in list)
                AddLast(value);
        }
        #endregion

        #region Public functions
        public void AddFirst(T value)
        {
            var tmp = new DoubleLinkedListNode<T>(value, null, Head);

            if (Head is null)
                Tail = tmp;
            else
                Head.Previous = tmp;
            Head = tmp;
            Count++;
        }
        public void AddLast(T value)
        {
            var tmp = new DoubleLinkedListNode<T>(value, Tail, null);

            if (Tail is null)
                Head = tmp;
            else
                Tail.Next = tmp;

            Tail = tmp;
            Count++;
        }
        public bool RemoveFirst()
        {
            if (Head is null)
                return false;

            if (Head == Tail)
            {
                Head = Tail = null;
                Count--;
                return true;
            }

            current = Head.Next;
            if (current is not null)
                current.Previous = null;
            
            Head.Next = null;
            Head = current;
            Count--;
            return true;
        }
        public bool RemoveLast()
        {
            if (Tail is null)
                return false;

            if (Head == Tail)
            {
                Head = Tail = null;
                Count--;
                return true;
            }

            current = Tail.Previous;
            if (current is not null)
                current.Next = null;

            Tail.Previous = null;
            Tail = current;
            Count--;
            return true;
        }
        public void Clear()
        {
            current = Head.Next;
            while (current != null)
            {
                Head.Next = null;
                Head.Previous = null;
                Head = current;
                current = current.Next;
            }
            Head = Tail = current = null;
            Count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (current = Head; current != null; current = current.Next)
                yield return current.Value;
        }
        public override string ToString()
        {
            System.Text.StringBuilder buffer = new();
            buffer.Append('[');

            for (current = Head; current != null; current = current.Next)
            {
                buffer.Append(current.Value);
                buffer.Append("<->");
            }

            if (buffer.Length - 2 >= 0)
                buffer.Remove(buffer.Length - 3, 3);

            buffer.Append(']');
            return buffer.ToString();
        }
        #endregion
    }

    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode(T value, DoubleLinkedListNode<T> previous = null, DoubleLinkedListNode<T> next = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
