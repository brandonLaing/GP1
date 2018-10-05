using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerColiderDetection : MonoBehaviour {

  public GameObject self;
  public GameObject player;

	// Use this for initialization
	void Start ()
  {
    Destroy(self, 10);

	}

  private void OnCollisionEnter(Collision collision)
  {

    if (collision.collider.tag != "Enemy" && collision.collider.tag != "Laser")
    {
      Destroy(self);

    }
  }
}
