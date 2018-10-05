using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
  public int enemiesLeft = 0;

  public Text enemiesLeftDisplay;

  public GameObject winBall;

  // Update is called once per frame
  void Update ()
  {
    if (enemiesLeft < 1)
    {
      if (winBall != null)
      {
        winBall.SetActive(true);
      }
    }

    enemiesLeftDisplay.text = "Enemies Left: " + enemiesLeft;

  }

}
