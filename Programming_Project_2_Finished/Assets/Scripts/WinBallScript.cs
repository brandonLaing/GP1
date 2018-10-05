using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBallScript : MonoBehaviour
{
  public GameObject playerController;
  public GameObject mainPlayerCamera;
  public GameObject secondPlayerCamera;
  public GameObject self;

  private void Start()
  {
    Camera startPlayerCamera = mainPlayerCamera.GetComponent<Camera>();
    Camera endPlayerCamera = secondPlayerCamera.GetComponent<Camera>();

    startPlayerCamera.enabled = true;
    endPlayerCamera.enabled = false;

    gameObject.SetActive(false);

  }

  private void OnCollisionEnter(Collision collision)
  {
    MyFirstPersonControler controllerScript = playerController.GetComponent<MyFirstPersonControler>();
    Camera startPlayerCamera = mainPlayerCamera.GetComponent<Camera>();
    Camera endPlayerCamera = secondPlayerCamera.GetComponent<Camera>();

    Collider otherCollider = collision.collider;
    GameObject otherObject = collision.gameObject;
    Transform otherTransform = collision.transform;
    Rigidbody otherRigidbody = collision.rigidbody;

    if (otherObject.tag == "Player")
    {
      controllerScript.enabled = !controllerScript.enabled;

      startPlayerCamera.enabled = !startPlayerCamera.enabled;
      endPlayerCamera.enabled = !endPlayerCamera.enabled;


      //startPlayerCamera.enabled = !startPlayerCamera.enabled;
      //endPlayerCamera.enabled = endPlayerCamera.enabled;

      Destroy(self,1);




    }

  }
}
