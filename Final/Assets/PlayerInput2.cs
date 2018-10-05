using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput2 : MonoBehaviour
{

  public float moveSpeed = 5.0f;

  [Header("My Variables")]

  public List<Vector3> moveLocation = new List<Vector3>();
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
    moveableDirection = transform.right;
    totalNumberOfPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

  }

  private void Update()
  {
    #region Check if should move
    if (moveLocation.Count > 0 && Vector3.Distance(this.transform.position, moveLocation[0]) > 1)
    {
      move = true;

    }

    else
    {
      move = false;
      if (moveLocation.Count > 0)
      {
        moveLocation.Remove(moveLocation[0]);

      }

    }

    #endregion

    #region Check where the mouse is
    RaycastHit hit;

    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    {
      // check if player clicks mouse
      if (Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.LeftShift))
      {
        if (hit.transform.tag == "Floor")
        {
          moveLocation = new List<Vector3>();
          moveLocation.Add(hit.point);

        }

        //else
        //{
        //  moveLocation = this.transform.position;

        //}

      }

      else if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftShift))
      {
        if (hit.transform.tag == "Floor")
        {
          moveLocation.Add(hit.point);

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
      Vector3 tempMoveLoc = moveLocation[0];
      tempMoveLoc.y = this.transform.position.y;
      moveLocation[0] = tempMoveLoc;

      transform.LookAt(moveLocation[0]);
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
