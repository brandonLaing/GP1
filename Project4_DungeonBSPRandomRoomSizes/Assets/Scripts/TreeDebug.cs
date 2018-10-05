using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDebug : MonoBehaviour
{
  void Start ()
  {
    // TODO: Use the BinaryTree class to demonstrate its correctness
    BinaryTree<int> sampleTree = new BinaryTree<int>(42);

    BinaryTreeNode<int> left = sampleTree.Root().AddChild(5);
    BinaryTreeNode<int> right = sampleTree.Root().AddChild(17);

    left.AddChild(-6);
    left.AddChild(12);

    right.AddChild(128);
    right.AddChild(1024);

    // Now what?
    BinaryTreeNode<int> treeRoot = sampleTree.Root();
    List<BinaryTreeNode<int>> leaves = new List<BinaryTreeNode<int>>();

    CollectLeaves(treeRoot, leaves);
    // At this point, <leaves> should contain all the childless nodes in the tree

    foreach (BinaryTreeNode<int> leaf in leaves)
    {
      Debug.Log("Leaf found with value " + leaf.Value() + " and parent value " + leaf.parent.Value());
      int currentLeafSum = CountFromNodeToRoot(leaf);
      Debug.Log("Current leaf sum: " + currentLeafSum);

    }

    #region NotNeededAnymore

    /** Not needed anymore
    BinaryTreeNode<int> current;

    current = leftOfLeft;

    int leftofLeftSum = 0;
    while (current != null)
    {
      leftofLeftSum += current.Value();
      current = current.parent;

    } // end current null
    // leftOfSum expected = 41
    Debug.Log("leftOfSum = " + leftofLeftSum);

    int rightOfLeftSum = 0;
    current = rightOfLeft;

    while (current != null)
    {
      rightOfLeftSum += current.Value();
      current = current.parent;

    } // end current null
    // rightOfLeftSum expected = 59
    Debug.Log("rightOfLeftSum = " + rightOfLeftSum);
  */

    //Debug.Log("leftOfLeft: " + CountFromNodeToRoot(leftOfLeft));
    //Debug.Log("righOfLeft: " + CountFromNodeToRoot(rightOfLeft));
    //Debug.Log("leftOfRight: " + CountFromNodeToRoot(leftOfRight));
    //Debug.Log("rightOfRight: " + CountFromNodeToRoot(rightOfRight));

#endregion

  } // end Start

  private void CollectLeaves(BinaryTreeNode<int> currentNode, List<BinaryTreeNode<int>> leaves)
  {
    if (currentNode == null) return;

    // Pratical exit case: current node == leaf node.
    if (currentNode.IsLeaf())
    {
      leaves.Add(currentNode);

    }

    else
    {
      CollectLeaves(currentNode.leftChild, leaves);
      CollectLeaves(currentNode.rightChild, leaves);

    }

  } // end CollectLeaves

  private int CountFromNodeToRoot(BinaryTreeNode<int> startNode)
  {
    BinaryTreeNode<int> current = startNode;
    int totalValue = 0;

    while (current != null)
    {
      totalValue += current.Value();
      current = current.parent;

    }

    return totalValue;
  }

}
