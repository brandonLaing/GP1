using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour
{
  public float speed;

  public Material skyboxDay;
  public Material skyboxNight;

  public bool night = false;

  private void Awake()
  {
    //transform.position = new Vector3(0, 500, 0);
    //transform.eulerAngles = new Vector3(90, 0, 0);

  }

  private void Update()
  {
    if (transform.position.y < 0)
    {
      SetNightTime();
      night = true;
      
    }

    else
    {
      SetDayTime();
      night = false;
    }

    transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
    transform.LookAt(Vector3.zero);

  }

  private void SetNightTime()
  {
    RenderSettings.skybox = skyboxNight;

  }

  private void SetDayTime()
  {
    RenderSettings.skybox = skyboxDay;

  }
}
