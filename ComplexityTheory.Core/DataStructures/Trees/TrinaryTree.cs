namespace ComplexityTheory.Core.DataStructures.Trees
{
    /// <summary>
    ///     The trinary tree.
    /// </summary>
    public class TrinaryTree
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TrinaryTree"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public TrinaryTree(int value)
        {
            this.RootNode = new TrinaryTreeNode(value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrinaryTree" /> class.
        /// </summary>
        public TrinaryTree()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the root node.
        /// </summary>
        public TrinaryTreeNode RootNode { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The delete.
        ///     http://www.algolist.net/Data_structures/Binary_search_tree/Removal
        /// </summary>
        /// <param name="searchValue">
        /// The search value.
        /// </param>
        public void Delete(int searchValue)
        {
            if (this.RootNode == null)
            {
                return;
            }

            if (this.RootNode.Data == searchValue)
            {
                var dummyRoot = new TrinaryTreeNode(0);
                dummyRoot.Left = this.RootNode;
                this.RootNode.Remove(searchValue, dummyRoot);
                this.RootNode = dummyRoot.Left;
                return;
            }

            this.RootNode.Remove(searchValue, null);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Insert(int value)
        {
            if (this.RootNode == null)
            {
                this.RootNode = new TrinaryTreeNode(value);
                return;
            }

            this.AddNode(value, this.RootNode);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add node.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="root">
        /// The root.
        /// </param>
        private void AddNode(int data, TrinaryTreeNode root)
        {
            TrinaryTreeNode newRoot = root;

            while (true)
            {
                if (newRoot.Data == data)
                {
                    if (newRoot.Middle == null)
                    {
                        newRoot.Middle = new TrinaryTreeNode(data);
                        return;
                    }

                    newRoot = newRoot.Middle;
                }
                else if (data < newRoot.Data)
                {
                    if (newRoot.Left == null)
                    {
                        newRoot.Left = new TrinaryTreeNode(data);
                        return;
                    }

                    newRoot = newRoot.Left;
                }
                else
                {
                    if (newRoot.Right == null)
                    {
                        newRoot.Right = new TrinaryTreeNode(data);
                        return;
                    }

                    newRoot = newRoot.Right;
                }
            }
        }

        #endregion

        /// <summary>
        ///     The trinary tree node.
        /// </summary>
        public class TrinaryTreeNode
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="TrinaryTreeNode"/> class.
            /// </summary>
            /// <param name="data">
            /// The data.
            /// </param>
            public TrinaryTreeNode(int data)
            {
                this.Data = data;
            }

            #endregion

            #region Public Properties

            /// <summary>
            ///     Gets or sets the data.
            /// </summary>
            public int Data { get; set; }

            /// <summary>
            ///     Gets or sets the left.
            /// </summary>
            public TrinaryTreeNode Left { get; set; }

            /// <summary>
            ///     Gets or sets the middle.
            /// </summary>
            public TrinaryTreeNode Middle { get; set; }

            /// <summary>
            ///     Gets or sets the right.
            /// </summary>
            public TrinaryTreeNode Right { get; set; }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The is left.
            /// </summary>
            /// <param name="parent">
            /// The parent.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool IsLeft(TrinaryTreeNode parent)
            {
                return this.Data < parent.Data;
            }

            /// <summary>
            /// The is middle.
            /// </summary>
            /// <param name="parent">
            /// The parent.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool IsMiddle(TrinaryTreeNode parent)
            {
                return this.Data == parent.Data;
            }

            /// <summary>
            /// The is right.
            /// </summary>
            /// <param name="parent">
            /// The parent.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool IsRight(TrinaryTreeNode parent)
            {
                return this.Data > parent.Data;
            }

            /// <summary>
            /// The min value.
            /// </summary>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public int MinValue()
            {
                TrinaryTreeNode node = this;

                while (true)
                {
                    if (node.Left == null)
                    {
                        return node.Data;
                    }

                    node = node.Left;
                }
            }

            /// <summary>
            /// The remove.
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            /// <param name="parent">
            /// The parent.
            /// </param>
            public void Remove(int value, TrinaryTreeNode parent)
            {
                // if the search value is less than the current node's data -> go left                
                if (value < this.Data)
                {
                    if (this.Left != null)
                    {
                        this.Left.Remove(value, this);
                    }

                    return;
                }

                // if the search value is greater than the current node's data -> go right
                if (value > this.Data)
                {
                    if (this.Right != null)
                    {
                        this.Right.Remove(value, this);
                    }

                    return;
                }

                // the only other option is that this.Data = value
                // the easiest thing to do here, is see if middle is not null, and replace references
                if (this.Middle != null)
                {
                    this.Middle = this.Middle.Middle;
                    return;
                }

                // ok, so we can't take the easy way out, we can resort to standard binary search tree methods here.
                // http://www.algolist.net/Data_structures/Binary_search_tree/Removal
                if (this.Left != null && this.Right != null)
                {
                    this.Data = this.Right.MinValue();
                    this.Right.Remove(this.Data, this);
                }
                else if (parent.Left == this)
                {
                    parent.Left = this.Left ?? this.Right;
                }
                else if (parent.Right == this)
                {
                    parent.Right = this.Left ?? this.Right;
                }
            }

            #endregion
        }

        /// <summary>
        ///     The node info.
        /// </summary>
        private class NodeInfo
        {
            #region Public Properties

            /// <summary>
            ///     Gets or sets the parent node.
            /// </summary>
            public TrinaryTreeNode ParentNode { get; set; }

            /// <summary>
            ///     Gets or sets the search node.
            /// </summary>
            public TrinaryTreeNode SearchNode { get; set; }

            #endregion
        }
    }
}