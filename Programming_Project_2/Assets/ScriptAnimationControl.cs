using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimationControl : MonoBehaviour {

    public bool isCharecterMoving;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (isCharecterMoving)
        {
            myAnimator.SetBool("IsMoving", true);

        }

        else
        {
            myAnimator.SetBool("IsMoving", false);

        }
	}
}
