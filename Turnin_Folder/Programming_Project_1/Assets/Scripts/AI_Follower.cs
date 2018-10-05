using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Follower : MonoBehaviour
{
  public GameObject charecterPosition;

  public LayerMask playerLayer;

  public float speed = 5;

  public float rayDistanceLookAt = 10.0F;
  public float rayDistanceFollow = 4.0F;
  public float rayDistanceStop = 2.0F;

  private Vector3 rayCollisionNormal;
  private Vector3 hitLocationThisFrame = Vector3.zero;
  private bool hitThisFrame = false;

	// Update is called once per frame
	void Update ()
  {
    hitThisFrame = false;

    RaycastHit hitInfo;
    if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistanceLookAt, playerLayer.value))
    {
      transform.LookAt(charecterPosition.transform);

    }

    if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistanceStop, playerLayer.value))
    {

    }

    else if (Physics.Raycast(transform.position,transform.forward, out hitInfo, rayDistanceFollow, playerLayer.value))
    {
      Vector3 moveDirection = Vector3.zero;

      moveDirection += transform.forward;

      transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }

  } // end update

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistanceLookAt);

  }

} // end class
