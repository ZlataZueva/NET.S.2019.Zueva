using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    /// <summary>
    /// Square matrix heir which contains values only on the main diagonal.
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements.
    /// </typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            this.Size = array.GetLength(0) <= array.GetLength(1) ? array.GetLength(0) : array.GetLength(1);

            if (this.Size < 1)
            {
                throw new ArgumentException(nameof(array));
            }

            this.Change += this.Message;
            this.Matrix = new T[this.Size, this.Size];

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.Matrix[i, j] = default(T);
                    if (i == j)
                    {
                        this.Matrix[i, j] = array[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Indexer in matrix.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>
        /// Element [i, j].
        /// </returns>
        public override T this[int i, int j]
        {
            set
            {
                if (i != j)
                {
                    throw new ArgumentException();
                }

                base[i, j] = value;
            }
        }
    }
}
