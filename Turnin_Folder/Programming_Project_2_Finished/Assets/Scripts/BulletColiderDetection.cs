using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColiderDetection : MonoBehaviour
{
  public GameObject self;
  public GameObject player;

  public LayerMask EnemyLayer;
  public float rayDistance = 10.0F;

  private float bulletCheckDistance = 10.0F;

  public bool bulletCollided = false;

  public bool goingToHit = false;

  public string bulletImpact;

  public bool doRaycst = false;

  public int enemyNearByInt = 0;

  private void Start()
  {
    //Debug.Log("destroy start");

    Destroy(self, 10.0F);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.tag != "Player" && collision.collider.tag != "Bullet")
    {

        bulletCollided = true;
        Destroy(self, 0.0F);

    }
  }

  private void Update()
  {
    RaycastHit hitInfo;
    if (doRaycst)
    {


      // hitting straight
      if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, EnemyLayer.value))
      {


        goingToHit = true;
        bulletImpact = "Forward";

      }

      else if (Physics.Raycast(transform.position, transform.right, out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "right";

      }

      else if (Physics.Raycast(transform.position, -transform.right, out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Left";

      }

      else if (Physics.Raycast(transform.position, transform.forward + transform.right, out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Right";

      }

      else if (Physics.Raycast(transform.position, transform.forward + -transform.right, out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Left";

      }

      else if (Physics.Raycast(transform.position, transform.forward + (transform.right / 2), out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Right + Front";

      }

      else if (Physics.Raycast(transform.position, transform.forward + (-transform.right / 2), out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Left + Front";

      }

      else if (Physics.Raycast(transform.position, transform.forward + (transform.right * 2), out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Right + Back";

      }

      else if (Physics.Raycast(transform.position, transform.forward + (-transform.right * 2), out hitInfo, rayDistance, EnemyLayer.value))
      {
        goingToHit = true;
        bulletImpact = "Forward + Left + Back";

      }



      else { goingToHit = false; }
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
    Gizmos.DrawLine(transform.position, transform.position + transform.right * rayDistance);
    Gizmos.color = Color.red; 
    Gizmos.DrawLine(transform.position, transform.position + -transform.right * rayDistance);
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + transform.right) * rayDistance/1.3F);
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + -transform.right) * rayDistance/1.3F);
    Gizmos.color = Color.magenta;
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + (transform.right/2)) * rayDistance);
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + (-transform.right/2)) * rayDistance);
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + (transform.right*2)) * rayDistance/2);
    Gizmos.DrawLine(transform.position, transform.position + (transform.forward + (-transform.right*2)) * rayDistance/2);



  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      enemyNearByInt++;
      if (enemyNearByInt != 0)
      {


        doRaycst = true;
      }
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      enemyNearByInt--;
      if (enemyNearByInt == 0)
      {
        doRaycst = false;
      }
    }
  }
}
