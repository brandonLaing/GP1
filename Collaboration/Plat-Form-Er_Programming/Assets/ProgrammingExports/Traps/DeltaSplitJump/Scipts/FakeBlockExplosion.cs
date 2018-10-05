using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlockExplosion : MonoBehaviour
{
  public float upVelocity = 510;
  public float outwardVelocity = 2;

  private void Awake()
  {
    Rigidbody playerRigidbody = gameObject.GetComponent<Rigidbody>();

    playerRigidbody.AddForce(Random.Range(-outwardVelocity, outwardVelocity), upVelocity, 0);

  }
}
