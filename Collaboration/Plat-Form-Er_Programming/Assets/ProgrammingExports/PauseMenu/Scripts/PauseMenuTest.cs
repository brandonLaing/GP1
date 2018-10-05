using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuTest : MonoBehaviour
{
  private void Update()
  {
    if (this.gameObject.transform.position.y < -20)
    {
      transform.position = new Vector3(0, 20, 0);
      GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(0, -101),0);
    }

    if (transform.position.x < -10 || transform.position.x > 10)
    {
      transform.position = new Vector3(0, transform.position.y, transform.position.z);

    }

    if (transform.position.z != 0)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
  }
}
