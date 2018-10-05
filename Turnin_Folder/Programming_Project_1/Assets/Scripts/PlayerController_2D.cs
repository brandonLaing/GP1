using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2D : MonoBehaviour
{
  public LayerMask floorLayer;
  public LayerMask blockLayer;
  public LayerMask wallLayer;


  public GameObject movePointLocation;

  private bool moveToMouse;

  public float speed = 4.0F;

  private bool useWASD = false;
  private bool useMouse = true;

  // Update is called once per frame
  void Update()
  {
    // switch from wasd to mouse
    if (Input.GetKeyDown(KeyCode.P))
    {
      if (useWASD)
      {
        useWASD = false;
        useMouse = true;

      }

      else if (useMouse)
      {
        useMouse = false;
        useWASD = true;
      }
    }



    // WASD Controls
    if (useWASD)
    {
      Vector3 moveDirection = Vector3.zero;

      // move forward
      if (Input.GetKey(KeyCode.W))
      {
        moveDirection += transform.forward;
        moveToMouse = false;

      } // end move forward

      // move backward
      if (Input.GetKey(KeyCode.S))
      {
        moveDirection += -transform.forward;
        moveToMouse = false;

      } // end move backward

      // move right
      if (Input.GetKey(KeyCode.D))
      {
        moveDirection += transform.right;
        moveToMouse = false;

      } // end move right

      // move left
      if (Input.GetKey(KeyCode.A))
      {
        moveDirection += -transform.right;
        moveToMouse = false;

      } // end move left

      transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }

 
    // mouse Controls
    if (useMouse)
    {
      RaycastHit hitInfo;

      // set move mouse object then move player to it
      if (Input.GetMouseButtonDown(1))
      {
        Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorLayer))
        {
          Vector3 movePosition = hitInfo.point + new Vector3(0, 1, 0);

          movePointLocation.transform.position = hitInfo.point + new Vector3(0, 1, 0);

          moveToMouse = true;


        } // end if

      } // end mouseButton 1

      // stop movement
      if (Input.GetKey(KeyCode.S))
      {
        moveToMouse = false;
      } // end stop movement

      // if player should move to mouse
      if (moveToMouse)
      {
        transform.LookAt(movePointLocation.transform);

        Vector3 moveDirection = Vector3.zero;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 6F, wallLayer.value))
        {
          moveDirection = hitInfo.point + hitInfo.normal;
          moveDirection.y = 1;

        }



        moveDirection += transform.forward;

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

      }

      // stop when player get next object
      if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 0.1F, blockLayer.value))
      {
        moveToMouse = false;
      }

    } // end mouse controls


    /** Testing shift queing
    // mouse Controls
    if (useMouse)
    {
      RaycastHit hitInfo;
      // set move mouse object then move player to it
      if (Input.GetMouseButtonDown(1))
      {
        Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorLayer))
        {
          Vector3 spawnPosition = hitInfo.point + new Vector3(0, 1, 0);
          Instantiate(movePointLocation, spawnPosition, Quaternion.identity);

        } // end if

      } // end mouseButton 1

      // stop movement
      if (Input.GetKey(KeyCode.S))
      {
        moveToMouse = false;
      } // end stop movement

      // if player should move to mouse
      if (moveToMouse)
      {
        transform.LookAt(movePointLocation.transform);

        Vector3 moveDirection = Vector3.zero;

        moveDirection += transform.forward;

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

      }

      // stop when player get next object
      if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 0.1F, blockLayer.value))
      {
        moveToMouse = false;
      }
    }
  */

  } // end update

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1F);
    
  }
} // end class
