using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{

  public GameObject ammoKit;
  public GameObject currentAmmoKit;
  public Transform ammoKitPosition;

  public float ammoKitCooldown;
  public float ammoKitTimer;

  // Update is called once per frame
  void Update()
  {


    if (currentAmmoKit == null)
    {

      if (ammoKitTimer < Time.time)
      {
        ammoKitTimer = Time.time + ammoKitCooldown;

        currentAmmoKit = Instantiate(ammoKit, ammoKitPosition.position, Quaternion.identity);

      }
    }
  }
}
