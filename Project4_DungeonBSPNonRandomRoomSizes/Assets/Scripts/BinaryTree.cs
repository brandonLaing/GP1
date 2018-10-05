using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BinaryTree<T>
{
  private BinaryTreeNode<T> root;

  public BinaryTreeNode<T> Root()
  {
    return root;

  } // end Root

  public BinaryTree(BinaryTreeNode<T> rootNode)
  {
    rootNode.parent = null;
    this.root = rootNode;

  } // end BinaryTree

  public BinaryTree(T rootValue)
  {
    this.root = new BinaryTreeNode<T>(rootValue);

  } // end BinaryTree


} // end BinaryTree




public class BinaryTreeNode<T>
{
  public BinaryTreeNode<T> parent;

  public BinaryTreeNode<T> leftChild;
  public BinaryTreeNode<T> rightChild;

  public BinaryTreeNode<T> hallChild;

  public bool IsLeaf()
  {
    return leftChild == null && rightChild == null;

  } // end IsLeaf

  public bool HasHall()
  {
    return hallChild != null;

  } // end HasHall

  private T innerValue;

  public T Value()
  {
    return innerValue;

  } // end Value

  public BinaryTreeNode(T nodeValue)
  {
    this.innerValue = nodeValue;

  } // end BinaryTreeNode

  public BinaryTreeNode<T> AddChild(T childValue)
  {
    if (leftChild == null)
    {
      leftChild = new BinaryTreeNode<T>(childValue);
      leftChild.parent = this;
      return leftChild;

    } // end leftChild null

    if (rightChild == null)
    {
      rightChild = new BinaryTreeNode<T>(childValue);
      rightChild.parent = this;
      return rightChild;

    } // end rightChild null

    throw new InvalidOperationException("Cannont add more than two children to a binary node.");

  } // end BinaryTreeNode

  public BinaryTreeNode<T> AddHallway(T childValue)
  {
    if (hallChild == null)
    {
      hallChild = new BinaryTreeNode<T>(childValue);
      hallChild.parent = this;
      return hallChild;

    }

    throw new InvalidOperationException("Cannot add more than one hall to a binary node.");

  } // end AddHallway


} // end BinaryTreeNode