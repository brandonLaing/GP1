using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    public float moveSpeed = 3.0f;
  public bool canMove = true;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.tag == "Obstacle")
    {
      canMove = false;

    }
  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.transform.tag == "Obstacle")
    {
      canMove = true;

    }
  }
}
