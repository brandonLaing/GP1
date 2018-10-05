using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

  public GameObject checkHeight;

  public GameObject turretController;

  public GameObject endText;

  public GameObject mainCamera;

  public GameObject endCamera;

  private void Start()
  {
    endText.gameObject.SetActive(false);
    endCamera.gameObject.SetActive(false);

  }

  void Update ()
  {
    CheckHeight checkHeightScript = checkHeight.GetComponent<CheckHeight>();

    TurretControl turretContolScript = turretController.GetComponent<TurretControl>();

    Debug.Log(checkHeightScript.destuctablesColliding);

    if (!checkHeightScript.destuctablesColliding)
    {

      Debug.Log("Game Ending");

      turretContolScript.enabled = false;

      endText.gameObject.SetActive(true);

      mainCamera.gameObject.SetActive(false);

      endCamera.gameObject.SetActive(true);

    }

    else
    {
      turretContolScript.enabled = true;

      endText.gameObject.SetActive(false);

      mainCamera.gameObject.SetActive(true);

      endCamera.gameObject.SetActive(false);

    }
	}
}
