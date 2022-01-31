using Xunit;

namespace Containers.SingleLinkedList.Tests
{
    public class SingleLinkedListTests
    {
        [Fact()]
        public void AddFirstTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(1);
            s.AddFirst(3);

            Assert.Equal(3, s.Count);
            Assert.Equal(3, s.Head.Value);
            Assert.Equal(2, s.Tail.Value);
        }

        [Fact()]
        public void AddLastTest()
        {
            SingleLinkedList<int> s = new();
            s.AddLast(2);
            s.AddLast(1);
            s.AddLast(3);

            Assert.Equal(3, s.Count);
            Assert.Equal(2, s.Head.Value);
            Assert.Equal(3, s.Tail.Value);
        }

        [Fact()]
        public void AddAfterTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            SingleLinkedListNode<int> node = new(10);
            s.AddAfter(s.Head.Next, node);
            Assert.Equal(6, s.Count);
            Assert.True(s.Contains(10));
            Assert.Equal(6, s.Head.Value);
            Assert.Equal(5, s.Head.Next.Value);
            Assert.Equal(10, s.Head.Next.Next.Value);
            Assert.Equal(4, s.Head.Next.Next.Next.Value);

        }

        [Fact()]
        public void RemoveFirstTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            s.RemoveFirst();
            s.RemoveFirst();
            Assert.Equal(3, s.Count);

            Assert.Equal(4, s.Head.Value);
        }

        [Fact()]
        public void RemoveLastTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            s.RemoveLast();
            s.RemoveLast();
            s.RemoveLast();
            Assert.Equal(2, s.Count);

            Assert.Equal(5, s.Tail.Value);
        }

        [Fact()]
        public void RemoveTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            Assert.True(s.Contains(4));
            Assert.True(s.Remove(4));
            Assert.Equal(4, s.Count);
            Assert.False(s.Remove(7));
            Assert.Equal(4, s.Count);
            Assert.False(s.Contains(4));
        }

        [Fact()]
        public void ContainsTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            Assert.True(s.Contains(2));
            Assert.True(s.Contains(3));
            Assert.True(s.Contains(4));
            Assert.True(s.Contains(5));
            Assert.True(s.Contains(6));
            Assert.False(s.Contains(7));
        }

        [Fact()]
        public void ClearTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(5);
            s.AddFirst(6);

            Assert.Equal(5, s.Count);
            s.Clear();
            Assert.Equal(0, s.Count);
            Assert.Null(s.Head);
            Assert.Null(s.Tail);
        }

        [Fact()]
        public void ReverseListTest()
        {
            SingleLinkedList<int> s = new();
            s.AddFirst(2);
            s.AddFirst(3);
            s.AddFirst(4);
            s.AddFirst(6);

            Assert.Equal(4, s.Count);
            s.ReverseList();
            Assert.Equal(2, s.Head.Value);
            Assert.Equal(3, s.Head.Next.Value);
            Assert.Equal(4, s.Head.Next.Next.Value);
            Assert.Equal(6, s.Head.Next.Next.Next.Value);
        }
    }
}