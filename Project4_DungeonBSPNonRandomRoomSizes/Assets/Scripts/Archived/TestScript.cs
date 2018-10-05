using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
  public int currentMinIndex;
  public int currentMaxIndex;

  public int hallMinCross;
  public int hallMaxCross;

  public int[] arrayOne = new int[4];
  public int[] arrayTwo = new int[12];
  public int[] arrayThree = new int[8];
  public int[] arrayFour = new int[4];
  public int[] arrayFive = new int[4];
  public int[] arraySix = new int[12];
  public int[] arraySeven = new int[4];

  private void Update()
  {
    // Array One
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      currentMinIndex = 0;
      currentMaxIndex = arrayOne.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex -1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arrayOne[currentMinIndex];
          int next = arrayOne[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arrayOne[currentMaxIndex];
          int next = arrayOne[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

    // Array Two
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      currentMinIndex = 0;
      currentMaxIndex = arrayTwo.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arrayTwo[currentMinIndex];
          int next = arrayTwo[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arrayTwo[currentMaxIndex];
          int next = arrayTwo[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

    // Array Three
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      currentMinIndex = 0;
      currentMaxIndex = arrayThree.Length - 1;


      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        hallMinCross = -1;
        hallMaxCross = -1;

        while (hallMinCross == -1)
        {
          int current = arrayThree[currentMinIndex];
          int next = arrayThree[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arrayThree[currentMaxIndex];
          int next = arrayThree[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }

        if (currentMinIndex != currentMaxIndex -1 && currentMaxIndex != currentMinIndex + 1)
        {
          currentMinIndex++;
          currentMaxIndex--;

        }

      }
    }

    // Array Four
    if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      currentMinIndex = 0;
      currentMaxIndex = arrayFour.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arrayFour[currentMinIndex];
          int next = arrayFour[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arrayFour[currentMaxIndex];
          int next = arrayFour[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

    // Array Five
    if (Input.GetKeyDown(KeyCode.Alpha5))
    {
      currentMinIndex = 0;
      currentMaxIndex = arrayFive.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arrayFive[currentMinIndex];
          int next = arrayFive[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arrayFive[currentMaxIndex];
          int next = arrayFive[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

    // Array Six
    if (Input.GetKeyDown(KeyCode.Alpha6))
    {
      currentMinIndex = 0;
      currentMaxIndex = arraySix.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arraySix[currentMinIndex];
          int next = arraySix[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arraySix[currentMaxIndex];
          int next = arraySix[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

    // Array Seven
    if (Input.GetKeyDown(KeyCode.Alpha7))
    {
      currentMinIndex = 0;
      currentMaxIndex = arraySeven.Length - 1;

      hallMinCross = -1;
      hallMaxCross = -1;

      while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMinCross == -1)
        {
          int current = arraySeven[currentMinIndex];
          int next = arraySeven[currentMinIndex + 1];

          if (current + 1 == next)
          {
            currentMinIndex++;

          }

          else
          {
            hallMinCross = current + 1;

          }

        }

        while (hallMaxCross == -1)
        {
          int current = arraySeven[currentMaxIndex];
          int next = arraySeven[currentMaxIndex - 1];

          if (current - 1 == next)
          {
            currentMaxIndex--;

          }

          else
          {
            hallMaxCross = current - 1;
          }
        }
      }
    }

  }
}

/**
    #region Getting cross hall start and end
    int[] crossArray = crossConnections.ToArray();
    Debug.Log("Starting Array");
    IntArrayToText(crossArray);

    int currentMinIndex = 0;
    Debug.Log("Start Min Index: " + currentMinIndex);
 
    int currentMaxIndex = crossArray.Length - 1;
    Debug.Log("Start Max Index: " + currentMaxIndex);

    int hallMinCross = -1;
    int hallMaxCross = -1;

    while (currentminindex != currentmaxindex - 1 && currentmaxindex != currentminindex + 1)
    {
      hallMinCross = -1;
      hallMaxCross = -1;
      
      while (hallMinCross == -1)
      {
        int current = crossArray[currentMinIndex];
        int next = crossArray[currentMinIndex + 1];

        if (next == current + 1)
        {
          currentMinIndex++;

        }

        else
        {
          hallMinCross = current + 1;

        }
      }


      while (hallMaxCross == -1)
      {
        int current = crossArray[currentMaxIndex];
        int next = crossArray[currentMaxIndex - 1];

        if (next == current - 1)
        {
          currentMaxIndex--;

        }

        else
        {
          hallMaxCross = current - 1;

        }
      }
      Debug.Log("Min index: " + currentMinIndex);
      Debug.Log("Max index: " + currentMaxIndex);

      if (currentMinIndex == currentMaxIndex - 1 && currentMaxIndex == currentMinIndex + 1)
      {
        Debug.Log("Would End here");

      }

    }
    #endregion

 */