using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
  public GameObject bulletPrefab;
  public Transform bulletSpawn;

  public int bulletVelocity = 6;
  public float lastFire = 0.0F;

  // Update is called once per frame
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      if (lastFire <= Time.time)
      {
        lastFire = Time.time;
        Fire();
      }

    }

  }

  public void Fire()
  {
    var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletVelocity;
    
    //if (bulletColiderScript.bulletCollided == true)
    //{
    //  Debug.Log("This worked");
    //  Destroy(bullet, 0.0F);
    //}

    //Destroy(bullet, 2.0F);

  }
}
