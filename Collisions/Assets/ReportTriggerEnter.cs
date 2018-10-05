using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportTriggerEnter : MonoBehaviour
{

  private void OnTriggerEnter(Collider other)
  {
    print("Object " + transform.name + " received trigger enter with ");
    
  } // end TriggerEnter

} // end CLASS
