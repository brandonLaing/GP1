using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGettingCrossHall : MonoBehaviour
{
  public int[] crossArrayOne;
  public int[] crossArrayTwo;

	void Update ()
  {
    if (Input.GetKeyDown(KeyCode.Alpha0))
    {
      DoThing(crossArrayOne);

    }

    if (Input.GetKeyDown(KeyCode.Alpha9))
    {
      DoThing(crossArrayTwo);

    }
  }

  private void DoThing(int[] array)
  {
    #region Getting cross hall start and end
    //int[] crossArray = crossConnections.ToArray();

    int currentMinIndex = 0;
    int currentMaxIndex = array.Length - 1;

    int hallMinCross = -1;
    int hallMaxCross = -1;

    bool reduceSwitch = true;

    while (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
    {
      hallMinCross = -1;

      while (hallMinCross == -1)
      {
        int current = array[currentMinIndex];
        int next = array[currentMinIndex + 1];

        Debug.Log("Current Min Index: " + currentMinIndex);
        Debug.Log("Current Min Value: " + current);

        if (current + 1 == next)
        {
          currentMinIndex++;

        }

        else
        {
          hallMinCross = current + 1;

        }
      }

      Debug.Log("");
      if (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        while (hallMaxCross == -1)
        {
          int current = array[currentMaxIndex];
          int next = array[currentMaxIndex - 1];

          Debug.Log("Current Max Index: " + currentMaxIndex);
          Debug.Log("Current Max Value: " + current);

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

      Debug.Log("Current Min Index: " + currentMinIndex);
      Debug.Log("Current Max Index: " + currentMaxIndex);

      if (currentMinIndex != currentMaxIndex - 1 && currentMaxIndex != currentMinIndex + 1)
      {
        hallMaxCross = -1;

        Debug.Log("reducing Index");
        if (reduceSwitch)
        {
          currentMinIndex++;

        }

        else
        {
          currentMaxIndex--;
        }

      }

      reduceSwitch = !reduceSwitch;
    }

    Debug.Log("Output: \nHall Min Cross: " + hallMinCross + "\nHall Max Cross: " + hallMaxCross);

    #endregion

  }
}
