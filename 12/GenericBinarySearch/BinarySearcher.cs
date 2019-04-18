using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearch
{
    /// <summary>
    /// Class contains method for binary searching elements in sequence.
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements in sequence.
    /// </typeparam>
    public class BinarySearcher<T> where T : IComparable
    {
            /// <summary>
            /// Array contains input elements.
            /// </summary>
            private T[] sequense;

            /// <summary>
            /// Constructor calls method for sorting input sequence.
            /// </summary>
            /// <param name="inputSequence"></param>
            public BinarySearcher(IEnumerable<T> inputSequence)
            {
                if (ReferenceEquals(inputSequence, null))
                {
                    throw new ArgumentNullException();
                }

                SetSequence(inputSequence);
            }

            /// <summary>
            /// Get sorted sequence in form of array.
            /// </summary>
            /// <returns></returns>
            public T[] GetSequence()
            {
                return sequense;
            }

            /// <summary>
            /// Set new sequence.
            /// </summary>
            /// <param name="inputSequence"></param>
            public void SetSequence(IEnumerable<T> inputSequence)
            {
                if (ReferenceEquals(inputSequence, null))
                {
                    throw new ArgumentNullException();
                }

                int length = inputSequence.Count();
                sequense = new T[length];
                int i = 0;
                foreach (T elem in inputSequence)
                {
                    sequense[i] = elem;
                    i++;
                }

                QuickSort(ref sequense);
            }

            /// <summary>
            /// Sorting input sequence.
            /// </summary>
            /// <param name="array"></param>
            public void QuickSort(ref T[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException();
                }

                if (array.Length <= 0)
                {
                    throw new ArgumentException(nameof(array));
                }

                QuickSort(ref array, 0, array.Length - 1);
            }

            /// <summary>
            /// User method to find index of input element in current .
            /// </summary>
            /// <param name="value">
            /// Element for searching.
            /// </param>
            /// <returns>
            /// Index.
            /// </returns>
            public int BinarySearch(T value)
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException();
                }

                return BinarySearch(sequense, value, (IComparable<T>)value);
            }

            /// <summary>
            /// Sorting input sequence.
            /// </summary>
            /// <param name="array">
            /// Current interval.
            /// </param>
            /// <param name="first">
            /// First element in interval.
            /// </param>
            /// <param name="last">
            /// Last element in interval.
            /// </param>
            private void QuickSort(ref T[] array, int first, int last)
            {
                T p = array[((last - first) / 2) + first];
                T temp;
                int i = first, j = last;
                while (i <= j)
                {
                    while (array[i].CompareTo(p) < 0 && i <= last)
                    {
                        ++i;
                    }

                    while (array[j].CompareTo(p) > 0 && j >= first)
                    {
                        --j;
                    }

                    if (i <= j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        ++i;
                        --j;
                    }
                }

                if (j > first)
                {
                    QuickSort(ref array, first, j);
                }

                if (i < last)
                {
                    QuickSort(ref array, i, last);
                }
            }

            /// <summary>
            /// Searching element in array in intervals.
            /// </summary>
            /// <param name="array">
            /// Input elements.
            /// </param>
            /// <param name="value">
            /// Element for searching.
            /// </param>
            /// <param name="comparer">
            /// Interface variable for compering current and necessary element.
            /// </param>
            /// <returns>
            /// Index.
            /// </returns>
            private int BinarySearch(T[] array, T value, IComparable<T> comparer)
            {
                int high, low = 0, mid;
                high = array.Length - 1;
                if (array[0].Equals(value))
                {
                    return 0;
                }
                else
                {
                    if (array[high].Equals(value))
                    {
                        return high;
                    }
                    else
                    {
                        while (low <= high)
                        {
                            mid = (high + low) / 2;
                            if (comparer.CompareTo(array[mid]) == 0)
                            {
                                return mid;
                            }
                            else
                            {
                                if (comparer.CompareTo(array[mid]) > 0)
                                {
                                    high = mid - 1;
                                }
                                else
                                {
                                    low = mid + 1;
                                }
                            }
                        }

                        return -1;
                    }
                }
            }
        }
}
