namespace ComplexityTheory.Test.DataStructures.Trees
{
    using System.Diagnostics.CodeAnalysis;

    using ComplexityTheory.Core.DataStructures.Trees;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public static class TrinaryTestHelper
    {
        public static TrinaryTree.TrinaryTreeNode AssertLeftIsNull(this TrinaryTree.TrinaryTreeNode node)
        {
            Assert.Null(node.Left);
            return node;
        }

        public static TrinaryTree.TrinaryTreeNode AssertMiddleIsNull(this TrinaryTree.TrinaryTreeNode node)
        {
            Assert.Null(node.Middle);
            return node;
        }

        public static TrinaryTree.TrinaryTreeNode AssertRightIsNull(this TrinaryTree.TrinaryTreeNode node)
        {
            Assert.Null(node.Right);
            return node;
        }
    }
}