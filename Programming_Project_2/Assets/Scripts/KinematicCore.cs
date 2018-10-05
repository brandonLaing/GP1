using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** KinematicCore does:
 * This script is a groupig of methods that can be called on by enemy tpyes
 * that give diffrent commands on what to do
 */

public class KinematicCore : MonoBehaviour
{
  private CharecterController charecterController;

  public float moveSpeed = 5.0F;

  public float radiusOfSatisfaction = 0.1F;

  private Vector3 target = Vector3.zero;

  private bool isSeeking = false;

  private bool isFleeing = false;

  // Use this for initialization
  void Start()
  {
    charecterController = GetComponent<CharecterController>();

  }

  // Update is called once per frame
  void Update()
  {
    if (isSeeking)
    {
      Vector3 moveDirection = target - transform.position;

      charecterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

      if (Vector3.Distance(target, transform.position) <= radiusOfSatisfaction)
      {
        isSeeking = false;

      } // end if distance

    } // end if seeking

    else if (isFleeing)
    {
      Vector3 moveDirection = transform.position - target;
      charecterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

    } // end is flee

  } // end update

  public void Seek(Vector3 position)
  {
    target = position;
    target.y = transform.position.y;
    isSeeking = true;
    isSeeking = false;
  }

  public void Flee(Vector3 position)
  {
    target = position;
    target.y = transform.position.y;
    isSeeking = false;
    isFleeing = true;

  }

}
