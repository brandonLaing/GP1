using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMapCreator : MonoBehaviour
{
  // number of rooms there will be
  public int numberOfPartitions;

  // set height and width
  public int mapWidth;
  public int mapHeight;

  public int[,] map;

  public int partitionWidth;
  public int partitionHeight;

  public int roomWidth;
  public int roomHeight;

  public int partition0X;
  public int partition0Y;

  public int partition1X;
  public int partition1Y;

  public int room0X;
  public int room0Y;

  public int room1X;
  public int room1Y;



  public void Start()
  {
    map = new int[mapWidth - 1, mapHeight - 1];

    // split for number of rooms
    Split();

    MakeRooms();

    ConnectRooms();

    DisplayRooms();
    

  } // end Start

  /** Split Does
   * Makes the size of the partition Width and Height based on the map width and height
   * Stores the bottom left position of each partition
   */
  public void Split()
  {
    // set partition width and height
    partitionWidth = mapWidth / numberOfPartitions;
    partitionHeight = mapHeight;

    // set first partition x and y
    partition0X = 0;
    partition0Y = 0;

    // set second partition x and y
    partition1X = partition0X + partitionWidth;
    partition1Y = 0;


  } // end Split

  /** MakeRooms Does
   * Makes the size for the room based on the partition width and height
   * Finds and stores the bottom left spot based on the partition its in
   */
  public void MakeRooms()
  {
    // set room width and height
    roomWidth = partitionWidth - 2;
    roomHeight = partitionHeight - 2;

    // set first room x and y
    room0X = partition0X + 1;
    room0Y = partition0Y + 1;

    // set second room x and y
    room1X = partition1X + 1;
    room1Y = partition1Y + 1;

  } // end MakeRooms

  /** ConnectRooms
   * Makes a coridor from one room to another
   */
  public void ConnectRooms()
  {

  } // end ConnectRooms

  public void DisplayRooms()
  {
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    string[,] twoDim = new string[mapWidth, mapHeight];

    for (int j = 0; j < mapHeight - 1; j++)
    {
      for (int i = 0; i < mapWidth - 1; i++)
      {
        // if the i and j equals the partion origin set each box in its height and with to 0
        if (partition0X == i && partition0Y == j)
        {
          for (int h = 0; h < mapHeight; h++)
          {
            for (int w = 0; w < partitionWidth; w++)
            {
              twoDim[h, w] = "0";

            } // end H

          } // end W

        } // end partition0

        // if the i and j equals the partion origin set each box in its height and with to 1
        if (partition1X == i && partition1Y == j)
        {
          for (int h = 0; h < mapHeight; h++)
          {
            for (int w = 0; w < partitionWidth; w++)
            {
              twoDim[h, w + 10] = "1";


            } // end H

          } // end W

        } // end partition1

      } // end J

    } // end I

    for (int i = 0; i < mapHeight; i++)
    {
      for (int j = 0; j < mapWidth; j++)
      {
        sb.Append(twoDim[i, j]);

      }

      sb.AppendLine();

    }

    Debug.Log(sb.ToString());

  } // end DisplayRooms

  // Things i tried not sure why it didnt work and not sure how to do it so im starting over
  /** public void MakeRooms()
  {
    room0 = new int[roomWidth, roomHeight];
    room1 = new int[roomWidth, roomHeight];

    for (int i = 0; i <= roomWidth - 1; i++)
    {
      if (i != 0 || i != 9)
      {
        for (int j = 0; j <= roomHeight - 1; j++)
        {

          if (j != 0 || j != 19)
          {
            room0[i, j] = partition0[i, j];

          }

        }

      }

    }

    for (int i = 0; i < roomWidth; i++)
    {
      if (i < 10 || i == 19)
      {
        for (int j = 0; j < roomHeight; j++)
        {
          if (j != 0 || j != 19)
          {
            room1[i, j] = partition1[i, j];

          }

        }
      }
    }
  } // end MakeRooms
  */
  /** public void ConnectRooms()
  {
    hall[9, 10] = partition0[10, 9];
    hall[10, 10] = partition1[10, 10];

  } // end ConnectRooms
  */
  /** public void DisplayRoom()
  {
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    string[,] twoDim = new string[20, 20];

    for (int i = 0; i < 20; i++)
    {
      for (int j = 0; j < 20; j++)
      {
        if (i != 0 || i != 9 || i != 10 || i != 19)
        {
          twoDim[i,j] = "R";

        }
        else
        {
          twoDim[i, j] = "E";

        }

        if (j == 0 || j == 19)
        {
          twoDim[i, j] = "E";

        }

        if ((i == 9 && j == 9) || (i == 10 && j == 9))
        {
          twoDim[i, j] = "C";

        }

      }
    }
  }
  */
  /** Steve way
  public void SteveDisplayRooms()
  {
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    string[,] twoDim = new string[8, 8];
    for (int i = 0; i < 8; i++)
    {
      for (int j = 0; j < 8; j++)
      {
        if (j == 0 || j == 7)
        {
          twoDim[i, j] = "X";

        }
        else
        {
          twoDim[i, j] = "O";

        }
      }
    }

    for (int i = 0; i < 8; i++)
    {
      for (int j = 0; j < 8; j++)
      {
        sb.Append(twoDim[i, j]);

      }
      sb.AppendLine();

    }
    print(sb.ToString());

  }
  */
  /** public void OldSplit(int rooms)
  {
    partition0 = new int[partitionWidth, partitionHeight];
    partition1 = new int[partitionWidth, partitionHeight];

    for (int i = 0; i <= partitionWidth - 1; i++)
    {
      for (int j = 0; j <= partitionHeight - 1; j++)
      {
        if (i < 10)
        {
          partition0[i, j] = map[i, j];

        }

        if (i >= 10)
          partition1[i, j] = map[i, j];

      }

    }

  } // end Split
  */

} // end Class
