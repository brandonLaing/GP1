﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewThirdPersonController : MonoBehaviour
{
  public float playerHealth;

  public float shiftSpeed = 8.0F;

  // set player move speed
  public float baseSpeed = 4.0F;

  public float speed;
  // set player camera speed
  public float xAxisRotationSpeed = 500.0F;
  public float yAxisRotationSpeed = 500.0F;

  // set mouse position variables
  public float mouseY;
  public float mouseX;
  public float mouseScroll;

  public float maxView = 90.0F;
  public float minView = -90.0F;

  private float camerFOVTracker = 60F;

  // get character objects transforms
  public Transform playerCamera;
  public Transform playerCharecter;
  public Transform playerAcutalCamera;

  public GameObject thirdPersonCamera;
  public GameObject firstPersonCamera;
  public GameObject endCamera;


  private bool thirdPersonControls = false;
  private bool firstPersonControls = true;
  
  // Update is called once per frame
  void Update ()
  {
    speed = baseSpeed;

    if (Input.GetKey(KeyCode.LeftShift))
    {
      speed = shiftSpeed;

    }

    // move the character forward
    if (Input.GetKey(KeyCode.W))
    {
      // checks if player characters transform is different from the cameras
      if (playerCharecter.transform.forward != playerCamera.transform.forward)
      {
        // create new vector 3 with cameras forward position
        Vector3 cameraForward = playerCamera.transform.forward.normalized;
        cameraForward.y = 0;
        // rotates player character to forward
        playerCharecter.transform.forward += cameraForward;
        // moves the player controller based on cameras loop position
        playerCharecter.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;
        playerCamera.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;

      }

    } // end MOVE FORWARD

    // move the character backward
    if (Input.GetKey(KeyCode.S))
    {
      Vector3 cameraForward = -playerCamera.transform.forward.normalized;
      cameraForward.y = 0;
      playerCharecter.transform.forward += cameraForward;
      playerCharecter.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;
      playerCamera.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;

    } // end MOVE BACKWARD

    // move the character left
    if (Input.GetKey(KeyCode.A))
    {
      Vector3 cameraForward = -playerCamera.transform.right.normalized;
      cameraForward.y = 0;
      playerCharecter.transform.forward += cameraForward;
      playerCharecter.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;
      playerCamera.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;

    } // end MOVE LEFT

    // move the character to the right
    if (Input.GetKey(KeyCode.D))
    {
      Vector3 cameraForward = playerCamera.transform.right.normalized;
      cameraForward.y = 0;
      playerCharecter.transform.forward += cameraForward;
      playerCharecter.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;
      playerCamera.transform.position = playerCharecter.transform.position + cameraForward * Time.deltaTime * speed;

    } // end MOVE RIGHT

    // move the object
    //transform.position += moveDirection.normalized * speed * Time.deltaTime;
    if (thirdPersonControls)
    {
      // rotate the camera left and right
      mouseX = Input.GetAxis("Mouse X");

      playerCamera.transform.Rotate(Vector3.up, mouseX * xAxisRotationSpeed * Time.deltaTime, Space.World);

      // rotate the camera up and down
      mouseY = Input.GetAxis("Mouse Y");

      float angleEulerLimit = playerCamera.transform.eulerAngles.x;

      // fix euler angles if they are over limit
      if (angleEulerLimit > 180)
      {
        angleEulerLimit -= 360;

      }

      if (angleEulerLimit < -180)
      {
        angleEulerLimit += 360;

      }

      // create new float to check what the target rotation would be
      float targetRotation = angleEulerLimit + mouseY * -yAxisRotationSpeed * Time.deltaTime;

      // then if the target rotation is within the min/max view set new rotation
      if (targetRotation < maxView && targetRotation > minView)
      {
        playerCamera.transform.eulerAngles += new Vector3(mouseY * -yAxisRotationSpeed * Time.deltaTime, 0, 0);
      }

      // scroll wheel to zoom camera
      mouseScroll = Input.GetAxis("Mouse ScrollWheel");

      if (mouseScroll > 0F)
      {
        if (camerFOVTracker > 50)
        {
          camerFOVTracker -= 5F;
          Camera.main.fieldOfView -= 5F;

        }
      }

      if (mouseScroll < 0)
      {
        if (camerFOVTracker < 100)
        {
          camerFOVTracker += 5;
          Camera.main.fieldOfView += 5F;
        }
      }
    }

    else if (firstPersonControls)
    {
      thirdPersonCamera.SetActive(false);
      firstPersonCamera.SetActive(true);

      // rotate camera left and right
      mouseX = Input.GetAxis("Mouse X");

      transform.Rotate(Vector3.up, mouseX * xAxisRotationSpeed * Time.deltaTime);

      // rotate the camera up and down
      mouseY = Input.GetAxis("Mouse Y");
      float angleEulerLimit = firstPersonCamera.transform.eulerAngles.x;

      if (angleEulerLimit > 180)
      {
        angleEulerLimit -= 360;
      }

      if (angleEulerLimit < -180)
      {
        angleEulerLimit += 360;
      }

      float targetRotation = angleEulerLimit + mouseY * -yAxisRotationSpeed * Time.deltaTime;

      if (targetRotation < maxView && targetRotation > minView)
      {
        firstPersonCamera.transform.eulerAngles += new Vector3(mouseY * -yAxisRotationSpeed * Time.deltaTime, 0, 0);

      } // end TARGET ROTATION
    }

    if (playerHealth <= 0)
    {
      playerHealth = 0;


      Destroy(gameObject.GetComponent < NewThirdPersonController>());
      Destroy(playerCharecter);

    }

    
	} // end UPDATE

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.tag == "Laser")
    {
      playerHealth -= .5F;
    }
  }
} // end CLASS
