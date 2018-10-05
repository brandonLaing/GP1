using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_00 : MonoBehaviour {

  public KinematicCore controlledAI;

	// Use this for initialization
	void Start ()
  {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
		if (Input.GetMouseButtonDown(0))
    {
      RaycastHit hitInfo;
      if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
      {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
          controlledAI.Flee(hitInfo.point);

        } 

        else
        {
          controlledAI.Seek(hitInfo.point);

        }
      } // if raycast

    } // end if mouse 0 down

	} // end update

} // end class
