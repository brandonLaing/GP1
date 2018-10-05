using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnCollisionEnter(Collision collision)
  {
    Collider otherCollider = collision.collider;
    GameObject otherObject = collision.gameObject;
    Transform otherTransform = collision.transform;
    Rigidbody otherRigidbody = collision.rigidbody;

    //print("Object " + transform.name + " collided with " + collision.gameObject.name);

    if (otherObject.tag == "Special")
    {
      print( "Object " + transform.name + " was hit by something special");

    }
  }


}
