using Xunit;
using Containers.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers.List.Tests
{
    public class ListTests
    {
        [Fact()]
        public void ListTest()
        {
            List<int> l = new(new int[] { 1, 2, 3, 4 });

            Assert.Equal(4, l.Count);
            Assert.Equal(1, l[0]);
            Assert.Equal(2, l[1]);
            Assert.Equal(3, l[2]);
            Assert.Equal(4, l[3]);
        }

        [Fact()]
        public void AddTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.Equal(1, l[0]);
            Assert.Equal(2, l[1]);
            Assert.Equal(3, l[2]);
            Assert.Equal(4, l[3]);
        }
        
        [Fact()]
        public void RemoveFirstTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.True(l.RemoveFirst());
            Assert.Equal(3, l.Count);
            Assert.True(l.RemoveFirst());
            Assert.Equal(2, l.Count);
            Assert.Equal(3, l[0]);
            Assert.True(l.RemoveFirst());
            Assert.True(l.RemoveFirst());
            Assert.False(l.RemoveFirst());
            Assert.Equal(0, l.Count);
        }

        [Fact()]
        public void RemoveLastTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.True(l.RemoveLast());
            Assert.Equal(3, l.Count);
            Assert.True(l.RemoveLast());
            Assert.Equal(2, l.Count);
            Assert.Equal(2, l[^1]);
            Assert.True(l.RemoveLast());
            Assert.True(l.RemoveLast());
            Assert.False(l.RemoveLast());
            Assert.Equal(0, l.Count);
        }

        [Fact()]
        public void RemoveAtTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.True(l.RemoveAt(1));
            Assert.False(l.Contains(2));
            Assert.Equal(3, l.Count);
        }

        [Fact()]
        public void RemoveFirstFoundValueTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.True(l.RemoveFirstFoundValue(1));
            Assert.False(l.Contains(1));
            Assert.Equal(3, l.Count);
        }

        [Fact()]
        public void ClearTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            l.Clear();
            Assert.Equal(0, l.Count);
        }

        [Fact()]
        public void ContainsTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);
            Assert.True(l.Contains(3));
            Assert.False(l.Contains(5));
        }

        [Fact()]
        public void SortTest()
        {
            List<int> l = new();
            l.Add(4);
            l.Add(2);
            l.Add(1);
            l.Add(6);

            Assert.Equal(4, l.Count);
            l.Sort(SortingStrategy.HeapSort);
            Assert.Equal(1, l[0]);
            Assert.Equal(2, l[1]);
            Assert.Equal(4, l[2]);
            Assert.Equal(6, l[3]);
        }

        [Fact()]
        public void SliceTest()
        {
            List<int> l = new();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);

            Assert.Equal(4, l.Count);

            var slice = l.Slice(1, 2);
            Assert.Equal(2, slice.Count);
            Assert.Equal(2, slice[0]);
            Assert.Equal(3, slice[1]);
        }
    }
}