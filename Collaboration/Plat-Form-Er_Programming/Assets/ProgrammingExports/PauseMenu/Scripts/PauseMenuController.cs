using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseMenuController : MonoBehaviour
{
  public GameObject pauseMenu;
  public GameObject ammouCount;
  public Text ammoText;

  public PlatformProjectorScript platformScipt;

  public bool gameIsPaused;

  private void Awake()
  {
    //player = GameObject.FindGameObjectWithTag("Player");

  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Numlock))
    {
      if (gameIsPaused)
      {
        _Resume();

      }

      else
      {
        Pause();

      }
    }

    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F4))
    {
      Application.Quit();

    }

    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F4))
    {
      Application.Quit();

    }

    ammoText.text = "Ammo Count: " + (platformScipt.bulletCount).ToString();

  }

  private void Pause()
  {
    pauseMenu.SetActive(true);
    Time.timeScale = 0;
    gameIsPaused = true;
    Cursor.visible = true;
    HideAmmo();

  }

  public void _Resume()
  {
    pauseMenu.SetActive(false);
    Time.timeScale = 1;
    gameIsPaused = false;
    Cursor.visible = false;
    DisplayAmmo();
    
  }

  public void _MainMenu()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("01_MainMenu");

  }

  public void _RestartLevel()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

  }

  public void _QuitGame()
  {
    Application.Quit();

  }

  private void DisplayAmmo()
  {
    ammouCount.SetActive(true);

  }

  private void HideAmmo()
  {
    ammouCount.SetActive(false);

  }
}
