using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
  public GameObject bulletPrefab;
  public Transform bulletSpawn;

  public int bulletVelocity = 6;
  public float lastFire = 0.0F;

  public int bullets;

  public AudioClip shootSound;

  private AudioSource source;

  private void Start()
  {
    source = GetComponent<AudioSource>();

  }
  // Update is called once per frame
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      if (lastFire <= Time.time)
      {
        lastFire = Time.time + 0.8F; 
        if (bullets > 0)
        {
          Fire();
          bullets--;
          if (!source.isPlaying)
          {
            source.PlayOneShot(shootSound, 1);

          }

        }


      }

    }

    else if (source.isPlaying)
    {
      if (lastFire <= Time.time)
      {
        lastFire = Time.time + 0.8F;
        if (bullets > 0)
        {
          Fire();
          bullets--;

        }

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
