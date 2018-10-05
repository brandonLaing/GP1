using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTestingCharecter : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
  {
		if (Input.GetKey(KeyCode.W))
    {
      gameObject.transform.position += new Vector3(0, 0, .1F);

    }

    if (Input.GetKey(KeyCode.S))
    {
      gameObject.transform.position += new Vector3(0, 0, -.1F);

    }

    if (Input.GetKey(KeyCode.A))
    {
      gameObject.transform.position += new Vector3(-.1F, 0, 0);

    }

    if (Input.GetKey(KeyCode.D))
    {
      gameObject.transform.position += new Vector3(.1F, 0, 0);

    }

  }
}
