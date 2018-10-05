using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCube : MonoBehaviour
{
  public GameObject splitblock;

  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log("Split Cube collided with: " + collision.transform.name);

    if (collision.transform.tag == "Player")
    {
      Debug.Log("making split block");

      Instantiate(splitblock, transform.position, transform.rotation);

      Debug.Log("Destroying: " + gameObject.transform.name);  

      Destroy(gameObject);

    }
  }
}
