using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : MonoBehaviour {
  private bool goingUp = true;
  private bool goingDown = false;

  public float rotationSpeed;

  public GameObject playerController;

  public GameObject pack;

  public Transform baseTransform;

  private float maxTransform;
  private float minTransform;

  public int ammoAdded;

  // Use this for initialization
  void Start()
  {
    baseTransform = pack.transform;

    maxTransform = baseTransform.position.y + .5F;
    minTransform = baseTransform.position.y - .5F;

  }

  // Update is called once per frame
  void Update()
  {
    if (goingUp)
    {
      pack.transform.position += new Vector3(0, 0.01F, 0);

      if (pack.transform.position.y > maxTransform)
      {
        goingUp = false;
        goingDown = true;

      } // swap direction

    } // end going up

    if (goingDown)
    {
      pack.transform.position -= new Vector3(0, 0.01F, 0);

      if (pack.transform.position.y < minTransform)
      {
        goingUp = true;
        goingDown = false;

      } // swap direction

    } // end going down

    pack.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);


  } // end update

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "PlayerPickup")
    {
      GunController controllerScript = GameObject.Find("Gun").GetComponent<GunController>();
      controllerScript.bullets += ammoAdded;

      Destroy(gameObject);

    }

  } // end OnTriggerEnter

} // end class
