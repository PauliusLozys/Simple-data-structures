using System.Collections.Generic;
namespace Containers.SingleLinkedList
{
    public class SingleLinkedList<T>
        where T : System.IComparable<T>, System.IEquatable<T>
    {
        #region Fields
        public SingleLinkedListNode<T> Head { get; private set; }
        public  SingleLinkedListNode<T> Tail { get; private set; }
        private SingleLinkedListNode<T> _current;
        public int Count { get; private set; } = 0;
        #endregion

        #region Constructors
        public SingleLinkedList()
        {
            Head = Tail = _current = null;
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

        public void AddAfter(SingleLinkedListNode<T> currentNode, SingleLinkedListNode<T> nextNode)
        {
            nextNode.Next = currentNode.Next;
            currentNode.Next = nextNode;
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
            _current = Head;
            Head = Head.Next;
            _current.Next = null;
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

            _current = Head;
            while (_current.Next != Tail)
                _current = _current.Next;
            
            _current.Next = null;
            Tail = _current;
            Count--;
            return true;
        }
        public bool Remove(T value)
        {
            if (Head is null)
                return false;
            if (Head.Value.Equals(value))
            {
                _current = Head;
                Head = Head.Next;
                if (Count == 1) // Point the Tail pointer to the head (null)
                    Tail = Head;
                _current.Next = null;
                _current = null;
                Count--;
                return true;
            }

            var previous = Head;
            _current = Head.Next;
            while (_current != null && !_current.Value.Equals(value))
            {
                previous = _current;
                _current = _current.Next;
            }
            if (_current is null)
                return false;

            previous.Next = _current.Next;
            _current.Next = null;
            _current = null;
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
            _current = Head.Next;
            while (_current != null)
            {
                Head.Next = null;
                Head = _current;
                _current = _current.Next;
            }
            Head = Tail = _current = null;
            Count = 0;
        }
        public void ReverseList()
        {
            _current = Head;
            SingleLinkedListNode<T> prev = null;
            
            while (_current != null)
            {
                var next = _current.Next;
                _current.Next = prev;
                prev = _current;
                _current = next;
            }
            (Tail, Head) = (Head, Tail); // Swap Head and Tail nodes
            _current = null;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (_current = Head; _current != null; _current = _current.Next)
                yield return _current.Value;
        }
        public override string ToString()
        {
            System.Text.StringBuilder buffer = new();
            buffer.Append('[');

            for (_current = Head; _current != null ; _current = _current.Next)
            {
                buffer.Append(_current.Value);
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
