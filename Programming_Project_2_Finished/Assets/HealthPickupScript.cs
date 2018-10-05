using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour {

  public GameObject healthKit;
  public GameObject currentHealthKit;
  public Transform healthKitPosition;

  public float healthKitCooldown;
  public float healthKitTimer;
	
	// Update is called once per frame
	void Update () {


    if (currentHealthKit == null)
    {

      if (healthKitTimer < Time.time)
      {
        healthKitTimer = Time.time + healthKitCooldown;

        currentHealthKit = Instantiate(healthKit, healthKitPosition.position, Quaternion.identity);

      }
    }
  }
}
