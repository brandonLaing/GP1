using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroyScript : MonoBehaviour {

  private void OnCollisionEnter(Collision collision)
  {

    Destroy(gameObject, .01F);



  }

}
