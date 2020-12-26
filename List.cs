﻿using System.Collections.Generic;

namespace Containers.List
{
    public class List<T>
        where T: System.IComparable<T>, System.IEquatable<T>
    {
        #region Fields
        private T[] _list;
        private int maxSize = 8;
        public int Count { get; private set; } = 0;
        #endregion

        #region Constructors
        public List() => _list = new T[maxSize];
        public List(int InitialSize) 
        {
            _list = new T[InitialSize];
            maxSize = InitialSize;
        }
        #endregion

        #region Public functions
        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }
        public void Add(T value)
        {
            if (Count >= maxSize) // Needs to be resized
                Resize(maxSize * 2);       
            _list[Count++] = value;
        }
        public void Add(IEnumerable<T> list)
        {
            foreach (var value in list)
                Add(value);
        }
        public bool RemoveFirst()
        {
            return Remove(0);
        }
        public bool RemoveLast()
        {
            if (Count == 0)
                return false;

            _list[--Count] = default;
            return true;
        }
        public bool Remove(int index)
        {
            if (index == Count - 1)
                return RemoveLast();

            if (index >= Count)
                return false;

            for (int i = index; i < Count - 1; i++)
            {
                _list[i] = _list[i + 1];
            }
            _list[--Count] = default;
            return true;
        }
        public bool RemoveValue(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_list[i].Equals(value))
                    return Remove(i);
            }
            return false;
        }
        public void Clear(int newArraySize = 8)
        {
            for (int i = 0; i < Count; i++)
            {
                _list[i] = default;
            }

            maxSize = newArraySize;
            _list = new T[maxSize];
            Count = 0;
        }
        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
                if (_list[i].Equals(value))
                    return true;

            return false;
        }
        public void Sort(SortingStrategy sortingStrategy)
        {
            switch (sortingStrategy)
            {
                case SortingStrategy.BubbleSort:
                    BubbleSort();
                    break;
                case SortingStrategy.MergeSort:
                    MergeSort();
                    break;
            }
        }
        public override string ToString()
        {
            System.Text.StringBuilder buffer = new();
            buffer.Append('[');
            for (int i = 0; i < Count; i++)
            {
                buffer.Append(_list[i]);
                buffer.Append(", ");
            }
            if(buffer.Length - 2 >= 0) 
                buffer.Remove(buffer.Length - 2, 2);

            buffer.Append(']');

            return buffer.ToString();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _list[i];
            }
        }
        #endregion

        #region Inner functions
        private void BubbleSort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (_list[i].CompareTo(_list[j]) > 0)
                    {
                        var tmp = _list[i];
                        _list[i] = _list[j];
                        _list[j] = tmp;
                    }
                }
            }
        }
        private void MergeSort()
        {
            for (int i = Count / 2 - 1; i >= 0; i--)
                Heapify(Count, i);

            for (int i = Count - 1; i > 0; i--)
            {
                var tmp = _list[0];
                _list[0] = _list[i];
                _list[i] = tmp;

                Heapify(i, 0);
            }
        }
        private void Heapify(int n, int i)
        {
            int largests = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && _list[l].CompareTo(_list[largests]) > 0)
                largests = l;

            if (r < n && _list[r].CompareTo(_list[largests]) > 0)
                largests = r;

            if (largests != i)
            {
                var tmp = _list[i];
                _list[i] = _list[largests];
                _list[largests] = tmp;

                Heapify(n, largests);
            }
        }
        private void Resize(int newSize)
        {
            var newList = new T[newSize];
            maxSize = newSize;

            for (int i = 0; i < Count; i++)
            {
                newList[i] = _list[i];
            }
            _list = newList;
        }       
        #endregion
    }
}