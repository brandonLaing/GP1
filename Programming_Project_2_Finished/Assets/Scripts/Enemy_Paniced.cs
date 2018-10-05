using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Paniced : MonoBehaviour
{
  public GameObject self;
  public GameObject gameController;

  public float moveSpeed = 1F;
  public int moveDirectionTime = 2;
  public float moveTimeStamp;

  public GameObject bullet;

  public int somethingTouchedMe = 0;

  public int gettingTiredTimeCooldown = 4;
  public float gettingTiredTime = 0;

  Vector3 moveDirection = Vector3.zero;
  private void Start()
  {
    // add one to the enemies left counter when the enemy is made
    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();

    controllerScript.enemiesLeft += 1;

  }

  private void OnCollisionEnter(Collision collision)
  {
    // if the collision tag is bullet destroy the enemy and remove one from the enemiesLeft count

    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();

    if (collision.collider.tag == "Bullet")
    {
      controllerScript.enemiesLeft -= 1;
      Destroy(self, 0.0F);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      somethingTouchedMe += 1;
      gettingTiredTime = Time.time + gettingTiredTimeCooldown;
    }

  } // end OnTriggerEnter

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      somethingTouchedMe -= 1;
      
    }
  }

  private void Update()
  {

    if (somethingTouchedMe != 0)
    {
      if (moveTimeStamp < Time.time)
      {
        moveTimeStamp = Time.time + moveDirectionTime;

        // get what direction the player will go
        int randomNumber = Random.Range(1, 5);
        switch (randomNumber)
        {
          // moving forward
          case 1:
            moveDirection = transform.forward;
            break;

          // move backward
          case 2:
            moveDirection = -transform.forward;
            break;

          // move right
          case 3:
            moveDirection = transform.right;
            break;

          // move left
          case 4:
            moveDirection = -transform.right;
            break;

        } // end SWITCH

      } // end Direction set

      transform.position += moveDirection * moveSpeed * Time.deltaTime;

    } // end check for bullets

    if (gettingTiredTime < Time.time)
    {
      somethingTouchedMe = 0;
    }

  } // end update
}
