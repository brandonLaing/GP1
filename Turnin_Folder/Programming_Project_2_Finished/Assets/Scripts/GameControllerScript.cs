using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
  public int enemiesLeft = 0;

  private Text enemiesLeftDisplay;
  private Text healthDisplay;
  private Text bulletsDisplay;

  public GameObject winBall;
  public GameObject player;
  public GameObject gun;
  

  public int round;

  private void Start()
  {


  }

  // Update is called once per frame
  void Update()
  {
    enemiesLeftDisplay = GameObject.Find("EnemiesLeftBox").GetComponent<Text>();

    healthDisplay = GameObject.Find("HealthDisplayBox").GetComponent<Text>();

    bulletsDisplay = GameObject.Find("BulletsDisplayBox").GetComponent<Text>();

    player = GameObject.Find("Yimmy");

    if (enemiesLeft < 1)
    {


      winBall.SetActive(true); 
    }

    else
    {

      winBall.SetActive(false);

    }
    enemiesLeftDisplay.text = "Enemies Left: " + enemiesLeft;

    MyFirstPersonControler playerScript = player.GetComponent<MyFirstPersonControler>();
    healthDisplay.text = "Health: " + playerScript.playerHealth;

    GunController gunScript = gun.GetComponent<GunController>();
    bulletsDisplay.text = "Bullets Left: " + gunScript.bullets;

    //if (winBall == null && Input.GetKeyDown(KeyCode.Space))
    //{
    //  SceneManager.LoadScene("Scene_00", LoadSceneMode.Single);
    //  round++;
    //}
  }

  
}
