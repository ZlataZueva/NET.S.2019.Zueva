using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    /// <summary>
    /// Square matrix heir which has the same values in elements [i, j] and [j, i].
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements.
    /// </typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Create matrix with values of elements.
        /// </summary>
        /// <param name="array">
        /// Values of elements.
        /// </param>
        public SymmetricMatrix(T[,] array)
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
                for (int j = i; j < this.Size; j++)
                {
                    this.Matrix[i, j] = array[i, j];
                    if (i != j)
                    {
                        this.Matrix[j, i] = array[i, j];
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
                base[i, j] = value;
                if (i != j)
                {
                    base[j, i] = value;
                }
            }
        }
    }
}
