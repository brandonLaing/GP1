using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Enemy_Smart Does
 * when the bullet enters the check zone the charecter will look at the bullet
 * the bullet will then check its raycast to see if its going to hit the enemy
 * if it is on a collision path send a message to the smart enemy to move out of the way
 * the enemey will continue to look at the bullet till it is out of its range.
 * 
 * TODO: 
 * set despawn
 * detection radius makes it look at the bullet
 * set method to have charecter to run away from bullet
 */
public class Enemy_Smart : MonoBehaviour
{
  // preset variables
  public GameObject gameController;

  public int speed = 4;

  public bool enemyNearByBool = false;
  public int enemyNearByInt = 0;
  public GameObject currentBullet;

  public float rightOrLeftCooldown = 0.0F;
  private int direction = 0;


  /** Start does:
   * addes enemy to enemy count
   */
  private void Start()
  {
    // add enemy to enemy count
    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();
    controllerScript.enemiesLeft++;

  } // end Start

  /** Update does:
   * looks at bullet if its in the trigger
   * get info from bullet if the bullet is going to get hit
   * moves if its going to get hit
   */
  private void Update()
  {
    if (enemyNearByBool)
    {
      Vector3 currentBulletLocation = currentBullet.transform.position;
      currentBulletLocation.y = transform.position.y;
      transform.LookAt(currentBulletLocation);

      BulletColiderDetection currentBulletScript = currentBullet.GetComponent<BulletColiderDetection>();


      if (currentBulletScript.goingToHit)
      {
        Debug.Log("Bullet is going to hit");

        Vector3 moveDirection = Vector3.zero;

        if (currentBulletScript.bulletImpact == "Forward")
        {
          Debug.Log("Bullet is going to hit forward");

          if (rightOrLeftCooldown < Time.time)
          {
            int direction = Random.Range(0, 2);
          }

          if (direction == 0)
          {
            Debug.Log("Player is going to move to the right");

            moveDirection += transform.right;
            rightOrLeftCooldown = Time.time + 4;
          }

          else
          {
            Debug.Log("Player is going to move to the left");

            moveDirection += -transform.right;
            rightOrLeftCooldown = Time.time + 4;
          }


        }

        else { moveDirection += -transform.forward; }

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

      } // end if bullet is going to hit

    } // end if enemyNearByBool
    
  } // end updatat

  /** OnCollisionEnter does:
   * When a bullet hits the collision it takes one enemy out of the enemiesLeft 
   * and destroies itself
   */
  private void OnCollisionEnter(Collision collision)
  {
    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();
    if ( collision.collider.tag == "Bullet")
    {
      controllerScript.enemiesLeft--;
      Destroy(gameObject);

    } // end if bullet

  } // end OnCollisionEnter

  /** On TriggerEnter does:
   * when the outer trigger is entered by a bullet it sets an alert 
   * that a bullet is near by and counts how many enemies are nearby
   */
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      currentBullet = other.gameObject;

      enemyNearByInt++;
      if (enemyNearByInt != 0)
      {
        enemyNearByBool = true;

      } // end if enemy != 0

    } // end if Bullet

  } // end OnTriggerEnter

  /** OnTriggerExit does:
   * when a bullet leaves the trigger it sets the bool to false and 
   * counts how many enemies are nearby
   */
  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      enemyNearByInt--;
      if(enemyNearByInt == 0)
      {
        enemyNearByBool = false;

      } // end if enemy == 0

    } // end if Bullet

  } // end OnTriggerExit

} // end class