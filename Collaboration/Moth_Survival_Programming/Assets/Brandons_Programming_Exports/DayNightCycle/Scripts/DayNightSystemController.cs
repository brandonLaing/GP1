using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayNightSystemController : MonoBehaviour
{
  public GameObject sun;
  public GameObject moon;

  public float countDown;

  public bool outOfTime = false;

  public string homeSceneName;

  public string nameOfEndScene;

  private void Awake()
  {
    GameObject[] tempArray = GameObject.FindGameObjectsWithTag("DayNightSystem");

    if (tempArray.Length > 1)
    {
      foreach (GameObject system in tempArray)
      {
        if (system.gameObject == this.gameObject)
        {
          Destroy(system);

        }
      }
    }

    DontDestroyOnLoad(this.gameObject);

  }

  private void Update()
  {
    if (SceneManager.GetActiveScene().name != homeSceneLevelName)
    {
      if (countDown > 0)
      {
        countDown -= Time.deltaTime;

      }

      else
      {
        outOfTime = true;
        SceneManager.LoadScene(nameOfEndScene);

      }
    }
  }

  public void AddTime(float timeAdded)
  {
    countDown += timeAdded;

  }
}
