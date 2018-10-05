using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** TODO:
 * Set Max and min Rotations on barrel
 * Fix Rotation
 */

public class TurretControl : MonoBehaviour {


    public float minBarrelElevation = 15.0f;
    public float maxBarrelElevation = 75.0f;

    public Transform barrelPivotPoint;
    public Transform barrelMouth;

    public GameObject shellPrefab;

    public float shellForce = 1000;

    public float turretRotationRate = 90f;
    public float barrelRotationRate = 30f;

  private float lastFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
      transform.Rotate(Vector3.up * Time.deltaTime * -turretRotationRate, Space.World);

    }

    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
      transform.Rotate(Vector3.up * Time.deltaTime * turretRotationRate, Space.World);

    }

    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
    {
      barrelPivotPoint.transform.Rotate(Vector3.right * Time.deltaTime * barrelRotationRate);

    }

    if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
    {
      barrelPivotPoint.transform.Rotate(Vector3.right * Time.deltaTime * -barrelRotationRate);

    }

    Vector3 clampedRotation = barrelPivotPoint.transform.eulerAngles;

    clampedRotation.x = Mathf.Clamp(clampedRotation.x, minBarrelElevation, maxBarrelElevation);

    barrelPivotPoint.transform.rotation = Quaternion.Euler(clampedRotation);


    if (Input.GetKey(KeyCode.Space))
    {
      if (lastFire <= Time.time)
      {
        lastFire = Time.time + .5F;

        var shell = (GameObject)Instantiate(shellPrefab, barrelMouth.position, barrelMouth.rotation);

        shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * shellForce;

      }

    }






    }

}
