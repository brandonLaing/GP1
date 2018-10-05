using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnPress : MonoBehaviour
{
  public void _LoadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

  }
}
