using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRaycast : MonoBehaviour {

  public LayerMask raycastLayers;
  public LayerMask raycastFloor;

  public float rayDistance = 3.0f;

  private Vector3 rayCollisionNormal;
  private Vector3 hitLocationThisFrame = Vector3.zero;
  private bool hitThisFrame = false;
	
	// Update is called once per frame
	void Update ()
  {
    hitThisFrame = false;
     
    RaycastHit hitInfo;
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, raycastLayers.value))
    {
      Debug.Log("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
      hitLocationThisFrame = hitInfo.point;
      rayCollisionNormal = hitInfo.normal;
      hitThisFrame = true;

    }

    if (Input.GetMouseButton(0))
    {
      Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(intoScreen, out hitInfo, 1000, raycastFloor))
      {
        transform.position = hitInfo.point + new Vector3(0, 1, 0);

      }

    }

	}

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);

    if (hitThisFrame)
    {
      Gizmos.color = Color.blue;
      Gizmos.DrawLine(hitLocationThisFrame, hitLocationThisFrame + rayCollisionNormal);

    }

  }
}
