using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPlatform : MonoBehaviour
{
  /** CheckpointPlatform Does:
   * Author: Brandon Laing
   * Controls the checkpoints in the checkpoint system
   */
  #region Variables
  public GameObject checkpointManager;
  public string checkpointManagerTag = "CheckpointManager";
  public string playerTag = "Player";
  public Material[] checkpointMaterials;

  #endregion


  // just aske me if you want to know
  private void Awake()
  {
    checkpointManager = GameObject.FindGameObjectWithTag(checkpointManagerTag);

    gameObject.GetComponent<Renderer>().material.color = Color.red;
    
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == playerTag)
    {
      checkpointManager.GetComponent<CheckpointManager>().currentCheckpoint = gameObject;
      checkpointManager.GetComponent<CheckpointManager>().checkColors = true;

      collision.gameObject.GetComponentInChildren<PlatformProjectorScript>().ResetList();
    }

  }

  public void CheckColor()
  {
    if (checkpointManager.GetComponent<CheckpointManager>().currentCheckpoint == gameObject)
    {
      gameObject.GetComponent<Renderer>().material.color = Color.green;

    }

    else
    {
      gameObject.GetComponent<Renderer>().material.color = Color.red;

    }

  }

} // end checkpointPlatform
