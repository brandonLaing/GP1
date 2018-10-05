using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

  public float moveSpeed = 5.0f;

  [Header("My Variables")]

  public Vector3 moveLocation;
  public GameObject ball;
  public bool move;
  public float moveableSpeed;
  public Vector3 moveableDirection;

  public int pickupsCollected;
  public int totalNumberOfPickups;

  public GameObject mainCamera;
  public GameObject endCamera;

  public bool debugEnd;

  private void Awake()
  {
    moveLocation = transform.position;
    moveableDirection = transform.right;
    totalNumberOfPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

  }

  private void Update()
  {
    #region Check if should move
    if (Vector3.Distance(this.transform.position, moveLocation) > 1)
    {
      move = true;

    }

    else
    {
      move = false;
      moveLocation = this.transform.position;

    }

    #endregion

    #region Check where the mouse is
    RaycastHit hit;

    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    {
      // check if player clicks mouse
      if (Input.GetMouseButtonDown(1))
      {
        if (hit.transform.tag == "Floor")
        {
          moveLocation = hit.point;

        }

        else
        {
          moveLocation = this.transform.position;

        }

      }

      // check if mouse is over a green object
      if (hit.collider.tag == "MoveableObstacle")
      {
        if (Input.GetKey(KeyCode.Space) && hit.collider.gameObject.GetComponent<MovingObstacle>().canMove)
        {
          hit.transform.position += moveableDirection * hit.collider.gameObject.GetComponent<MovingObstacle>().moveSpeed * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
          moveableDirection *= -1;
          hit.collider.gameObject.GetComponent<MovingObstacle>().canMove = true;

        }


      }

    }

    #endregion

    #region Movement
    if (move)
    {
      Vector3 tempMoveLoc = moveLocation;
      tempMoveLoc.y = this.transform.position.y;
      moveLocation = tempMoveLoc;

      transform.LookAt(moveLocation);
      transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    #endregion

    #region EndGame
    if (pickupsCollected == totalNumberOfPickups || debugEnd)
    {
      swapCameras();

      this.enabled = false;

    }
    #endregion

  }

  private void swapCameras()
  {
    mainCamera.SetActive(false);
    endCamera.SetActive(true);

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Pickup")
    {
      pickupsCollected++;
      StartCoroutine(other.GetComponent<CoinController>().CoinPickedUp());
      StartCoroutine(other.GetComponent<CoinController>().RotateCoin());
      Destroy(other);

    }
  }
}
