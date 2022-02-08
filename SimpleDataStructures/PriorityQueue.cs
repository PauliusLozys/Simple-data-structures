using Containers.SingleLinkedList;

namespace Containers.PriorityQueue
{
    public class PriorityQueue<Te, Tp>
        where Te : System.IComparable<Te>, System.IEquatable<Te>
        where Tp : System.IComparable<Tp>, System.IEquatable<Tp>
    {
        #region Fields
        private readonly SingleLinkedList<(Te Element, Tp Priority)> _internalList;
        public int Count { get => _internalList.Count; }
        #endregion

        #region Constructor
        public PriorityQueue()
        {
            _internalList = new SingleLinkedList<(Te, Tp)>();
        }
        #endregion

        #region Public fields
        public void Enqueue(Te element, Tp priority)
        {
            var current = _internalList.Head;

            if (current is null)
            {
                _internalList.AddFirst((element, priority));
                return;
            }

            if (priority.CompareTo(current.Value.Priority) < 0) // if priority smaller than head
            {
                _internalList.AddFirst((element, priority));
                return;
            }

            while (current.Next != null)
            {
                if (priority.CompareTo(current.Next.Value.Priority) < 0)
                {
                    SingleLinkedListNode<(Te, Tp)> node = new SingleLinkedListNode<(Te, Tp)>((element, priority), null);
                    _internalList.AddAfter(current, node);
                    return;
                }
                current = current.Next;
            }

            // Add to end
            _internalList.AddLast((element, priority));
        }
        public (Te Element, Tp Priority) Dequeue()
        {
            var value = _internalList.Head.Value;
            _internalList.RemoveFirst();
            return value;
        }
        public void Clear()
        {
            _internalList.Clear();
        }
        public override string ToString()
        {
            return _internalList.ToString();
        }
        #endregion
    }
}
