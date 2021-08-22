using Containers.List;

namespace Containers
{
    public class ArraySlice<T>
        where T : System.IComparable<T>, System.IEquatable<T>
    {
        private readonly int _start,
                             _length;

        private readonly List<T> _list;
        public int Count { get { return _length; } }

        public ArraySlice(int start, int length, List<T> listReferance)
        {
            _start = start;
            _length = length;
            _list = listReferance;
        }

        public T this[int index]
        {
            get { return _list[index + _start]; }
            set { _list[index] = value; }
        }

        public List<T> ToNewArray()
        {
            List<T> newArray = new List<T>(_length);
            for (int i = 0; i < _length; i++)
            {
                newArray.Add(this[i]);
            }
            return newArray;
        }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }
    }
}
