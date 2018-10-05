using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Eye_Shooting : MonoBehaviour {
  public GameObject bulletPrefab;
  public Transform bulletSpawnLeft;
  public Transform bulletSpawnRight;

  public int bulletVelocity = 6;
  public float lastFire = 0.0F;

  public GameObject selfMain;

  public AudioClip shootSound;

  private AudioSource source;

  private void Start()
  {
    source = GetComponent<AudioSource>();

  }

  // Update is called once per frame
  private void Update()
  {
    Enemy_Smart SelfMainScript = selfMain.GetComponent<Enemy_Smart>();

    if (SelfMainScript.shootLazer)
    {
      if (lastFire <= Time.time)
      {
        SelfMainScript.enemyAnimator.SetTrigger("Shoot_Lazer");
        lastFire = Time.time + 2F;
        Fire();

        if (!source.isPlaying)
        {
          source.PlayOneShot(shootSound, 1);

        }

      }


    }

    else
    {

    }


  }

  public void Fire()
  {
    var bullet01 = (GameObject)Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);

    var bullet02 = (GameObject)Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);

    bullet01.GetComponent<Rigidbody>().velocity = bullet01.transform.forward * bulletVelocity;

    bullet02.GetComponent<Rigidbody>().velocity = bullet02.transform.forward * bulletVelocity;

  }

}
