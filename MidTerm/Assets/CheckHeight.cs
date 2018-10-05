using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeight : MonoBehaviour {

  public bool destuctablesColliding;

  public int numberOfObjects;

  private void Update()
  {
    if (numberOfObjects > 0)
    {
      destuctablesColliding = true;

    }

    else
    {
      destuctablesColliding = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Destructibles")
    {
      numberOfObjects++;

    }

  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Destructibles")
    {
      numberOfObjects--;

    }

  }

}
