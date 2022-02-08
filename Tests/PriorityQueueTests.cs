using Xunit;
using Containers.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers.PriorityQueue.Tests
{
    public class PriorityQueueTests
    {
        [Fact()]
        public void EnqueueTest()
        {
            PriorityQueue<int, int> queue = new();    
            queue.Enqueue(3, 3);
            queue.Enqueue(117, 9);
            queue.Enqueue(20, 5);
            queue.Enqueue(11, 1);

            Assert.Equal(4, queue.Count);
        }

        [Fact()]
        public void DequeueTest()
        {
            PriorityQueue<int, int> queue = new();
            queue.Enqueue(3, 3);
            queue.Enqueue(117, 9);
            queue.Enqueue(11, 1);
            queue.Enqueue(20, 5);

            Assert.Equal(4, queue.Count);
            Assert.Equal(11, queue.Dequeue().Element);
            Assert.Equal(3, queue.Dequeue().Element);
            Assert.Equal(2, queue.Count);
        }

        [Fact()]
        public void ClearTest()
        {
            PriorityQueue<int, int> queue = new();
            queue.Enqueue(3, 3);
            queue.Enqueue(117, 9);
            queue.Enqueue(11, 1);
            queue.Enqueue(20, 5);

            Assert.Equal(4, queue.Count);
            queue.Clear();
            Assert.Equal(0, queue.Count);
        }
    }
}