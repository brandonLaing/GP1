using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
  public int ammoToAdd;

  private void Update()
  {
    Debug.Log("FIX THIS CODE THEN DELETE THE UPDATE");

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      //other.GetComponent<PlayerPrefs>().ammo += ammoToAdd;
      this.gameObject.GetComponent<SendInfoToStation>().SendMessage();


    }
  }
}