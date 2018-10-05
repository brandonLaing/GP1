using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCubeMassBySize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 localScale = transform.localScale;
        GetComponent<Rigidbody>().mass = localScale.x * localScale.y * localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
