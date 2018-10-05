using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
  public int healthToAdd;

  private void Update()
  {
    Debug.Log("FIX THIS CODE THEN DELETE THE UPDATE");

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      //other.GetComponent<PlayerController>().health += healthToAdd;
      this.gameObject.GetComponent<SendInfoToStation>().SendMessage();


    }
  }
}