using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
  {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
		
	}

  public void Move(Vector3 moveDirection)
  {
    transform.LookAt(moveDirection);

    transform.position += moveDirection;
  }
}
