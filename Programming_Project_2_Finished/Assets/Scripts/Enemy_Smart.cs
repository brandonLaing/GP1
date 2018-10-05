using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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
  private GameObject gameController;

  public Animator enemyAnimator;

  public float speed = 4;

  public bool enemyNearByBool = false;
  public int enemyNearByInt = 0;
  public GameObject currentBullet;

  public bool playerNearByBool = false;
  public GameObject currentPlayer;

  public bool patrol = true;

  public float rightOrLeftCooldown = 0.0F;
  private int direction = 0;

  public GameObject lazerEyes;
  public bool fireLazers;

  public bool movingForward;
  public bool movingBackward;
  public bool movingRight;
  public bool movingLeft;

  public float distanceToPlayer;

  public BoxCollider playerCollider;

  private float lazerEyeCooldownTime;

  public bool shootLazer = true;

  public GameObject lazerEyeScriptObj;

  GameObject[] patrolPoints;
  GameObject currentPoint;

  public AudioClip hitSound;

  private AudioSource source;

  /** Start does:
   * addes enemy to enemy count
   */
  private void Start()
  {
    gameController = GameObject.Find("GameController");

    // add enemy to enemy count
    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();
    controllerScript.enemiesLeft++;

    patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoints");

    source = GetComponent<AudioSource>();

  } // end Start

  /** Update does:
   * looks at bullet if its in the trigger
   * get info from bullet if the bullet is going to get hit
   * moves if its going to get hit
   */
  private void Update()
  {
    movingForward = false;
    movingBackward = false;
    movingLeft = false;
    movingRight = false;

    if (playerNearByBool)
    {
      Vector3 playerLocation = currentPlayer.transform.position;
      playerLocation.y = transform.position.y;
      transform.LookAt(playerLocation);

      distanceToPlayer = Vector3.Distance(playerLocation, transform.position);

      if (Vector3.Distance(playerLocation, transform.position) < 5)
      {
        transform.position += -transform.forward * speed * Time.deltaTime;

        movingBackward = true;
      }

      else if (Vector3.Distance(playerLocation, transform.position) > 6F && Vector3.Distance(playerLocation, transform.position) < 15)
      {
        transform.position += transform.forward * speed * Time.deltaTime;

        movingForward = true;
      }


    }


    else if (enemyNearByBool)
    {
      Vector3 currentBulletLocation = currentBullet.transform.position;
      currentBulletLocation.y = transform.position.y;
      transform.LookAt(currentBulletLocation);

      BulletColiderDetection currentBulletScript = currentBullet.GetComponent<BulletColiderDetection>();


      if (currentBulletScript.goingToHit)
      {
        //Debug.Log("Bullet is going to hit");

        Vector3 moveDirection = Vector3.zero;

        if (currentBulletScript.bulletImpact == "Forward")
        {
          //Debug.Log("Bullet is going to hit forward");

          if (rightOrLeftCooldown < Time.time)
          {
            int direction = Random.Range(0, 2);
          }

          if (direction == 0)
          {
            //Debug.Log("Player is going to move to the right");

            moveDirection += transform.right;
            rightOrLeftCooldown = Time.time + 4;
            movingRight = true;

          }

          else
          {
            //Debug.Log("Player is going to move to the left");

            moveDirection += -transform.right;
            rightOrLeftCooldown = Time.time + 4;
            movingLeft = true;

          }

        }

        else { moveDirection += -transform.forward; movingBackward = true; }

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

      } // end if bullet is going to hit

    } // end if enemyNearByBool

    else if (patrol)
    {
      if (currentPoint == null)
      {
        currentPoint = patrolPoints[Random.Range(0, patrolPoints.Length)];

      }

      else
      {
        transform.LookAt(currentPoint.transform);
        movingForward = true;

        transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(currentPoint.transform.position, transform.position) < 2)
        {
          currentPoint = null;
        }
      }

    }


    if (movingForward)
    {
      if (!enemyAnimator.GetBool("Moving_ForwardBool"))
      {
        enemyAnimator.SetTrigger("Moving_Forward");

      }

      enemyAnimator.SetBool("Moving_ForwardBool", true);

    }

    else if (movingBackward)
    {
      if (!enemyAnimator.GetBool("Moving_BackBool"))
      {
        enemyAnimator.SetTrigger("Moving_Back");

      }

      enemyAnimator.SetBool("Moving_BackBool", true);

    }

    else if (movingLeft)
    {
      if (!enemyAnimator.GetBool("Moving_LeftBool"))
      {
        enemyAnimator.SetTrigger("Moving_Left");

      }

      enemyAnimator.SetBool("Moving_LeftBool", true);

    }

    else if (movingRight)
    {
      if (!enemyAnimator.GetBool("Moving_RightBool"))
      {
        enemyAnimator.SetTrigger("Moving_Right");

      }

      enemyAnimator.SetBool("Moving_RightBool", true);

    }

    else { ResetAnimationBools(); enemyAnimator.SetBool("Looking_Around", true); }

    if (shootLazer)
    {
      if (lazerEyeCooldownTime < Time.deltaTime)
      {
        lazerEyeCooldownTime = Time.deltaTime + 4F;

      }

    }

    else { shootLazer = false; }

  } // end updatat

  /** OnCollisionEnter does:
   * When a bullet hits the collision it takes one enemy out of the enemiesLeft 
   * and destroies itself
   */
  private void OnCollisionEnter(Collision collision)
  {
    //Debug.Log("was hit");

    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();
    if ( collision.collider.tag == "Bullet")
    {
      //Debug.Log("enemy destroy onCollisionEnter");

      if (!source.isPlaying)
      {
        source.PlayOneShot(hitSound, 1);

      }
      controllerScript.enemiesLeft--;
      Destroy(gameObject, 30F);
      Destroy(playerCollider);
      enemyAnimator.SetTrigger("Dying");
      Enemy_Smart enemyScript = gameObject.GetComponent<Enemy_Smart>();
      Destroy(enemyScript);
      Lazer_Eye_Shooting lazerScript = lazerEyeScriptObj.gameObject.GetComponent<Lazer_Eye_Shooting>();
      Destroy(lazerScript);




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

    if (other.gameObject.tag == "Player")
    {
      currentPlayer = GameObject.Find("Yimmy");

      playerNearByBool = true;
      shootLazer = true;
    }

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

    if (other.gameObject.tag == "Player")
    {
      currentPlayer = GameObject.Find("Yimmy");

      playerNearByBool = false;
      shootLazer = false;
    }

  } // end OnTriggerExit

  public void DoEndAnimation()
  {
    enemyAnimator.SetTrigger("Win_Dance");

  }

  private void ResetAnimationBools()
  {
    enemyAnimator.SetBool("Looking_Around", false);
    enemyAnimator.SetBool("Moving_ForwardBool", false);
    enemyAnimator.SetBool("Moving_BackBool", false);
    enemyAnimator.SetBool("Moving_LeftBool", false);
    enemyAnimator.SetBool("Moving_RightBool", false);

  }
} // end class