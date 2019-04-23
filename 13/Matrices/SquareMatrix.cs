using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    /// <summary>
    /// General class to work with square matrix.
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements in matrix.
    /// </typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Contains elements of matrix.
        /// </summary>
        private T[,] matrix;

        /// <summary>
        /// Dimension of matrix.
        /// </summary>
        private int size;

        /// <summary>
        /// Create matrix without initialization.
        /// </summary>
        /// <param name="size"></param>
        public SquareMatrix(int size)
        {
            this.size = size;
            if (size < 1)
            {
                throw new ArgumentException(nameof(size));
            }

            matrix = new T[size, size];
            Change += Message;
        }

        /// <summary>
        /// Create matrix with values of elements.
        /// </summary>
        /// <param name="array">
        /// Values of elements.
        /// </param>
        public SquareMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            size = array.GetLength(0) <= array.GetLength(1) ? array.GetLength(0) : array.GetLength(1);

            if (size < 1)
            {
                throw new ArgumentException(nameof(array));
            }

            Change += Message;
            matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = array[i, j];
                }
            }
        }

        public SquareMatrix()
        {
        }

        /// <summary>
        /// Type of methods which will be called after changing elements.
        /// </summary>
        /// <param name="i">
        /// Number of row of changing element. 
        /// </param>
        /// <param name="j">
        /// Number of column of changing element.
        /// </param>
        /// <param name="elem"></param>
        public delegate void ChangeEventHandler(int i, int j, T elem);

        /// <summary>
        /// Event - change element.
        /// </summary>
        public event ChangeEventHandler Change;

        public T[,] Matrix
        {
            get { return matrix; }
            protected set { matrix = value; }
        }

        public int Size
        {
            get { return size; }
            protected set { size = value; }
        }

        /// <summary>
        /// Indexer for elements in matrix.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>
        /// Element [i, j].
        /// </returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= size)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                if (j < 0 || j >= size)
                {
                    throw new ArgumentOutOfRangeException(nameof(j));
                }

                return matrix[i, j];
            }

            set
            {
                matrix[i, j] = value;
                OnChange(i, j, value);
            }
        }

        /// <summary>
        /// Count sum of two matrices.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> first, SquareMatrix<T> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            if (first.Size != second.Size)
            {
                throw new ArgumentException();
            }

            SquareMatrix<T> result = new SquareMatrix<T>(first.Size);

            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    result[i, j] = Convert.ChangeType((dynamic)first[i, j] + (dynamic)second[i, j], typeof(T));
                }
            }

            return result;
        }

        /// <summary>
        /// Calls all methods that are subscribed to change.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="elem"></param>
        protected void OnChange(int i, int j, T elem)
        {
            if (Change != null)
            {
                Change.Invoke(i, j, elem);
            }
        }

        /// <summary>
        /// Output info about changing element.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="elem"></param>
        protected void Message(int i, int j, T elem)
        {
            Console.WriteLine("Элемент ({0}, {1}) изменен на значение {2}", i, j, elem.ToString());
        }
    }
}
