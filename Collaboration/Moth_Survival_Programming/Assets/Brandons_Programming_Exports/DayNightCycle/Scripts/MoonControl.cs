using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonControl : MonoBehaviour
{
  public GameObject Sun;

  private void Awake()
  {
    // set base position for moon
    //transform.position = new Vector3(0, -500, 0);
    //transform.eulerAngles = new Vector3(-90, 0, 0);

    if (Sun == null)
    {
      Sun = GameObject.Find("Sun");

    }

    if (Sun == null)
    {
      Debug.Log("SET THE SUN TO THE GAMEOBJEC POSITION OR NAME IT \"sun\".");

    }
  }

  private void Update()
  {
    transform.RotateAround(Vector3.zero, Vector3.right, Sun.GetComponent<SunControl>().speed * Time.deltaTime);
    transform.LookAt(Vector3.zero);

  }
}
