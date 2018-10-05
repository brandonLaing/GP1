using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWASD : MonoBehaviour
{
  public LayerMask WallLayer;

  public float speed = 2.0f;

  public bool forwardHitting = false;
  public bool rightHitting = false;
  public bool backwardHitting = false;
  public bool leftHitting = false;

  private bool startingRotation = true;

  private float rayDistance = 1.2F;

  private string nextMove;

  Vector3 moveDirection = Vector3.zero;

  public float timeStamp;
  public float currentTime;

  private CharacterController myController;

  // Use this for initialization
  void Start()
  {
    myController = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    currentTime = Time.time;
    Vector3 aiTransform = transform.position;
    aiTransform.y = 0.5F;

    RaycastHit hitInfo;

    /**
    // check alternat directions
    // check forward right
    if (Physics.Raycast(transform.position, (transform.forward + transform.right).normalized, out hitInfo, rayDistance, WallLayer.value))
    {
      forwardRightHitting = true;
      rightHitting = true;
      forwardHitting = true;


    }

    else
    {
      forwardRightHitting = false;
      rightHitting = false;
      forwardHitting = true;

    }

    // check backward right
    if (Physics.Raycast(transform.position, (-transform.forward + transform.right).normalized, out hitInfo, rayDistance, WallLayer.value))
    {
      backwardRightHitting = true;
      rightHitting = true;
    }

    else
    {
      backwardRightHitting = false;
      rightHitting = false;
    }

    // check forward left
    if (Physics.Raycast(transform.position, (transform.forward + -transform.right).normalized, out hitInfo, rayDistance, WallLayer.value))
    {
      forwardLeftHitting = true;
      leftHitting = true;

    }

    else
    {
      forwardLeftHitting = false;
      leftHitting = false;

    }

    // check backward left
    if (Physics.Raycast(transform.position, (-transform.forward + -transform.right).normalized, out hitInfo, rayDistance, WallLayer.value))
    {
      backwardLeftHitting = true;
      leftHitting = true;

    }

    else
    {
      backwardLeftHitting = false;
      leftHitting = false;

    }
    */

    // check regular 4 directions
    // check if hitting forward
    if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, WallLayer.value))
    {
      forwardHitting = true;

    }

    else
    {
      forwardHitting = false;
    }

    // check if right hit
    if (Physics.Raycast(transform.position, transform.right, out hitInfo, rayDistance, WallLayer.value))
    {
      rightHitting = true;

    }

    else
    {
      rightHitting = false;
    }

    // check if down hit
    if (Physics.Raycast(transform.position, -transform.forward, out hitInfo, rayDistance, WallLayer.value))
    {
      backwardHitting = true;

    }

    else
    {
      backwardHitting = false;
    }


    // check if left hit
    if (Physics.Raycast(transform.position, -transform.right, out hitInfo, rayDistance, WallLayer.value))
    {
      leftHitting = true;

    }

    else
    {
      leftHitting = false;
    }


    /** This part does:
     * This is the ai logic and movement section. Basicly it says if nothing is to the right turn right then move that way.
     */

    if (timeStamp <= Time.time)
    {



      if (Input.GetKey(KeyCode.Space))
      {
        float newX = Mathf.Round(transform.position.x);

        float newZ = Mathf.Round(transform.position.z);

        transform.position = new Vector3(newX, .5F, newZ);
        
        timeStamp = Time.time + 1F;

        // starting movements
        // rotate right till the AI has something on its right then stop rotating
        if (startingRotation)
        {
          if (!rightHitting)
          {
            Debug.Log("turn right");
            gameObject.transform.Rotate(0, 90, 0);
            
          }

          else
          {
            startingRotation = false;
          }

        } // end starting movements

        // special moves
        else if (nextMove != null)
        {
          Debug.Log("starting Special moves");
          
          // Next move should be a forward
          if (nextMove == "Move_Forward")
          {
            Debug.Log("Starting special move forward");
            moveDirection = transform.forward;
          }

          // next move should turn left
          if (nextMove == "Turn_Left")
          {
            gameObject.transform.Rotate(0, -90, 0);

          }
          nextMove = null;

        } // end special moves

        // regular moves
        // if right is hitting move forward unless there is a wall in front. if there is a wall in front and to the right turn right until
        // there isnt a wall in front
        else if (rightHitting)
        {
          if (!forwardHitting)
          {
            Debug.Log("moving forward");
            moveDirection = transform.forward;
          }

          else if (forwardHitting)
          {
            Debug.Log("Turn Left");
            gameObject.transform.Rotate(0, -90, 0);
            
          }

        }

        else if (!rightHitting)
        {
          Debug.Log("move right then forward");
          transform.Rotate(0, 90, 0);
          nextMove = "Move_Forward";

        }

      }

      else
      {
        moveDirection = Vector3.zero;
      }



    }









    if (moveDirection != Vector3.zero)
    {
      myController.Move(moveDirection.normalized * speed * Time.deltaTime);

    }



















    /*
    Vector3 moveDirection = Vector3.zero;

    if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
    if (Input.GetKey(KeyCode.A)) moveDirection -= Vector3.right;
    if (Input.GetKey(KeyCode.S)) moveDirection -= Vector3.forward;
    if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

    if (moveDirection != Vector3.zero)
    {
      myController.Move(moveDirection.normalized * speed * Time.deltaTime);
    }

  */

  } // end update

  private void OnDrawGizmos()
  {
    Vector3 aiTransform = transform.position;
    aiTransform.y = 0.5F;
    // check for forward
    Gizmos.color = Color.green;
    if (forwardHitting)
    {
      Gizmos.color = Color.red;
    }
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);

    // check for backward
    Gizmos.color = Color.green;
    if (backwardHitting)
    {
      Gizmos.color = Color.red;
    }
    Gizmos.DrawLine(transform.position, transform.position + -transform.forward * rayDistance);

    // check for right
    Gizmos.color = Color.green;
    if (rightHitting)
    {
      Gizmos.color = Color.red;
    }
    Gizmos.DrawLine(transform.position, transform.position + transform.right * rayDistance);

    // check for left
    Gizmos.color = Color.green;
    if (leftHitting)
    {
      Gizmos.color = Color.red;
    }
    Gizmos.DrawLine(transform.position, transform.position + -transform.right * rayDistance);


  } // end draw gizmos

} // end class