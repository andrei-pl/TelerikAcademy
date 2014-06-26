namespace _06.BinarySearch
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class TreeNode<T> : IComparable<TreeNode<T>>, IEnumerable<TreeNode<T>>
     where T : IComparable<T>
    {
        #region Properties

        // Contains the data of the node
        public T Item { get; set; }

        // Contains the parent of the node
        public TreeNode<T> Parent { get; set; }

        // Contains the left child of the node
        public TreeNode<T> Left { get; set; }

        // Contains the right child of the node
        public TreeNode<T> Right { get; set; }

        #endregion

        #region Constructors

        public TreeNode(T item)
        {
            this.Item = item;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return this.Item.ToString();
        }

        public override bool Equals(object obj)
        {
            // If the cast is invalid, the result will be null
            TreeNode<T> other = obj as TreeNode<T>;

            // Check if we have valid not null BinaryTreeNode object
            if (other == null)
            {
                return false;
            }

            return this.Item.CompareTo(other.Item) == 0;
        }

        public static bool operator ==(TreeNode<T> nodeA, TreeNode<T> nodeB)
        {
            return TreeNode<T>.Equals(nodeA, nodeB);
        }

        public static bool operator !=(TreeNode<T> nodeA, TreeNode<T> nodeB)
        {
            return !(TreeNode<T>.Equals(nodeA, nodeB));
        }

        public override int GetHashCode()
        {
            return this.Item.GetHashCode();
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Item.CompareTo(other.Item);
        }

        IEnumerator<TreeNode<T>> IEnumerable<TreeNode<T>>.GetEnumerator()
        {
            if (this.Left != null)
            {
                foreach (TreeNode<T> node in this.Left)
                {
                    yield return node;
                }
            }

            yield return this;

            if (this.Right != null)
            {
                foreach (TreeNode<T> node in this.Right)
                {
                    yield return node;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TreeNode<T>>)this).GetEnumerator();
        }

        #endregion
    }
}
