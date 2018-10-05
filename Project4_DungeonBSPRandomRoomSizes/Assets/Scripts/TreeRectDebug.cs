using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

// this is the random

public class TreeRectDebug : MonoBehaviour
{
  public int levelWidth = 20;
  public int levelHeight = 20;

  public int numberOfSplits = 8;

  public string typeOfDrive = "F";

  private float totalTimePartitioning;
  private int numberOfTimesPartitioned;

  private float totalTimeRooming;
  private int numberOfTimesRoomed;

  private float totalTimeHalling;
  private int numberOfTimesHalled;

  private float totalTimeDisplaying;
  private int numberOfTimesDisplayed;

  private float totalTimeTotaling;
  private int numberOfTimesTotaled;

  // Use this for initialization
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      DoThing(); 

    } // end If space

    //if (Input.GetKeyDown(KeyCode.Equals))
    //{
    //  Debug.Log("Average Partition: " + (totalTimePartitioning / numberOfTimesPartitioned));
    //  Debug.Log("Average Room: " + (totalTimeRooming / numberOfTimesRoomed));
    //  Debug.Log("Average Halling: " + (totalTimeHalling / numberOfTimesHalled));
    //  Debug.Log("Average Displaying: " + (totalTimeDisplaying / numberOfTimesDisplayed));
    //  Debug.Log("Average Total: " + (totalTimeTotaling / numberOfTimesTotaled));

    //}

  } // end Update

  private void DoThing()
  {
    float startTime = Time.realtimeSinceStartup;

    // Make new tree
    BinaryTree<RectInt> sampleRectTree;
    sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, levelWidth, levelHeight));

    #region Split Partitions
    bool split1 = true;

    for (int i = 0; i < numberOfSplits; i++)
    {
      List<BinaryTreeNode<RectInt>> leaves = new List<BinaryTreeNode<RectInt>>();
      CollectLeaves(sampleRectTree.Root(), leaves);

      foreach (BinaryTreeNode<RectInt> leaf in leaves)
      {

        if (split1)
        {
          SplitVertically(leaf);

        }

        if (!split1)
        {
          SplitHorizontally(leaf);

        }


      } // end for each

      split1 = !split1;


    } // end for loop

    //DisplayPartitions(sampleRectTree);

    #endregion

    float partitionTime = Time.realtimeSinceStartup;
    Debug.Log("Partition Creation Took: " + (totalTimePartitioning = (partitionTime - startTime)));
    numberOfTimesPartitioned++;


    #region Make Rooms
    List<BinaryTreeNode<RectInt>> leavesTwo = new List<BinaryTreeNode<RectInt>>();
    CollectLeaves(sampleRectTree.Root(), leavesTwo);

    foreach (BinaryTreeNode<RectInt> leafTwo in leavesTwo)
    {
      MakeRooms(leafTwo);

    }

    #endregion

    float roomTime = Time.realtimeSinceStartup;
    Debug.Log("Room Creation Took: " + (totalTimeRooming = (roomTime - partitionTime)));
    numberOfTimesRoomed++;

    #region Make Hallways
    // get the list of leafs
    // for each leaf check if its the left child then check if it has a right child
    // if both check out then get positions of the rooms on either side and get a midpoint to make a cross
    // 
    List<BinaryTreeNode<RectInt>> leavesForHalls = new List<BinaryTreeNode<RectInt>>();
    CollectLeaves(sampleRectTree.Root(), leavesForHalls);

    foreach (BinaryTreeNode<RectInt> leaf in leavesForHalls)
    {
      CheckToMakeHall(leaf);

    }

    #endregion

    float hallTime = Time.realtimeSinceStartup;
    Debug.Log("Hall Creation Took: " + (totalTimeHalling = (hallTime - roomTime)));
    numberOfTimesHalled++;

    DisplayRooms(sampleRectTree);

    float displayTime = Time.realtimeSinceStartup;
    Debug.Log("Displaying Took: " + (totalTimeDisplaying = (displayTime - hallTime)));
    numberOfTimesDisplayed++;

    Debug.Log("Total Time: " + (totalTimeTotaling = (totalTimePartitioning + totalTimeRooming + totalTimeHalling + totalTimeDisplaying)));
    numberOfTimesTotaled++;

    Debug.Log("Percentages: " +
      "\nPartition: " + ((totalTimePartitioning / totalTimeTotaling) * 100) + "%" +
      "\nRoom: " + ((totalTimeRooming / totalTimeTotaling) * 100) + "%" +
      "\nHall: " + ((totalTimeHalling / totalTimeTotaling) * 100) + "%" +
      "\nDisplay: " + ((totalTimeDisplaying / totalTimeTotaling) * 100) + "%"
      );

    Debug.Log("");

  }

  #region Display Stuff
  public void DisplayPartitions(BinaryTree<RectInt> node)
  {
    List<BinaryTreeNode<RectInt>> leaves = new List<BinaryTreeNode<RectInt>>();
    CollectLeaves(node.Root(), leaves);

    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    int[,] twoDim = new int[levelWidth, levelHeight];

    int currentLeaf = 0;

    foreach (BinaryTreeNode<RectInt> leaf in leaves)
    {
      currentLeaf++;

      RectInt leafWorld = NodeRectWorld(leaf);

      int currentX = leafWorld.x;
      int currentY = leafWorld.y;
      int currentWidth = leafWorld.width;
      int currentHeight = leafWorld.height;

      // for every width unit
      for (int w = 0; w < levelWidth; w++)
      {

        // and for ever hight unit
        for (int h = 0; h < levelHeight; h++)
        {

          // check if they width and hight equal the current X and Y
          if (w == currentX && h == currentY)
          {

            // go though the width and height of the leaf and put them in the value of the width plus the current
            for (int cW = 0; cW < currentWidth; cW++)
            {

              for (int cH = 0; cH < currentHeight; cH++)
              {

                twoDim[cW + currentX, cH + currentY] = currentLeaf;

              }

            }

          }

        }

      }

    }

    for (int w = 0; w < levelWidth; w++)
    {
      for (int h = 0; h < levelHeight; h++)
      {
        sb.Append(twoDim[w, h] + "\t");

      }

      sb.AppendLine();
      sb.AppendLine();

    }

    string content = sb.ToString();

    File.WriteAllText(typeOfDrive + ":\\School\\Game_Programming\\Project4_DungeonBSP\\Assets\\LangugeFile\\DisplayPartitions.bspd", content);

  }

  public void DisplayRooms(BinaryTree<RectInt> node)
  {
    List<BinaryTreeNode<RectInt>> roomLeaves = new List<BinaryTreeNode<RectInt>>();
    CollectLeaves(node.Root(), roomLeaves);

    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    string[,] twoDim = new string[levelWidth, levelHeight];

    for (int w = 0; w < levelWidth; w++)
    {

      for (int h = 0; h < levelHeight; h++)
      {
        twoDim[w, h] = "E\t";

      }
    }

    foreach (BinaryTreeNode<RectInt> leaf in roomLeaves)
    {
      RectInt leafWorld = NodeRectWorld(leaf);

      for (int i = 0; i < leafWorld.width; i++)
      {
        for (int j = 0; j < leafWorld.height; j++)
        {
          twoDim[leafWorld.x + i, leafWorld.y + j] = "F\t";

        }
      }
    }

    List<BinaryTreeNode<RectInt>> hallLeaves = new List<BinaryTreeNode<RectInt>>();
    CollectHalls(node.Root(), hallLeaves);

    foreach (BinaryTreeNode<RectInt> hall in hallLeaves)
    {
      RectInt hallWorld = NodeRectWorld(hall);

      for (int i = 0; i < hallWorld.width; i++)
      {
        for (int j = 0; j < hallWorld.height; j++)
        {
          twoDim[hallWorld.x + i, hallWorld.y + j] = "C\t";


        }
      }
    }

    #region Making Shit more Readable
    for (int i = 0; i < levelHeight; i++)
    {
      twoDim[0, i] = i + "\t";

    }

    for (int i = 0; i < levelWidth; i++)
    {
      twoDim[i, 0] = i + "\t";

    }

    twoDim[0, 0] = "O\t";
    twoDim[0, levelHeight - 1] = "Y\t";
    twoDim[levelWidth - 1, 0] = "X\t";

    #endregion

    for (int w = levelWidth - 1; w > -1; w--)
    {
      for (int h = 0; h < levelHeight; h++)
      {
        sb.Append(twoDim[h, w]);

      }

      sb.AppendLine();
      sb.AppendLine();

    }

    string content = sb.ToString();

    File.WriteAllText(typeOfDrive + ":\\School\\Game_Programming\\Project4_DungeonBSPRandomRoomSizes\\Assets\\LangugeFile\\DisplayBaseRooms.bspd", content);

  }

  #endregion

  #region Splitting
  private void SplitVertically(BinaryTreeNode<RectInt> node)
  {
    // if it can be randomized
    if (node.Value().width > 5)
    {
      int partitionWidth = UnityEngine.Random.Range(5, node.Value().width - 5);
      int partitionHeight = node.Value().height;

      RectInt leftPartition = new RectInt(0, 0, partitionWidth, partitionHeight);
      RectInt rightPartition = new RectInt(partitionWidth, 0, node.Value().width - partitionWidth, partitionHeight);

      node.AddChild(leftPartition);
      node.AddChild(rightPartition);

    }

    // if it cant be randomized
    else
    {
      Debug.Log("Partition isnt big enough for random");

      int partitionWidth = node.Value().width / 2;
      int partitionHeight = node.Value().height;

      RectInt leftPartition = new RectInt(0, 0, partitionWidth, partitionHeight);

      RectInt rightPartition = new RectInt(partitionWidth, 0, node.Value().width - partitionWidth, partitionHeight);

      node.AddChild(leftPartition);
      node.AddChild(rightPartition);
    }

  }

  private void SplitHorizontally(BinaryTreeNode<RectInt> node)
  {
    // if it can be randomized
    if (node.Value().height > 5)
    {
      int partitionWidth = node.Value().width;
      int partitionHeight = UnityEngine.Random.Range(5, node.Value().height - 5);

      RectInt bottomPartition = new RectInt(0, 0, partitionWidth, partitionHeight);
      RectInt topPartition = new RectInt(0, partitionHeight, partitionWidth, node.Value().height - partitionHeight);

      node.AddChild(bottomPartition);
      node.AddChild(topPartition);

    }

    // cant be randomized
    else
    {
      Debug.Log("Partition isnt big enough for random");

      int partitionWidth = node.Value().width;
      int partitionHeight = node.Value().height / 2;

      RectInt bottomPartition = new RectInt(0, 0, partitionWidth, partitionHeight);
      RectInt topPartition = new RectInt(0, partitionHeight, partitionWidth, node.Value().height - partitionHeight);

      node.AddChild(bottomPartition);
      node.AddChild(topPartition);

    }
  }

  #endregion

  #region Making Room
  private void MakeRooms(BinaryTreeNode<RectInt> node)
  {
    //if (node.Value().width > 4 && node.Value().height > 4)
    //{
    int roomWidth = node.Value().width - 2;
    int roomHeight = node.Value().height - 2;

    RectInt room = new RectInt(1, 1, roomWidth, roomHeight);

    node.AddChild(room);

    //}
  }

  #endregion

  #region Making Halls
  /** CheckToMakeHall: Done
   * This will accept a node and it will check if it has the base requirements to make a hallway to each other 
   */
  public void CheckToMakeHall(BinaryTreeNode<RectInt> node)
  {
    if (node.parent != null && node == node.parent.leftChild)
    {
      if (node.parent.rightChild != null)
      {
        ConnectRooms(node.parent);
        CheckToMakeHall(node.parent);

      }

      else
      {
        CheckToMakeHall(node.parent);

      }
    }
  }

  /** ConnectRooms: Work in progress
   */
  public void ConnectRooms(BinaryTreeNode<RectInt> partition)
  {
    // set up list for each set of rooms
    List<BinaryTreeNode<RectInt>> roomsOfLeftChild = new List<BinaryTreeNode<RectInt>>();
    List<BinaryTreeNode<RectInt>> roomsOfRightChild = new List<BinaryTreeNode<RectInt>>();

    CollectLeaves(partition.leftChild, roomsOfLeftChild);
    CollectLeaves(partition.rightChild, roomsOfRightChild);

    List<RectInt> partitionLeftRooms = new List<RectInt>();
    foreach (BinaryTreeNode<RectInt> leaf in roomsOfLeftChild)
    {
      partitionLeftRooms.Add(NodeRectNode(leaf, partition));

    }

    List<RectInt> partitionRightRooms = new List<RectInt>();
    foreach (BinaryTreeNode<RectInt> leaf in roomsOfRightChild)
    {
      partitionRightRooms.Add(NodeRectNode(leaf, partition));

    }

    RectInt hallRoom = GetHallRectInt(partitionLeftRooms, partitionRightRooms);

    partition.AddHallway(hallRoom);

  }

  private RectInt GetHallRectInt(List<RectInt> leftRooms, List<RectInt> rightRooms)
  {
    #region Make list of individual spaces
    // Make a list of left rooms
    List<Vector2> leftSpaces = new List<Vector2>();

    foreach (RectInt leftRoom in leftRooms)
    {
      for (int i = 0; i < leftRoom.width; i++)
      {
        for (int j = 0; j < leftRoom.height; j++)
        {
          if ((i == 0 || i == leftRoom.width - 1) || (j == 0 || j == leftRoom.height - 1))
          {
            leftSpaces.Add(new Vector2(leftRoom.x + i, leftRoom.y + j));

          }
        }
      }
    }

    Debug.Log("Left Spaces");
    V2ListToText(leftSpaces);

    // Make a list of right room spaces
    List<Vector2> rightSpaces = new List<Vector2>();

    foreach (RectInt rightRoom in rightRooms)
    {
      for (int i = 0; i < rightRoom.width; i++)
      {
        for (int j = 0; j < rightRoom.height; j++)
        {
          if ((i == 0 || i == rightRoom.width - 1) || (j == 0 || j == rightRoom.height - 1))
          {
            rightSpaces.Add(new Vector2(rightRoom.x + i, rightRoom.y + j));

          }
        }
      }
    }

    Debug.Log("Right Spaces");
    V2ListToText(rightSpaces);


    #endregion

    #region Get new list of connections
    // make a list of rooms that are in a straight line 
    List<Vector2> connectionPoints = new List<Vector2>();

    bool connectOnX = false;
    bool connectOnY = false;

    // main connections will be what the hall must connect on
    List<int> mainConnections = new List<int>();

    // cross are the points of the room on each main connection line
    List<int> crossConnections = new List<int>();

    /** Example:
     * if you have a 2 by 2 room at 1,1 and a 2 by 2 room at 1, 5
     * main connections will be 1 and 2
     * cross connections will be 1, 2, 5, 6;
    */

    foreach (Vector2 leftSpace in leftSpaces)
    {
      foreach (Vector2 rightSpace in rightSpaces)
      {
        if (leftSpace.x == rightSpace.x)
        {
          connectOnX = true;
          connectionPoints.Add(leftSpace); connectionPoints.Add(rightSpace);
          mainConnections.Add(Convert.ToInt32(rightSpace.x));

          crossConnections.Add(Convert.ToInt32(leftSpace.y));
          crossConnections.Add(Convert.ToInt32(rightSpace.y));

        }

        if (leftSpace.y == rightSpace.y)
        {
          connectOnY = true;
          connectionPoints.Add(leftSpace); connectionPoints.Add(rightSpace);
          mainConnections.Add(Convert.ToInt32(rightSpace.y));

          crossConnections.Add(Convert.ToInt32(leftSpace.x));
          crossConnections.Add(Convert.ToInt32(rightSpace.x));

        }
      }
    }

    #endregion

    #region Removing Duplicates and sorting lists
    // remove any duplicates
    List<Vector2> tempConnectionPoints = connectionPoints.Distinct().ToList();
    connectionPoints = tempConnectionPoints;

    List<int> tempMainConnections = mainConnections.Distinct().ToList();
    mainConnections = tempMainConnections;
    mainConnections.Sort();

    List<int> tempCrossConnections = crossConnections.Distinct().ToList();
    crossConnections = tempCrossConnections;
    crossConnections.Sort();

    #endregion

    #region Checking for border and removing board if possible
    bool switchOutList = false;

    List<int> noBoarders = new List<int>();

    foreach (int connection in mainConnections)
    {
      if (mainConnections.Contains(connection - 1) && mainConnections.Contains(connection + 1))
      {
        switchOutList = true;
        noBoarders.Add(connection);

      }
    }

    if (switchOutList)
    {
      mainConnections = noBoarders;

    }

    int singleMainConnection = GetRandomFromIntList(mainConnections);

    #endregion

    #region Getting cross hall start and end
    int[] crossArray = crossConnections.ToArray();

    int currentMinIndex = 0;
    int currentMaxIndex = crossArray.Length - 1;

    int hallMinCross = -1;
    int hallMaxCross = -1;

    //IntArrayToText(crossArray);

    while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
    {
      hallMinCross = -1;
      hallMaxCross = -1;

      while (hallMinCross == -1)
      {
        int current = crossArray[currentMinIndex];
        int next = crossArray[currentMinIndex + 1];

        //Debug.Log("Current Min Value End: " + current);
        //Debug.Log("Current Min Index End: " + currentMinIndex);

        if (current + 1 == next)
        {
          currentMinIndex++;

        }

        else
        {
          hallMinCross = current + 1;

        }
      }

      //Debug.Log("");

      while (hallMaxCross == -1)
      {
        int current = crossArray[currentMaxIndex];
        int next = crossArray[currentMaxIndex - 1];

        //Debug.Log("Current Max Value End: " + current);
        //Debug.Log("Current Max Index End: " + currentMaxIndex);

        if (current - 1 == next)
        {
          currentMaxIndex--;

        }

        else
        {
          hallMaxCross = current - 1;

        }
      }
      

      //Debug.Log("Current Min Index: " + currentMinIndex);
      //Debug.Log("Current Max Index: " + currentMaxIndex);

      if (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        //Debug.Log("reducing Index");

        currentMinIndex++;
        currentMaxIndex--;

      }
    }

    Debug.Log("Output: \nHall Min Cross: " + hallMinCross + "\nHall Max Cross: " + hallMaxCross);

    #endregion

    #region Get hall length
    int hallLength = 0;
    int currentCross = hallMinCross;

    while (currentCross <= hallMaxCross)
    {
      currentCross++;
      hallLength++;

    }

    #endregion

    #region Set RectInt
    RectInt hallConnection = new RectInt(0,0,0,0);

    if (connectOnX)
    {
      hallConnection = new RectInt(singleMainConnection, hallMinCross, 1, hallLength);

    }

    if (connectOnY)
    {
      hallConnection = new RectInt(hallMinCross, singleMainConnection, hallLength, 1);

    }

    return hallConnection;

    #endregion

  } // end GetPossibleConnections

  private void CheckMatching(List<int> listOverlap, List<int> listOne, List<int> listTwo)
  {

    foreach (int listOneNumber in listOne)
    {
      foreach (int listTwoNumber in listTwo)
      {
        if (listOneNumber == listTwoNumber)
        {
          listOverlap.Add(listOneNumber);

        }
      }
    }
  }

  #endregion

  #region Stuff with RectInt
  private void CollectLeaves(BinaryTreeNode<RectInt> currentNode, List<BinaryTreeNode<RectInt>> leaves)
  {
    if (currentNode == null) return;

    // Piratical exit case: current node == leaf node.
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

  private void CollectHalls(BinaryTreeNode<RectInt> currentNode, List<BinaryTreeNode<RectInt>> halls)
  {
    if (currentNode == null) return;

    if (currentNode.HasHall())
    {
      halls.Add(currentNode.hallChild);
      CollectHalls(currentNode.leftChild, halls);
      CollectHalls(currentNode.rightChild, halls);


    }

    else
    {
      CollectHalls(currentNode.leftChild, halls);
      CollectHalls(currentNode.rightChild, halls);

    }

  }

  private RectInt NodeRectWorld(BinaryTreeNode<RectInt> node)
  {
    BinaryTreeNode<RectInt> current = node;
    RectInt rectWorld = node.Value();

    rectWorld.x = 0;
    rectWorld.y = 0;

    while (current != null)
    {
      rectWorld.x += current.Value().x;
      rectWorld.y += current.Value().y;

      current = current.parent;

    }

    return rectWorld;

  } // end RectInt

  private RectInt NodeRectNode(BinaryTreeNode<RectInt> room, BinaryTreeNode<RectInt> partition)
  {
    BinaryTreeNode<RectInt> current = room;
    RectInt rectNode = room.Value();

    rectNode.x = 0;
    rectNode.y = 0;

    while (current != partition)
    {
      rectNode.x += current.Value().x;
      rectNode.y += current.Value().y;


      current = current.parent;

    }

    return rectNode;

  }

  #endregion

  #region Other Methods
  private void IntListToText(List<int> list)
  {
    string listString = "";

    foreach (int listNumber in list)
    {
      listString += listNumber.ToString() + " ";

    }

    Debug.Log(listString);

  }

  private void RectIntListToText(List<RectInt> list)
  {
    string listString = "";

    foreach (RectInt listNumber in list)
    {
      listString += listNumber.ToString() + "\n";

    }

    Debug.Log(listString);
  }

  private void V2ListToText(List<Vector2> list)
  {
    string listString = "";

    foreach (var listEle in list)
    {
      listString += listEle.ToString() + " ";

    }

    Debug.Log(listString);

  }

  private void IntArrayToText(int[] array)
  {
    string arrayString = "";

    for (int i = 0; i < array.Length; i++)
    {
      arrayString += array[i] + " ";

    }

    Debug.Log(arrayString);

  }

  private int GetRandomFromIntList(List<int> intList)
  {
    int[] array = intList.ToArray();

    return array[UnityEngine.Random.Range(0, array.Length)];

  }

  #endregion

}