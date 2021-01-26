using System.Collections.Generic;
namespace Containers.SingleLinkedList
{
    public class SingleLinkedList<T>
        where T : System.IComparable<T>, System.IEquatable<T>
    {
        #region Fields
        public SingleLinkedListNode<T> Head { get; private set; }
        public  SingleLinkedListNode<T> Tail { get; private set; }
        private SingleLinkedListNode<T> current;
        public int Count { get; private set; } = 0;
        #endregion

        #region Constructors
        public SingleLinkedList()
        {
            Head = Tail = current = null;
        }
        public SingleLinkedList(IEnumerable<T> list)
        {
            foreach (var value in list)
                AddLast(value);
        }
        #endregion

        #region Public functions
        public void AddFirst(T value)
        {
            var tmp = new SingleLinkedListNode<T>(value, Head);
            if (Head is null)
                Tail = tmp;
            Head = tmp;
            Count++;
        }
        public void AddLast(T value)
        {
            var tmp = new SingleLinkedListNode<T>(value, null);

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
            current = Head;
            Head = Head.Next;
            current.Next = null;
            Count--;
            return true;
        }
        public bool RemoveLast()
        {
            if (Head is null)
                return false;
            if (Head == Tail)
            {
                Head = Tail = null;
                Count--;
                return true;
            }

            current = Head;
            while (current.Next != Tail)
                current = current.Next;
            
            current.Next = null;
            Tail = current;
            Count--;
            return true;
        }
        public bool Remove(T value)
        {
            if (Head is null)
                return false;
            if (Head.Value.Equals(value))
            {
                current = Head;
                Head = Head.Next;
                if (Count == 1) // Point the Tail pointer to the head (null)
                    Tail = Head;
                current.Next = null;
                current = null;
                Count--;
                return true;
            }

            var previous = Head;
            current = Head.Next;
            while (current != null && !current.Value.Equals(value))
            {
                previous = current;
                current = current.Next;
            }
            if (current is null)
                return false;

            previous.Next = current.Next;
            current.Next = null;
            current = null;
            Count--;
            return true;
        }
        public bool Contains(T value)
        {
            for (SingleLinkedListNode<T> node = Head; node != null; node = node.Next)
            {
                if (node.Value.Equals(value))
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            // The purpose of this while loop is to break each node's link to the next node
            // This is done to make the GC detect unused objects more efficiently
            current = Head.Next;
            while (current != null)
            {
                Head.Next = null;
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

            for (current = Head; current != null ; current = current.Next)
            {
                buffer.Append(current.Value);
                buffer.Append("->");
            }

            if (buffer.Length - 2 >= 0)
                buffer.Remove(buffer.Length - 2, 2);

            buffer.Append(']');
            return buffer.ToString();
        }
        #endregion

    }
    public class SingleLinkedListNode<T>
    {
        public T Value { get; set; }
        public SingleLinkedListNode<T> Next { get; set; }

        public SingleLinkedListNode(T value, SingleLinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
