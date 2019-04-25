using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTree<T>
    {
        /// <summary>
        /// Comparison condition.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Constructor without initialization.
        /// </summary>
        /// <param name="comparer"></param>
        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Constructor with initialization.
        /// </summary>
        /// <param name="comparer"></param>
        /// <param name="items"></param>
        public BinaryTree(IComparer<T> comparer, IEnumerable<T> items)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();
            foreach (T item in items)
            {
                Insert(item);
            }
        }

        /// <summary>
        /// Value of item.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Left son of item.
        /// </summary>
        public BinaryTree<T> Left { get; set; }

        /// <summary>
        /// Right son of item.
        /// </summary>
        public BinaryTree<T> Right { get; set; }

        /// <summary>
        /// Parent item.
        /// </summary>
        public BinaryTree<T> Parent { get; set; }

        /// <summary>
        /// Add item in tree.
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            if (comparer.Compare(Data, default(T)) == 0 || ReferenceEquals(Data, data) == true)
            {
                Data = data;
            }
            else
            {
                if (comparer.Compare(Data, data) > 0)
                {
                    if (Left == null)
                    {
                        Left = new BinaryTree<T>(comparer);
                    }

                    Insert(data, Left, this);
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new BinaryTree<T>(comparer);
                    }

                    Insert(data, Right, this);
                }
            }
        }

        /// <summary>
        /// Find item in tree.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTree<T> Find(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            if (comparer.Compare(Data, data) == 0)
            {
                return this;
            }

            if (comparer.Compare(Data, data) > 0)
            {
                return Find(data, Left);
            }

            return Find(data, Right);
        }

        public BinaryTree<T> Find(T data, BinaryTree<T> node)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            if (node == null)
            {
                return null;
            }

            if (comparer.Compare(node.Data, data) == 0)
            {
                return node;
            }

            if (comparer.Compare(node.Data, data) > 0)
            {
                return Find(data, node.Left);
            }

            return Find(data, node.Right);
        }

        /// <summary>
        /// Returns the sequence for pre-order bypass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetPreorderRound()
        {
            List<T> result = new List<T>();
            foreach (T item in PreorderRound(this))
            {
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<T> PreorderRound(BinaryTree<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var value in PreorderRound(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in PreorderRound(node.Right))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Returns the sequence for in-order bypass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetInorderRound()
        {
            List<T> result = new List<T>();
            foreach (T item in InorderRound(this))
            {
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<T> InorderRound(BinaryTree<T> node)
        {
            if (node.Left != null)
            {
                foreach (var value in InorderRound(node.Left))
                {
                    yield return value;
                }
            }

            yield return node.Data;
            if (node.Right != null)
            {
                foreach (var value in InorderRound(node.Right))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Returns the sequence for post-order bypass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetPostorderRound()
        {
            List<T> result = new List<T>();
            foreach (T item in PostorderRound(this))
            {
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<T> PostorderRound(BinaryTree<T> node)
        {
            if (node.Left != null)
            {
                foreach (var value in PostorderRound(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in PostorderRound(node.Right))
                {
                    yield return value;
                }
            }

            yield return node.Data;
        }

        private void Insert(T data, BinaryTree<T> node, BinaryTree<T> parent)
        {
            if (comparer.Compare(node.Data, default(T)) == 0 || ReferenceEquals(node.Data, data) == true)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            else
            {
                if (comparer.Compare(node.Data, data) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTree<T>(comparer);
                    }

                    Insert(data, node.Left, node);
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTree<T>(comparer);
                    }

                    Insert(data, node.Right, node);
                }
            }
        }
    }
}
