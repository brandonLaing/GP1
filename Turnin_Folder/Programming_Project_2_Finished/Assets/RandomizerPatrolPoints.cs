using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class RandomizerPatrolPoints : MonoBehaviour {

  GameObject[] patrolPoints;
  GameObject currentPoint;

  public Transform maxX;
  public Transform maxY;
  public Transform minX;
  public Transform minY;


	// Use this for initialization
	void Start ()
  {
    patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoints");

		for (int i = 0; i < patrolPoints.Length; i++)
    {
      currentPoint = patrolPoints[i];
      currentPoint.transform.position =
        new Vector3(Random.Range(minX.position.x, maxX.position.x), 0, Random.Range(minY.position.z, maxY.position.z));

    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
