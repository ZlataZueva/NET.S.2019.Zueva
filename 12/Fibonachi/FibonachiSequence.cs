using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    public class FibonachiSequence
    {
        private List<int> sequence;
        private int count;

        /// <summary>
        /// Constuctor creates sequence.
        /// </summary>
        /// <param name="count">
        /// Count of elements in sequence.
        /// </param>
        public FibonachiSequence(int count)
        {
            this.count = count;
            sequence = new List<int>();
            GenerateSequence(count);
        }

        /// <summary>
        /// User method for getting current sequence.
        /// </summary>
        /// <returns>
        /// Sequence.
        /// </returns>
        public List<int> GetSequence()
        {
            return sequence;
        }

        /// <summary>
        /// Generating a sequence with dimension count.
        /// </summary>
        /// <param name="count">
        /// Count of elements in sequence.
        /// </param>
        public void GenerateNewSequence(int count)
        {
            this.count = count;
            sequence.Clear();
            GenerateSequence(count);
        }

        /// <summary>
        /// Passage through the elements.
        /// </summary>
        /// <returns>
        /// Current element.
        /// </returns>
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return sequence[i];
            }
        }

        /// <summary>
        /// Generate Fibonacci numbers.
        /// </summary>
        /// <param name="count">
        /// Count of elements.
        /// </param>
        private void GenerateSequence(int count)
        {
            int current;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    sequence.Add(0);
                    continue;
                }

                if (i == 1)
                {
                    sequence.Add(1);
                    continue;
                }

                current = sequence[i - 1] + sequence[i - 2];
                sequence.Add(current);
            }
        }
    }
}
