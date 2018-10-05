using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerEnemySpawnPoints : MonoBehaviour {

  public GameObject currentPoint;

  public GameObject enemies;

  public int numOfEnemies = 2;

  public Transform maxX;
  public Transform minX;
  public Transform maxZ;
  public Transform minZ;

	// Use this for initialization
	void Start () {

    for (int i = 0; i < numOfEnemies; i++)
    {
      currentPoint.transform.position =
        new Vector3(Random.Range(minX.position.x, maxX.position.x), 10, Random.Range(minZ.position.z, maxZ.position.z));

      Instantiate(enemies, currentPoint.transform.position, Quaternion.identity);

    }


  }

  // Update is called once per frame
  void Update () {
		
	}
}
