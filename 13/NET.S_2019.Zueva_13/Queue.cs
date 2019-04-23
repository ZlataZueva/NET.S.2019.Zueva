using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S_2019.Zueva_13
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private T[] elements;
        private int current;

        /// <summary>
        /// Head index of queue.
        /// </summary>
        private int firstElem;

        /// <summary>
        /// Tail index of queue.
        /// </summary>
        private int lastElem;

        /// <summary>
        /// Real number of elements.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Default capacity.
        /// </summary>
        private int defaultCapacity = 10;

        /// <summary>
        /// Capacity of queue. Count and capacity can not be the same.
        /// </summary>
        private int capacity;

        /// <summary>
        /// Constructor with default capacity of array.
        /// </summary>
        public Queue()
        {
            elements = new T[defaultCapacity];
            capacity = defaultCapacity;
            firstElem = 0;
            lastElem = 0;
        }

        /// <summary>
        /// User transfers items in constructor. Copies existing elements.
        /// </summary>
        /// <param name="collection"></param>
        public Queue(IEnumerable<T> collection)
        {
            capacity = collection.Count();
            foreach (T element in collection)
            {
                Enqueue(element);
                lastElem++;
                count++;
            }

            firstElem = 0;
        }

        /// <summary>
        /// User specifies size.
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            elements = new T[capacity];
            this.capacity = capacity;
            firstElem = 0;
            lastElem = 0;
        }

        /// <summary>
        /// Delete all elements in queue.
        /// </summary>
        public void Clear()
        {
            Array.Clear(elements, 0, elements.Length);
        }

        /// <summary>
        /// Remove item from queue.
        /// </summary>
        /// <returns>
        /// Item.
        /// </returns>
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }

            T result = elements[firstElem];
            elements[firstElem] = default(T);
            firstElem++;
            if (firstElem == capacity)
            {
                firstElem = 0;
            }

            count--;
            return result;
        }

        /// <summary>
        /// Add item to queue.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            elements[lastElem] = item;
            T[] newArr = new T[++capacity];
            for (int i = 0; i < lastElem + 1; i++)
            {
                newArr[i] = elements[i];
            }
            elements = newArr;
            count = lastElem;
            lastElem++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// To support foreach.
        /// </summary>
        /// <returns>
        /// Iterator.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary>
        /// Show first element without removing.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }

            T result = elements[firstElem];
            return result;
        }

        /// <summary>
        /// Iterator of queue.
        /// </summary>
        private class QueueEnumerator : IEnumerator<T>
        {
            private T[] queue;
            private int first;
            private int last;
            private int currentIndex = -1;

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue.elements;
                first = queue.firstElem;
                last = queue.lastElem;
            }

            /// <summary>
            /// Current item in container.
            /// </summary>
            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex >= queue.Length)
                    {
                        throw new InvalidOperationException();
                    }

                    return queue[currentIndex];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            /// <summary>
            /// Move one position forward in the element container.
            /// </summary>
            /// <returns>
            /// True is possible to move, false isn't possible.
            /// </returns>
            public bool MoveNext()
            {
                if (currentIndex < queue.Length - 1)
                {
                    currentIndex++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Move to top of container.
            /// </summary>
            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Get number of elements in the queue.
        /// </summary>
        public int Length
        {
            get
            {
                return elements.Length;
            }
        }
    }
}
